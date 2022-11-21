using Microsoft.Extensions.Options;
using WbWorker;
using WbWorker.Domain.Wb;
using WbWorker.Infrastructure.Databases;
using WbWorker.Infrastructure.Databases.MSSQL;

IHost host = Host.CreateDefaultBuilder(args)
	.ConfigureServices((hostContext, services) =>
	{
		services.Configure<DatabaseCredential>(hostContext.Configuration.GetSection("DatabaseCredential"));
		services.AddSingleton(cfg => cfg.GetService<IOptions<DatabaseCredential>>().Value);

		services.Configure<AppSetting>(hostContext.Configuration.GetSection("AppSetting"));
		services.AddSingleton(cfg => cfg.GetService<IOptions<AppSetting>>().Value);

		services.AddSingleton<IDataAccess, DataAccess>();
		services.AddSingleton<WbClient>();
		services.AddHostedService<Worker>();
	})
	.UseWindowsService()
	.Build();

await host.RunAsync();