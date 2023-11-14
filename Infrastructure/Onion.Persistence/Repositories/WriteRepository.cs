using Microsoft.EntityFrameworkCore;
using Onion.Application.Interfaces.Repositories;
using Onion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntitiyBase, new()
	{
		public readonly DbContext dbContext;
		public WriteRepository(DbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		private DbSet<T> Table { get => dbContext.Set<T>(); } //dbcontext sürekli set etmemek için Table nesnesine atadık

		public async Task AddAsync(T entity)
		{
			await Table.AddAsync(entity);
		}

		public async Task AddRangeAsync(IList<T> entities)
		{
			await Table.AddRangeAsync(entities);
		}

		public async Task HardDeleteAsync(T entity)
		{
			await Task.Run(() => Table.Remove(entity));
		} 

		public async Task<T> UpdateAsync(T entity)
		{
			await Task.Run(() => Table.Update(entity));
			return entity;
		}
	}
}
