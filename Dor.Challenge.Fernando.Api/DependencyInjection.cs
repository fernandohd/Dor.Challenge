using Dor.Challenge.Fernando.Api.Configuration;

namespace Dor.Challenge.Fernando.Api
{
    /// <summary>
    /// Extension methods for cofigure service in API project
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add modules from API project
        /// </summary>
        /// <param name="services">Contract to register services</param>
        /// <param name="configuration">Contract to register settings</param>
        /// <returns></returns>
        public static IServiceCollection AddWebApiModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SwaggerInfo>(configuration.GetSection(nameof(SwaggerInfo)));

            services.AddSwaggerGen();
            services.AddSwaggerGenNewtonsoftSupport();
            services.ConfigureOptions<ConfigureSwaggerGenOptions>();
            services.AddControllers().ConfigureMvc();
            services.AddEndpointsApiExplorer();

            return services;
        }

        /// <summary>
        /// Add middlewares from API project
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseWebApi(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseUnhandledExceptionMiddleware();

            app.UseHttpsRedirection();
            app.UseAuthorization();

            return app;
        }
    }
}