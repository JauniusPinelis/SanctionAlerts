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
			string fileData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\Data\\TestData.xml");

			var dataService = new Mock<IDataService>();
			dataService.Setup(x => x.GetData()).ReturnsAsync(fileData);

			var context = new InMemoryDbContextFactory().GetArticleDbContext();

			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});

			var mapper = mappingConfig.CreateMapper();

			var jobService = new JobsService(dataService.Object, context, mapper);

			await jobService.FetchData();

			context.SdnEntities.Count().Should().NotBe(0);
		}

		[Test]
		public async Task FetchData_GivenHeaders_FetchesData()
		{
			string fileData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\Data\\TestData.xml");
			var headers = new List<KeyValuePair<string, IEnumerable<string>>>();
			headers.Add(new KeyValuePair<string, IEnumerable<string>>
				("Last-Modified",
				new List<string>()
				{
					"Thu, 26 Mar 2020 14:23:25 GMT"
				}
				));

			var dataService = new Mock<IDataService>();
			dataService.Setup(x => x.GetData()).ReturnsAsync(fileData);
			dataService.Setup(x => x.GetHeaders()).ReturnsAsync(headers);


			var context = new InMemoryDbContextFactory().GetArticleDbContext();

			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});

			var mapper = mappingConfig.CreateMapper();

			var jobService = new JobsService(dataService.Object, context, mapper);

			await jobService.FetchHeaders();

			await jobService.FetchData();

			context.SdnEntities.Count().Should().NotBe(0);
		}
	}
}
