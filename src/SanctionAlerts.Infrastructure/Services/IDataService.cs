using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanctionAlerts.Infrastructure.Services
{
	public interface IDataService
	{
		Task<string> GetData();
		Task<List<KeyValuePair<string, IEnumerable<string>>>> GetHeaders();
	}
}
