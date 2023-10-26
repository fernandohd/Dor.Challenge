using Microsoft.EntityFrameworkCore;

namespace Dor.Challenge.Fernando.Infra.Persistance
{
    public interface IRepository
    {
        IQueryable<TEntity> Read<TEntity>() where TEntity : class;
        IQueryable<TEntity> Get<TEntity>() where TEntity : class;
        DbSet<TEntity> Command<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class Repository : IRepository
    {
        private readonly IDorDbContext awsDbContext;

        public Repository(IDorDbContext awsDbContext)
        {
            this.awsDbContext = awsDbContext;
        }

        public virtual IQueryable<TEntity> Read<TEntity>() where TEntity : class
        {
            return awsDbContext.Set<TEntity>().AsQueryable().AsNoTracking();
        }

        public virtual IQueryable<TEntity> Get<TEntity>() where TEntity : class
        {
            return awsDbContext.Set<TEntity>().AsQueryable();
        }

        public virtual DbSet<TEntity> Command<TEntity>() where TEntity : class
        {
            return awsDbContext.Set<TEntity>();
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return awsDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
