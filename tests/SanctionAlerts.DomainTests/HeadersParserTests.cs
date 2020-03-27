using FluentAssertions;
using NUnit.Framework;
using SanctionAlerts.Domain;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace SanctionAlerts.DomainTests
{
	public class HeadersParsersTests
	{
		private readonly HeadersParser _parser;

		public HeadersParsersTests()
		{
			_parser = new HeadersParser();
		}

		[Test]
		public void GetLastModifiedDate_GivenHeadersWithLastModified_ParsesCorrectDate()
		{
			var headers = new List<KeyValuePair<string, IEnumerable<string>>>();
			headers.Add(new KeyValuePair<string, IEnumerable<string>>
				("Last-Modified",
				new List<string>()
				{
					"Thu, 26 Mar 2020 14:23:25 GMT"
				}
				));

			var lastModified = _parser.GetLastModifiedDate(headers);

			lastModified.ToLongDateString().Should().Be("26 Mar 2020 14:23:25 GMT");
		}
	}
}