using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanctionAlerts.Application.Jobs
{
	public interface IJobsService
	{
		Task FetchHeaders();
	}
}
