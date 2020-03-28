using System;
using System.Collections.Generic;
using System.Text;

namespace SanctionAlerts.Domain.Contracts
{
	public class ParsedSdnEntry
	{
		public string UId { get; set; }
		public string LastName { get; set; }
		public string SdnType { get; set; }
	}
}
