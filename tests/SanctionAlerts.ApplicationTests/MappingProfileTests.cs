using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using SanctionAlerts.Application.Mappings;
using SanctionAlerts.Domain.Contracts;
using SanctionAlerts.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SanctionAlerts.ApplicationTests
{
	public class MappingProfileTests
	{
		private readonly IMapper _mapper;

		public MappingProfileTests()
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});

			_mapper = mappingConfig.CreateMapper();
		}

		[Test]
		public void Map_SdnEntry_ParsesIdInt()
		{
			var parsedSndEntry = new ParsedSdnEntry()
			{
				UId = "12"
			};

			var sdnEntry = _mapper.Map<SdnEntry>(parsedSndEntry);

			sdnEntry.UId.Should().Be(12);
		}

		[Test]
		public void Map_GivenListOfSdnEntries_ParsesListsCorrectly()
		{
			var parsedSdnEntries = new List<ParsedSdnEntry>()
			{
				new ParsedSdnEntry()
			{
				UId = "12"
			}
			 };
			
			var sdnEntries = _mapper.Map<List<SdnEntry>>(parsedSdnEntries);

			sdnEntries.FirstOrDefault().UId.Should().Be(12);
		}
	}
}