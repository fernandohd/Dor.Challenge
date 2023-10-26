using Dor.Challenge.Fernando.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Dor.Challenge.Fernando.Infra.Persistance
{
    public interface IDorDbContext : IDisposable
    {
        DatabaseFacade Database { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class DorDbContext : DbContext, IDorDbContext
    {
        public DorDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entityTypes = typeof(DummyDomain).Assembly.GetTypes().Where(type => type.GetCustomAttribute<TableAttribute>() != null);

            foreach (var type in entityTypes) modelBuilder.Entity(type);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
