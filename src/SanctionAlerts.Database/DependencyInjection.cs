using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanctionAlerts.Database
{
	public static class DependencyInjection
	{
		public static void SetDatabase(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
		}
	}
}
