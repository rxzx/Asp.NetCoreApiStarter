using Asp.NetCore.Domain.IRepositories;
using BolForce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.NetCore.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>, IBase<TKey> where TKey : IEquatable<TKey>
    {
        protected readonly StartupDataContext Context;
        protected DbSet<TEntity> Entities;
        string errorMessage = string.Empty;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public BaseRepository(StartupDataContext context, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            this.Context = context;
            Entities = context.Set<TEntity>();
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public async Task<List<TEntity>> GetAll(CancellationToken ct = default(CancellationToken))
        {
            return await Entities.ToListAsync(ct);
        }

        public async Task<TEntity> Get(TKey id)
        {
            return await Entities.SingleOrDefaultAsync(s => s.Id.Equals(id));
        }

        public async Task<TKey> Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            string ip = string.Empty;

            entity.IsDeleted = false;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;
            //entity.LastModifiedBy = GetUserId(out ip);
            //entity.CreatedBy = GetUserId(out ip);
            entity.UpdatedIp = ip;

            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();

            return entity.Id;
        }

       
        public async Task<TKey> Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            string ip = string.Empty;
            entity.LastModifiedOn = DateTime.UtcNow;
            //entity.LastModifiedBy = GetUserId(out ip);
            entity.UpdatedIp = ip;

            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return entity.Id;
        }

        

        
        public async virtual Task<TEntity> Get(Expression<Func<TEntity, bool>> where, CancellationToken ct = default(CancellationToken))
        {
            return await Entities.Where(where)?.FirstOrDefaultAsync(ct);
        }

        public Task Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
