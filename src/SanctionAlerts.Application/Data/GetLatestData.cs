using SanctionAlerts.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using SanctionAlerts.Application.ViewModels;

namespace SanctionAlerts.Application.Data
{
	public class GetLatestData
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;
		public GetLatestData(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<Response> Do()
		{
			var sdnEntities = await _context.SdnEntities.OrderByDescending(s => s.LastModified).Take(10).ToListAsync();
			var sdnEntries = _mapper.Map<List<SdnViewModel>>(sdnEntities);

			var lastDownloaded = await _context.GetSvcLastDownloaded();
			var lastModified = await _context.GetSvcLastModified();
			var lastHeadersChecked = await _context.GetSvcLastUpdated();

			return new Response()
			{
				SdnEntries = sdnEntries,
				LastDownloaded = lastDownloaded,
				LastModified = lastModified,
				LastHeadersChecked = lastHeadersChecked
			};
		}

		public class Response
		{
			public List<SdnViewModel> SdnEntries { get; set; }
			public DateTime? LastDownloaded { get; set; }
			public DateTime? LastModified { get; set; }

			public DateTime? LastHeadersChecked { get; set; }
		}
	}
}
