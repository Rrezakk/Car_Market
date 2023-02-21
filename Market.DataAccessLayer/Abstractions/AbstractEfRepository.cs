
using Market.DataAccessLayer.Interfaces;
using Market.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Market.DataAccessLayer.Abstractions
{
    public abstract class AbstractEfRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected readonly TContext Context;
        public AbstractEfRepository(TContext context)
        {
            this.Context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity?> Delete(int id)
        {
            var entity = await Context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();

            return entity;
        }
        public async Task<TEntity?> Get(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }
        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsQueryable();
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

    }
}