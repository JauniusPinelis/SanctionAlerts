using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SanctionAlerts.Database.Entities
{
	public class SdnEntity
	{
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
		public int UId { get; set; }
		public string LastName { get; set; }
		public string SdnType { get; set; }
		public DateTime LastModified { get; set; }
	}
}
