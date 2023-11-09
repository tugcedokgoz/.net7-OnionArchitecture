using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Onion.Application.Interfaces.Repositories;
using Onion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Persistence.Repositories
{
	public class ReadRepository<T> : IReadRepository<T> where T : class, IEntitiyBase, new()
	{
		public readonly DbContext dbContext;
		public ReadRepository(DbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		private DbSet<T> Table { get => dbContext.Set<T>(); } //dbcontext sürekli set etmemek için Table nesnesine atadık

		public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
		{
			Table.AsNoTracking();
			if (predicate is not null) Table.Where(predicate);
			return await Table.CountAsync();
		}

		public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
		{
			if (!enableTracking) Table.AsNoTracking();
			return Table.Where(predicate);
		}

		public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? incule = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
		{
			IQueryable<T> queryable = Table;
			if (!enableTracking) queryable = queryable.AsNoTracking();
			if (incule is not null) queryable = incule(queryable);
			if (predicate is not null) queryable = queryable.Where(predicate);
			if (orderBy is not null)
				return await orderBy(queryable).ToListAsync();

			return await queryable.ToListAsync();
		}

		public async Task<IList<T>> GetAllAsyncByPaging(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? incule = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
		{
			IQueryable<T> queryable = Table;
			if (!enableTracking) queryable = queryable.AsNoTracking();
			if (incule is not null) queryable = incule(queryable);
			if (predicate is not null) queryable = queryable.Where(predicate);
			if (orderBy is not null)
				return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

			return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
		}

		public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? incule = null, bool enableTracking = false)
		{
			IQueryable<T> queryable = Table;
			if (!enableTracking) queryable = queryable.AsNoTracking();
			if (incule is not null) queryable = incule(queryable);

			//queryable.Where(predicate);

			return await queryable.FirstOrDefaultAsync();
		}
	}
}
