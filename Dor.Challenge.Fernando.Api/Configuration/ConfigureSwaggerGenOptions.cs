using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Dor.Challenge.Fernando.Api.Configuration
{
    /// <summary>
    /// Options to configure swagger
    /// </summary>
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly SwaggerInfo options;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerGenOptions" /> class using the specified settings.
        /// </summary>
        /// <param name="options">Settings regitered in configuration</param>
        public ConfigureSwaggerGenOptions(IOptions<SwaggerInfo> options)
        {
            this.options = options.Value;
        }

        /// <summary>
        /// A method used to configure options for swagger.
        /// </summary>
        /// <param name="options">Generics options for swagger</param>
        public void Configure(SwaggerGenOptions options)
        {
            options.CustomSchemaIds(type => type.ToString());

            options.SwaggerDoc(this.options.Version, CreateVersionInfo());
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
        }

        private OpenApiInfo CreateVersionInfo()
        {
            var openInfo = new OpenApiInfo
            {
                Title = options.Title,
                Version = options.Version,
                Description = options.Description,
                Contact = new OpenApiContact
                {
                    Name = options.Company,
                    Url = new Uri(options.Url!)
                }
            };

            return openInfo;
        }
    }

    /// <summary>
    /// Settings used to configure swagger
    /// </summary>
    public class SwaggerInfo
    {
        /// <summary>
        /// REQUIRED. The title of the application.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// REQUIRED. The version of the OpenAPI document.
        /// </summary>
        public string? Version { get; set; }

        /// <summary>
        /// The identifying name of the contact person/organization.
        /// </summary>
        public string? Company { get; set; }


        /// <summary>
        /// The URL pointing to the contact information. MUST be in the format of a URL.
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// A short description of the application.
        /// </summary>
        public string? Description { get; set; }
    }
}
