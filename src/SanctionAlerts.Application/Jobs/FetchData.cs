using AutoMapper;
using Newtonsoft.Json;
using SanctionAlerts.Database;
using SanctionAlerts.Domain;
using SanctionAlerts.Domain.Models;
using SanctionAlerts.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanctionAlerts.Application.Jobs
{
	public class FetchData
	{
		private readonly IDataService _dataService;
		private readonly DataContext _context;
		private readonly DataParser _parser;
		private readonly IMapper _mapper;

		public FetchData(IDataService dataService, DataContext context, 
			DataParser parser, IMapper mapper )
		{
			_dataService = dataService;
			_context = context;
			_parser = parser;
			_mapper = mapper;
		}

		public async Task Do()
		{
			var unstructuredData = await _dataService.GetData();

			var parsedSdnEntries = _parser.ParseFileData(unstructuredData);

			var sdnEntries = _mapper.Map<List<SdnEntry>>(parsedSdnEntries);
		}
	}
}
