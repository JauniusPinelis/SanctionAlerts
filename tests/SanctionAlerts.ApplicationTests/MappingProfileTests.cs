using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using SanctionAlerts.Application.Mappings;
using SanctionAlerts.Domain.Contracts;
using SanctionAlerts.Domain.Models;

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
	}
}