using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SanctionAlerts.Application.Data;
using SanctionAlerts.Infrastructure.Services;

namespace SanctionAlerts.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DataController : ControllerBase
	{
		private readonly ILogger<DataController> _logger;
		private readonly IDataService _dataService;

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
