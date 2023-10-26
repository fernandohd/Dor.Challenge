namespace Dor.Challenge.Fernando.App.Common.Interfaces.Persistance
{
    public interface IService<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Read();
        IQueryable<TEntity> Read(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(IEnumerable<TEntity> entities);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void UpdateRange(IEnumerable<TEntity> entities);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
