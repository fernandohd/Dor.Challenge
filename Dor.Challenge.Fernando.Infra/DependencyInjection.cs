using Autofac;
using Autofac.Extensions.DependencyInjection;
using Dor.Challenge.Fernando.Infra.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dor.Challenge.Fernando.Infra
{
    /// <summary>
    /// Extension methods for cofigure service in Infra project
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Use EntityFramework extensions to register DbContexts getting the connection strings from settings
        /// </summary>
        /// <param name="services">Contract to register services</param>
        /// <param name="configuration">Contract to get settings</param>
        /// <returns></returns>
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            // In this case an in-memory database is used using the connection string as a name
            services.AddDbContextPool<IDorDbContext, DorDbContext>(builder => builder
                .UseInMemoryDatabase(configuration.GetConnectionString(nameof(DorDbContext))!)
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

            //services.AddHealthChecks().AddDbContextCheck<AwsDbContext>();

            return services;
        }

        /// <summary>
        /// Use the Autofac module to register assembly predicate types
        /// </summary>
        /// <param name="hostBuilder">Contract to preconfigure the host</param>
        public static void RegisterAssembly(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>((context, builder) =>
                {
                    builder.RegisterModule(new AutofacInfrastructureModule());
                });
        }
    }

    public class AutofacInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(AutofacInfrastructureModule).Assembly;

            // Any public, non-abstract, non-interface type as an implemented interface.
            builder.RegisterAssemblyTypes(assembly).PublicOnly()
                .Where(t => !t.IsAbstract && !t.IsInterface).AsImplementedInterfaces();

            // Any public, non-abstract, non-interface generic type as an implemented interface.
            builder.RegisterAssemblyOpenGenericTypes(assembly)
                .Where(t => !t.IsAbstract && !t.IsInterface).AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}