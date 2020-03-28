using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
		private readonly ILogger<DataController> _logger;
		private readonly IDataService _dataService;
		private readonly DataContext _context;
		private readonly HeadersParser _parser;

		public DataController(ILogger<DataController> logger, IDataService dataService)
		{
			_logger = logger;
			_dataService = dataService;
			
		}

		[HttpGet]
		public async Task<ActionResult> GetData()
			=> Ok(await new GetHeaders(_dataService).Do());
	}
}
