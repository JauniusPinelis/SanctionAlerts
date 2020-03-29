using Microsoft.EntityFrameworkCore;
using SanctionAlerts.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanctionAlerts.ApplicationTests.Helpers
{
	public class InMemoryDbContextFactory
	{
		public DataContext GetArticleDbContext()
		{
			var options = new DbContextOptionsBuilder<DataContext>()
							.UseInMemoryDatabase(Guid.NewGuid().ToString())
							.Options;
			var dbContext = new DataContext(options);

			return dbContext;
		}
	}
}
