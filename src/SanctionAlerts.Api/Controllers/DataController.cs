using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SanctionAlerts.Application.Data;
using SanctionAlerts.Database;
using SanctionAlerts.Domain;
using SanctionAlerts.Infrastructure.Services;

namespace SanctionAlerts.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DataController : ControllerBase
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public DataController(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<GetLatestData.Response> GetData()
			=> await new GetLatestData(_context, _mapper).Do();
	}
}
