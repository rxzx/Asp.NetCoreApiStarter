using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.NetCore.Domain.IRepositories
{
    public interface IBaseRepository<TEntity, TKey>
    {
        Task<List<TEntity>> GetAll(CancellationToken ct = default(CancellationToken));
        Task<TEntity> Get(TKey id);
        Task<TKey> Insert(TEntity entity);
        Task<TKey> Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
