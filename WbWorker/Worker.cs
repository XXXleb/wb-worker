using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using WbWorker.Domain.Settings.Models;
using WbWorker.Domain.Wb;

namespace WbWorker;

public class Worker : BackgroundService
{
	private readonly ILogger<Worker> _logger;
	private readonly WbClient _wbClient;
	private readonly AppSetting _appSetting;

	public Worker(ILogger<Worker> logger, WbClient wbClient, AppSetting appSetting)
	{
		_logger = logger;
		_wbClient = wbClient;
		_appSetting = appSetting;
	}

	protected override async Task ExecuteAsync(CancellationToken cancellationToken)
	{
		ApiSetting[] apiSettings = await _wbClient.ApiSettingGet();

		while (!cancellationToken.IsCancellationRequested)
		{
			_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

			await MainLogic(apiSettings, cancellationToken);

			await Task.Delay(_appSetting.ApiCallIntervalInSecond * 1000, cancellationToken);
		}
	}

	private async Task MainLogic(ApiSetting[] apiSettings, CancellationToken cancellationToken)
	{
		foreach (var apiSetting in apiSettings)
		{
			foreach (var apiType in apiSetting.ApiTypes)
			{
				foreach (var schedule in apiType.ApiTypeSchedules)
				{
					await InternalProcess(apiSetting, apiType, schedule, cancellationToken);
				}
			}
		}
	}

	private async Task InternalProcess(ApiSetting apiSetting, ApiType apiType, ApiTypeSchedule schedule, CancellationToken cancellationToken)
	{
		if (DateTime.Now.TimeOfDay < schedule.Time)
		{
			_logger.LogInformation($"Too early for processing marketplaceId={apiSetting.MarketplaceId}, apiTypeId={apiType.Id}");

			return;
		}

		(long? lastId, string url, DateTime dateFrom) = await IsProcessed(apiSetting, apiType);

		if (lastId >= 0)
		{
			_logger.LogInformation($"Already processed marketplaceId={apiSetting.MarketplaceId}, apiTypeId={apiType.Id}, dateFrom={dateFrom}, url={url}");
			return;
		}

		string errorText = string.Empty;

		int limit = 0;
		if (apiType.Id == 5 /*Report*/)
		{
			int.TryParse(apiType.ApiTypeParams.FirstOrDefault(t => t.Name == "limit")?.Value, out limit);
		}

		lastId = 0;
		long prevId = 0;
		try
		{
			while (true)
			{
				_logger.LogInformation($"Processing: marketplaceId={apiSetting.MarketplaceId}, apiTypeId={apiType.Id}, dateFrom={dateFrom}, url={url}");

				string result = await CallExternalAsync(url, cancellationToken);

				result = string.IsNullOrWhiteSpace(result) || result == "null" ? "[]" : result;

				lastId = await ProcessToDb(apiSetting.MarketplaceId, dateFrom, apiType, result, limit);

				if (lastId == 0)
				{
					break;
				}
				else
				{
					url = url.Replace($"rrdId={prevId}", $"rrdId={lastId}");
					prevId = lastId.Value;
					await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
				}
			}
		}
		catch (Exception ex)
		{
			errorText = ex.Message + ";\n" + ex.StackTrace;
			lastId = null;

			_logger.LogError(errorText);
		}

		await _wbClient.ApiCallLogAdd(apiSetting.MarketplaceId, apiType.Id, dateFrom, url, errorText, schedule.Id, lastId);

		_logger.LogInformation($"Finish processing: marketplaceId={apiSetting.MarketplaceId}, apiTypeId={apiType.Id}, dateFrom={dateFrom}, url={url}");
	}

	private async Task<long> ProcessToDb(byte marketplaceId, DateTime dateFrom, ApiType apiType, string resultJson, int limit)
	{
		DataTable dt;
		long lastId = 0;
		switch (apiType.Id)
		{
			case 1:
				dt = DataWrapper.SupplyDataGet(resultJson);
				await _wbClient.SupplyAdd(marketplaceId, dateFrom, dt);
				break;
			case 2:
				dt = DataWrapper.StockDataGet(resultJson);
				await _wbClient.StockAdd(marketplaceId, dateFrom, dt);
				break;
			case 3:
				dt = DataWrapper.OrderDataGet(resultJson);
				await _wbClient.OrderAdd(marketplaceId, dateFrom, dt);
				break;
			case 4:
				dt = DataWrapper.SaleDataGet(resultJson);
				await _wbClient.SaleAdd(marketplaceId, dateFrom, dt);
				break;
			case 5:
				(dt, lastId) = DataWrapper.ReportDataGet(resultJson, limit);
				await _wbClient.ReportAdd(marketplaceId, dateFrom, dt);
				break;
			case 6:
				dt = DataWrapper.ExciseDataGet(resultJson);
				await _wbClient.ExciseAdd(marketplaceId, dateFrom, dt);
				break;
		}
		return lastId;
	}

	private async Task<string> CallExternalAsync(string url, CancellationToken cancellationToken)
	{
		using HttpClient httpClient = new(new HttpClientHandler() { UseProxy = false });
		httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		httpClient.Timeout = TimeSpan.FromMinutes(30);

		HttpRequestMessage httpRequest = new(HttpMethod.Get, url);

		using HttpResponseMessage response = await httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

		response.EnsureSuccessStatusCode();

		string result = await response.Content.ReadAsStringAsync(cancellationToken);

		return result;
	}

	private async Task<(long?, string, DateTime)> IsProcessed(ApiSetting apiSetting, ApiType apiType)
	{
		var apiParams = apiType.ApiTypeParams.Select(p => ReplaceValues(p.Name, p.Value, apiSetting.ApiKey));
		var @params = string.Join("&", apiParams);
		var url = $"{apiType.Url}?{@params}";

		var dateFrom = DateTime.Parse(apiParams.Where(rp => rp.StartsWith("dateFrom=")).Select(rps => rps.Replace("dateFrom=", "")).First());

		return (await _wbClient.ApiCallLogGet(apiSetting.MarketplaceId, apiType.Id, dateFrom), url, dateFrom);
	}

	private string ReplaceValues(string param, string val, string apiKey)
	{
		string result = $"{param}=";
		string sReplace;

		switch (val)
		{
			case "{curdate}":
				sReplace = DateTime.Today.ToString("yyyy-MM-dd");
				break;
			case "{curdate}-1":
				sReplace = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
				break;
			case "{curmonth}-1":
				sReplace = new DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, 1).ToString("yyyy-MM-dd");
				break;
			case "{curmonth}":
				sReplace = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
				break;
			case "{curweek}":
				sReplace = new DateTime(DateTime.Now.AddDays(-7).Year, DateTime.Now.AddDays(-7).Month, DateTime.Now.AddDays(-7).Day).ToString("yyyy-MM-dd");
				break;
			case "{key}":
				sReplace = apiKey;
				break;
			default:
				sReplace = val;
				break;
		}

		return $"{result}{sReplace}";
	}
}