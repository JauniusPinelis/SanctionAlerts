using Microsoft.EntityFrameworkCore;
using SanctionAlerts.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanctionAlerts.Database
{
	public class DataContext : DbContext
	{
		public DbSet<FileInfo> FileInfos { get; set; }

		public DataContext(DbContextOptions options) : base(options)
		{
			
		}

		public async Task UpdateSvcLastModified(DateTime lastModified)
		{
			var existingEntity = await FileInfos.FirstOrDefaultAsync(f => f.Name == "Svc");
			if (existingEntity != null)
			{
				existingEntity.LastModified = lastModified;
				existingEntity.LastUpdated = DateTime.Now;
			}
			else
			{
				FileInfos.Add(new FileInfo()
				{
					Name = "Svc",
					LastModified = lastModified,
					LastUpdated = DateTime.Now
			});
			}
			await SaveChangesAsync();

		}
	}
}
