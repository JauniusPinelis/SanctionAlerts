using FluentAssertions;
using NUnit.Framework;
using SanctionAlerts.Domain;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SanctionAlerts.DomainTests
{
	public class ParserTests
	{
		private readonly DataParser _parser;

		public ParserTests()
		{
			_parser = new DataParser();
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

			lastModified.HasValue.Should().BeTrue();
			lastModified.Value.ToString().Should().Be("2020-03-26 16:23:25");
		}

		[Test]
		public void ParseFileData_GivenTestXml_CountIsCorrect()
		{
			string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\Data\\TestData.xml");
			var sdnEntries =  _parser.ParseFileData(textData);

			sdnEntries.Count.Should().Be(2);
		}

		[Test]
		public void ParseFileData_GivenTestXml_ParsesBasicData()
		{
			string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\Data\\TestData.xml");
			var sdnEntries = _parser.ParseFileData(textData);

			sdnEntries[1].UId.Should().Be("306");
			sdnEntries[1].LastName.Should().Be("BANCO NACIONAL DE CUBA");
			sdnEntries[1].SdnType.Should().Be("Entity");
		}
	}
}