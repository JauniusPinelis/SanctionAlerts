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

		[Test]
		public async Task FetchData_UpdatedLastModified_FetchesDataTwice()
		{
			var serviceMockFactory = new ServiceMockFactory();
			var dataService = serviceMockFactory.GetDataService();
			var mapper = serviceMockFactory.GetMapper();
			var context = new InMemoryDbContextFactory().GetArticleDbContext();
			var jobService = new JobsService(dataService, context, mapper);

			await jobService.FetchHeaders();
			await jobService.FetchData();

			var updatedDataService = serviceMockFactory.
				GetDataService("Sun, 29 Mar 2020 14:23:25 GMT",
				TestContext.CurrentContext.TestDirectory + "\\Data\\UpdatedTestData.xml");

			var updatedJobService = new JobsService(updatedDataService, context, mapper);

			await updatedJobService.FetchHeaders();
			await updatedJobService.FetchData();

			context.SdnEntities.Count().Should().NotBe(0);
			context.SdnEntities.FirstOrDefault().SdnType.Should().Be("NewType");
		}
	}
}
