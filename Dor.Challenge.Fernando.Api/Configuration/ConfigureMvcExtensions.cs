using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dor.Challenge.Fernando.Api.Configuration
{
    /// <summary>
    /// Extension methods for setting up MVC services
    /// </summary>
    public static class ConfigureMvcExtensions
    {
        /// <summary>
        /// Configure MVC API behavior options for requests. And json formats for responses
        /// </summary>
        /// <param name="builder">An interface for configuring MVC services</param>
        /// <returns></returns>
        public static IMvcBuilder ConfigureMvc(this IMvcBuilder builder)
        {
            builder.ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressInferBindingSourcesForParameters = true;
                options.SuppressModelStateInvalidFilter = true;
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            return builder;
        }
    }
}
