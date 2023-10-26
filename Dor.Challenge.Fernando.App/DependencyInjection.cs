using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dor.Challenge.Fernando.App
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppModule(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DummyApplication>());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssemblyContaining<DummyApplication>();
            services.AddFluentValidationAutoValidation();

            return services;
        }
    }

    public class DummyApplication { }
}