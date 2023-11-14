using Onion.Application.Interfaces.Repositories;
using Onion.Application.Interfaces.UnitOfWorks;
using Onion.Persistence.Context;
using Onion.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Persistence.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWorks
	{
		private readonly AppDbContext dbContext;

		public UnitOfWork(AppDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
        public async ValueTask DisposeAsync() =>await dbContext.DisposeAsync();
		public int Save() =>dbContext.SaveChanges();

		public async Task<int> SaveAsync()=>await dbContext.SaveChangesAsync();

		IReadRepository<T> IUnitOfWorks.GetReadRepository<T>() => new ReadRepository<T>(dbContext);

		IWriteRepository<T> IUnitOfWorks.GetWriteRepository<T>()=>new WriteRepository<T>(dbContext);
	}
}
