using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using SanctionAlerts.Application.Jobs.Services;
using SanctionAlerts.Infrastructure.Services;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;
using SanctionAlerts.ApplicationTests.Helpers;
using AutoMapper;
using SanctionAlerts.Application.Mappings;
using System.Linq;
using FluentAssertions;

namespace SanctionAlerts.ApplicationTests
{
	public class JobServiceTests
	{
		
		public JobServiceTests()
		{
			
		}

		[Test]
		public async Task TestSetup()
		{
			var serviceMockFactory = new ServiceMockFactory();
			var dataService = serviceMockFactory.GetDataService();
			var mapper = serviceMockFactory.GetMapper();
			var context = new InMemoryDbContextFactory().GetArticleDbContext();
			var jobService = new JobsService(dataService, context, mapper);

			await jobService.FetchData();

			context.SdnEntities.Count().Should().NotBe(0);
		}

		[Test]
		public async Task FetchData_GivenHeaders_FetchesData()
		{
			var serviceMockFactory = new ServiceMockFactory();
			var dataService = serviceMockFactory.GetDataService();
			var mapper = serviceMockFactory.GetMapper();
			var context = new InMemoryDbContextFactory().GetArticleDbContext();
			var jobService = new JobsService(dataService, context, mapper);

			await jobService.FetchHeaders();
			await jobService.FetchData();

			context.SdnEntities.Count().Should().NotBe(0);
		}
	}
}
