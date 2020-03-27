using System;
using System.Collections.Generic;
using System.Linq;
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

		public async Task<string> GetData()
		{
			var client = _httpClientFactory.CreateClient("Sdn");

			var result = await client.GetAsync("");

			var resultString = await result.Content.ReadAsStringAsync();

			return resultString;
		}

		public async Task<string> GetHeaders()
		{
			var client = _httpClientFactory.CreateClient("Sdn");

			HttpRequestMessage request = new HttpRequestMessage(
			HttpMethod.Head, "");

			var result = await client.SendAsync(request);

			var headers = result.Content.Headers.ToList();

			return headers.ToString();
		}
	}
}
