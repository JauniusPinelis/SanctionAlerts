using Newtonsoft.Json;
using SanctionAlerts.Database;
using SanctionAlerts.Domain;
using SanctionAlerts.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanctionAlerts.Application.Jobs
{
	public class FetchData
	{
		private readonly IDataService _dataService;
		private readonly DataContext _context;
		private readonly DataParser _parser;

		public FetchData(IDataService dataService, DataContext context, 
			DataParser parser)
		{
			_dataService = dataService;
			_context = context;
			_parser = parser;
		}

		public async Task Do()
		{
			var unstructuredData = await _dataService.GetData();

			var data = _parser.ParseFileData(unstructuredData);
		}
	}
}
