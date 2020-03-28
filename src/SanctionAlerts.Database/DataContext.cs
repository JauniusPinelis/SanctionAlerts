using Microsoft.EntityFrameworkCore;
using SanctionAlerts.Database.Entities;
using SanctionAlerts.Domain.Models;
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
		public DbSet<SdnEntity> SdnEntities { get; set; }

		public DataContext(DbContextOptions options) : base(options)
		{
			
		}

		public async Task<DateTime?> GetSvcLastModified()
		{
			var SvcFileEntity =  await FileInfos.FirstOrDefaultAsync(f => f.Name == "Svc");

			return SvcFileEntity.LastModified;
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

		public async Task UpdateSdnData(IEnumerable<SdnEntry> sdnEntries)
		{
			//foreach(var sdnEntry in sdnEntries)
			//{
			//	var sdnEntity = SdnEntities.FirstOrDefault(s => s.UId == sdnEntry.UId);
			//	/* ok this is complex - i can compare simple data currently
			//	 * but what if there are many properties - how to compare? 
			//	 * reflection or hash could be a solution?*/
			//	 if (sdnEntity.LastName != sdnEntry.LastName 
			//		|| sdnEntity.SdnType != sdnEntry.SdnType)
			//	{
			//		sdnEntity.LastName = sdnEntry.LastName;
			//		sdnEntity.SdnType = sdnEntry.SdnType;
			//		sdnEntity.LastModified = DateTime.Now;
			//	}
			//}

			await SaveChangesAsync();

			throw new NotImplementedException();

		}
	}
}
