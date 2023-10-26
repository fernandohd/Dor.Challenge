using Dor.Challenge.Fernando.Infra.Loggers;

namespace Dor.Challenge.Fernando.Api.Configuration
{
    /// <summary>
    /// Extensions to configure middlewares
    /// </summary>
    public static class ConfigureMiddelwareExtensions
    {
        /// <summary>
        /// Use a custom middleware to hanlde exceptions
        /// </summary>
        /// <param name="applicationBuilder">The application used to configure the HTTP pipelines</param>
        /// <returns></returns>
        public static IApplicationBuilder UseUnhandledExceptionMiddleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<UnhandledExceptionMiddleware>();
        }
    }
}
