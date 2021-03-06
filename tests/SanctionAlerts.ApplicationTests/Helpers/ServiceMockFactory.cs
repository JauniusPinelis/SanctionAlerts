﻿using AutoMapper;
using Moq;
using NUnit.Framework;
using SanctionAlerts.Application.Mappings;
using SanctionAlerts.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SanctionAlerts.ApplicationTests.Helpers
{
	public class ServiceMockFactory
	{
		public IDataService GetDataService()
		{
			return GetDataService("Thu, 26 Mar 2020 14:23:25 GMT",
				TestContext.CurrentContext.TestDirectory + "\\Data\\TestData.xml");
		}

		public IDataService GetDataService(string lastModifiedDate, string fileUrl)
		{
			var fileData = File.ReadAllText(fileUrl);
			var headers = new List<KeyValuePair<string, IEnumerable<string>>>();
			headers.Add(new KeyValuePair<string, IEnumerable<string>>
				("Last-Modified",
				new List<string>()
				{
					lastModifiedDate
				}
				));

			var dataService = new Mock<IDataService>();
			dataService.Setup(x => x.GetData()).ReturnsAsync(fileData);
			dataService.Setup(x => x.GetHeaders()).ReturnsAsync(headers);

			return dataService.Object;
		}

		public IMapper GetMapper()
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});

			return mappingConfig.CreateMapper();
		}
	}
}
