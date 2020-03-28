using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using SanctionAlerts.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanctionAlerts.Infrastructure
{
	public static class DependencyInjection
	{
		public static void SetInfrastructure(this IServiceCollection services, string connectionString)
		{
			services.AddSingleton<IDataService, SdnDataService>();
			services.AddHttpClient("Sdn", client =>
			{
				client.BaseAddress = new Uri("https://www.treasury.gov/ofac/downloads/sdn.xml");
			});

			//Hangfire 
			services.AddHangfire(configuration => configuration
			   .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
			   .UseSimpleAssemblyNameTypeSerializer()
			   .UseRecommendedSerializerSettings()
			   .UseSqlServerStorage(connectionString, new SqlServerStorageOptions
			   {
				   CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
				   SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
				   QueuePollInterval = TimeSpan.Zero,
				   UseRecommendedIsolationLevel = true,
				   UsePageLocksOnDequeue = true,
				   DisableGlobalLocks = true
			   }));

			JobStorage.Current = new SqlServerStorage(connectionString);

			services.AddHangfireServer();
		}
	}
}
