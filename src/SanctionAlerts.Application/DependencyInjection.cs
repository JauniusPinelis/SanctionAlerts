using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using SanctionAlerts.Application.Jobs.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanctionAlerts.Application
{
	public static class DependencyInjection
	{
		public static void SetJobs(this IServiceCollection services)
		{
			RecurringJob.AddOrUpdate<JobsService>(j => j.FetchHeaders(), Cron.Minutely);
		}
	}
}
