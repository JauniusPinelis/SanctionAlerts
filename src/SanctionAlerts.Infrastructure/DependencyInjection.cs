using Microsoft.Extensions.DependencyInjection;
using SanctionAlerts.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanctionAlerts.Infrastructure
{
	public static class DependencyInjection
	{
		public static void SetInfrastructure(this IServiceCollection services)
		{
			services.AddSingleton<IDataService, SdnDataService>();
			services.AddHttpClient("Sdn", client =>
			{
				client.BaseAddress = new Uri("https://www.treasury.gov/ofac/downloads/sdn.xml");
			});

			
		}
	}
}
