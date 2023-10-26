using Dor.Challenge.Fernando.App.Common.Interfaces.Persistance;
using System.Linq.Expressions;

namespace Dor.Challenge.Fernando.Infra.Persistance
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        protected readonly IRepository repository;

        public Service(IRepository repository)
        {
            this.repository = repository;
        }

        public virtual IQueryable<TEntity> Read()
        {
            return repository.Read<TEntity>();
        }

        public virtual IQueryable<TEntity> Read(Expression<Func<TEntity, bool>> predicate)
        {
            return repository.Read<TEntity>().Where(predicate);
        }

        public virtual IQueryable<TEntity> Get()
        {
            return repository.Get<TEntity>();
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return repository.Get<TEntity>().Where(predicate);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var entry = await repository.Command<TEntity>().AddAsync(entity);

            return entry.Entity;
        }

        public virtual async Task AddAsync(IEnumerable<TEntity> entities)
        {
            await repository.Command<TEntity>().AddRangeAsync(entities);
        }

        public virtual TEntity Add(TEntity entity)
        {
            return repository.Command<TEntity>().Add(entity).Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            return repository.Command<TEntity>().Update(entity).Entity;
        }

        public virtual void Remove(TEntity entity)
        {
            repository.Command<TEntity>().Remove(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            repository.Command<TEntity>().AddRange(entities);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            repository.Command<TEntity>().UpdateRange(entities);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            repository.Command<TEntity>().RemoveRange(entities);
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await repository.SaveChangesAsync(cancellationToken);
        }
    }
}
