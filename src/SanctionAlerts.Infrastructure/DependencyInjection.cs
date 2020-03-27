using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanctionAlerts.Infrastructure
{
	public static class DependencyInjection
	{
		public static void SetInfrastructure(IServiceCollection services)
		{
			services.AddHttpClient("Sdn", client =>
			{
				client.BaseAddress = new Uri("https://www.treasury.gov/ofac/downloads/sdn.xml");
			});
		}
	}
}
