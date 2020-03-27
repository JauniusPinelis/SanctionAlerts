using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SanctionAlerts.Infrastructure.Services
{
    public class SdnDataService : IDataService
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public SdnDataService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public Task<string> GetData()
		{
			throw new NotImplementedException();
		}

		public Task<string> GetHeaders()
		{
			throw new NotImplementedException();
		}
	}
}
