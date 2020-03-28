using System;
using System.Collections.Generic;
using System.Text;

namespace SanctionAlerts.Database.Entities
{
	public class FileInfo
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime LastModified { get; set; }
		public DateTime LastUpdated { get; set; }
	}
}
