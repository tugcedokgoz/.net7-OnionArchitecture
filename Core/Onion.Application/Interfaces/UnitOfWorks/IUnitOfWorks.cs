using Onion.Application.Interfaces.Repositories;
using Onion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Interfaces.UnitOfWorks
{
	public interface IUnitOfWorks:IAsyncDisposable
	{
		IReadRepository<T> GetReadRepository<T>() where T : class, IEntitiyBase, new();
		IWriteRepository<T> GetWriteRepository<T>() where T: class, IEntitiyBase, new();
		Task<int> SaveAsync();
		int Save();
	}
}
