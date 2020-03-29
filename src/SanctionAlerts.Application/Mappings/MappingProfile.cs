using AutoMapper;
using SanctionAlerts.Application.ViewModels;
using SanctionAlerts.Database.Entities;
using SanctionAlerts.Domain.Contracts;
using SanctionAlerts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanctionAlerts.Application.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ParsedSdnEntry, SdnEntry>()
				.ForMember(dest => dest.UId,
				opt => opt.MapFrom(src => int.Parse(src.UId)));
			CreateMap<SdnEntry, SdnEntity>();
			CreateMap<SdnEntity, SdnViewModel>();
		}

		
	}
}
