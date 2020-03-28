using Microsoft.EntityFrameworkCore;
using SanctionAlerts.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanctionAlerts.Database
{
	public class DataContext : DbContext
	{
		public DbSet<FileInfo> FileInfos { get; set; }

		public DataContext(DbContextOptions options) : base(options)
		{
			
		}

		public void AddOrUpdate()
		{

		}
	}
}
