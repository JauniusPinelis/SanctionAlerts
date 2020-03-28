using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanctionAlerts.Domain.models
{
	public class SdnEntry
	{
		[JsonProperty("uid")]
		public int Id { get; set; }
		[JsonProperty("lastName")]
		public string LastName { get; set; }
	}
}
