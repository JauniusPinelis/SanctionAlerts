using SanctionAlerts.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanctionAlerts.Application.Data
{
	public class GetHeaders
	{
		private readonly IDataService _dataService;

		public GetHeaders(IDataService dataService)
		{
			_dataService = dataService;
		}

		public async Task<string> Do()
		{
			return await _dataService.GetHeaders();
		}

	}
}
