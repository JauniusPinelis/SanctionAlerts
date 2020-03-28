using AutoMapper;
using SanctionAlerts.Database;
using SanctionAlerts.Domain;
using SanctionAlerts.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanctionAlerts.Application.Jobs.Services
{
	public class JobsService : IJobsService
	{
		private readonly IDataService _dataService;
		private readonly DataContext _context;
		private readonly DataParser _parser;
		private readonly IMapper _mapper;

		public JobsService(IDataService dataService, DataContext dataContext, IMapper mapper)
		{
			_dataService = dataService;
			_context = dataContext;
			_mapper = mapper;

			_parser = new DataParser();
		}

		public async Task FetchHeaders()
		=> await new FetchHeaders(_dataService, _context, _parser).Do();

		public async Task FetchData()
		=> await new FetchData(_dataService, _context, _parser, _mapper).Do();
	}
}
