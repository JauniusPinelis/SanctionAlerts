using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Linq;
using System.Globalization;
using SanctionAlerts.Domain.models;

namespace SanctionAlerts.Domain
{
	public class DataParser
	{
		public DateTime? GetLastModifiedDate(List<KeyValuePair<string, IEnumerable<string>>> headers)
		{
			// Will need refactoring
			if (headers.Select(h => h.Key).Contains("Last-Modified") &&
				headers.FirstOrDefault(h => h.Key == "Last-Modified").Value.Any())
			{
				var lastModifiedObject = headers.FirstOrDefault(h => h.Key == "Last-Modified");
				var lastModifiedValue = lastModifiedObject.Value.FirstOrDefault();

				return DateTime.Parse(lastModifiedValue, CultureInfo.InvariantCulture);
			}

			return null;
		}

		public SdnData ParseFileData(string data)
		{
			throw new NotImplementedException();
		}
	}
}
