using AutoMapper;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using SanctionAlerts.Application.Jobs.Services;
using SanctionAlerts.Application.Mappings;
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

		public static void SetAutoMapper(this ServiceCollection services)
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});

			IMapper mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);

		}
	}
}
