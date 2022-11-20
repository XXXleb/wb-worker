using Microsoft.Data.SqlClient;
using System.Data;
using WbWorker.Domain.Settings.Models;
using WbWorker.Infrastructure.Databases;

namespace WbWorker.Domain.Wb;

public class WbClient
{
	private readonly IDataAccess _db;

	public WbClient(IDataAccess db)
	{
		_db = db;
	}

	public async Task<bool> ApiCallLogGet(byte marketplaceId, byte apiTypeId, DateTime date)
	{
		SqlParameter[] sqlParameters = new[] {
				new SqlParameter("MarketplaceId", marketplaceId),
				new SqlParameter("ApiTypeId", apiTypeId),
				new SqlParameter("DateFrom", date)
			};

		using var ds = await _db.ExecProcedure("wb.ApiCallLog_Get", sqlParameters);

		var result = ds.Tables[0].AsEnumerable().Select(r => r.Field<bool>("Result")).FirstOrDefault();

		return result;
	}

	public async Task SupplyAdd(byte marketplaceId, DateTime dateFrom, DataTable dt)
	{
		SqlParameter[] sqlParameters = new[] {
				new SqlParameter("MarketplaceId", marketplaceId),
				new SqlParameter("DateFrom", dateFrom),
				new SqlParameter("SupplyData", SqlDbType.Structured) { TypeName = "wb.SupplyData", Value = dt }
			};

		await _db.ExecProcedure("wb.Supply_Add", sqlParameters);
	}

	public async Task StockAdd(byte marketplaceId, DateTime dateFrom, DataTable dt)
	{
		SqlParameter[] sqlParameters = new[] {
				new SqlParameter("MarketplaceId", marketplaceId),
				new SqlParameter("DateFrom", dateFrom),
				new SqlParameter("StockData", SqlDbType.Structured) { TypeName = "wb.StockData", Value = dt }
			};

		await _db.ExecProcedure("wb.Stock_Add", sqlParameters);
	}

	public async Task OrderAdd(byte marketplaceId, DateTime dateFrom, DataTable dt)
	{
		SqlParameter[] sqlParameters = new[] {
				new SqlParameter("MarketplaceId", marketplaceId),
				new SqlParameter("DateFrom", dateFrom),
				new SqlParameter("OrderData", SqlDbType.Structured) { TypeName = "wb.OrderData", Value = dt }
			};

		await _db.ExecProcedure("wb.Order_Add", sqlParameters);
	}

	public async Task SaleAdd(byte marketplaceId, DateTime dateFrom, DataTable dt)
	{
		SqlParameter[] sqlParameters = new[] {
				new SqlParameter("MarketplaceId", marketplaceId),
				new SqlParameter("DateFrom", dateFrom),
				new SqlParameter("SaleData", SqlDbType.Structured) { TypeName = "wb.SaleData", Value = dt }
			};

		await _db.ExecProcedure("wb.Sale_Add", sqlParameters);
	}

	public async Task ReportAdd(byte marketplaceId, DateTime dateFrom, DataTable dt)
	{
		SqlParameter[] sqlParameters = new[] {
				new SqlParameter("MarketplaceId", marketplaceId),
				new SqlParameter("DateFrom", dateFrom),
				new SqlParameter("ReportData", SqlDbType.Structured) { TypeName = "wb.ReportData", Value = dt }
			};

		await _db.ExecProcedure("wb.Report_Add", sqlParameters);
	}

	public async Task ExciseAdd(byte marketplaceId, DateTime dateFrom, DataTable dt)
	{
		SqlParameter[] sqlParameters = new[] {
				new SqlParameter("MarketplaceId", marketplaceId),
				new SqlParameter("DateFrom", dateFrom),
				new SqlParameter("ExciseData", SqlDbType.Structured) { TypeName = "wb.ExciseData", Value = dt }
			};

		await _db.ExecProcedure("wb.Excise_Add", sqlParameters);
	}

	public async Task ApiCallLogAdd(byte marketplaceId, byte apiTypeId, DateTime dateFrom, string url, string errorText, int apiTypeScheduleId)
	{
		SqlParameter[] sqlParameters = new[] {
				new SqlParameter("MarketplaceId", marketplaceId),
				new SqlParameter("ApiTypeId", apiTypeId),
				new SqlParameter("DateFrom", dateFrom),
				new SqlParameter("Url", url),
				new SqlParameter("ErrorText", errorText),
				new SqlParameter("ApiTypeScheduleId", apiTypeScheduleId),
			};

		await _db.ExecProcedure("wb.ApiCallLog_Add", sqlParameters);
	}

	public async Task<ApiSetting[]> ApiSettingGet()
	{
		using var ds = await _db.ExecProcedure("wb.ApiSetting_Get");

		return ds.Tables[0].AsEnumerable()
			.Select(r => new ApiSetting()
			{
				MarketplaceId = r.Field<byte>("MarketplaceId"),
				ApiKey = r.Field<string>("ApiKey"),
				ApiTypes = ds.Tables[1].AsEnumerable()
					.Where(x => x.Field<byte>("MarketplaceId") == r.Field<byte>("MarketplaceId"))
					.Select(t =>
						new ApiType()
						{
							Id = t.Field<byte>("Id"),
							Name = t.Field<string>("Name"),
							Url = t.Field<string>("URL"),
							Order = t.Field<byte>("ExecuteOrder"),
							ApiTypeSchedules = GetApiTypeSchedules(ds.Tables[2], t),
							ApiTypeParams = GetApiTypeParams(ds.Tables[3], t)
						}
					).OrderBy(o => o.Order).ToArray()
			}).ToArray();
	}

	private static ApiTypeSchedule[] GetApiTypeSchedules(DataTable dt, DataRow r)
	{
		return dt.AsEnumerable()
			.Where(sh => sh.Field<byte>("ApiTypeId") == r.Field<byte>("Id"))
			.Select(c => new ApiTypeSchedule() { Id = c.Field<int>("Id"), Time = c.Field<TimeSpan>("Time") })
			.ToArray();
	}

	private static ApiTypeParam[] GetApiTypeParams(DataTable dt, DataRow r)
	{
		return dt.AsEnumerable()
			.Where(f => f.Field<byte>("ApiTypeId") == r.Field<byte>("Id") && f.Field<byte>("MarketplaceId") == r.Field<byte>("MarketplaceId"))
			.Select(p => new ApiTypeParam()
			{
				Name = p.Field<string>("Name"),
				Value = p.Field<string>("Value")
			}).ToArray();
	}
}