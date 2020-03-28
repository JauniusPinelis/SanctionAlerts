using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanctionAlerts.Application.Jobs.Services
{
	public interface IJobsService
	{
		Task FetchHeaders();
		Task FetchData();
	}
}
