using SanctionAlerts.Database;
using SanctionAlerts.Domain;
using SanctionAlerts.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanctionAlerts.Application.Jobs
{
	public class FetchHeaders
	{
		private readonly IDataService _dataService;
		private readonly DataContext _context;
		private readonly HeadersParser _parser;

		public FetchHeaders(IDataService dataService, DataContext context, 
			HeadersParser parser)
		{
			_dataService = dataService;
			_context = context;
			_parser = parser;
		}

		public async Task Do()
		{
			var headerData =  await _dataService.GetHeaders();
			var lastModified = _parser.GetLastModifiedDate(headerData); 
			
		}
	}
}
