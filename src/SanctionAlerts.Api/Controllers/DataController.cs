using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SanctionAlerts.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DataController : ControllerBase
	{
		private readonly ILogger<DataController> _logger;

		public DataController(ILogger<DataController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public bool Get()
		{
			return true;
		}
	}
}
