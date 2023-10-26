using Dor.Challenge.Fernando.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Mime;

namespace Dor.Challenge.Fernando.Infra.Loggers
{
    public class UnhandledExceptionMiddleware
    {
        private readonly RequestDelegate requestDelegate;

        /// <summary>
        /// Middleware used to intercept any unhandled exception and format it
        /// It can be used to log exceptions to external services
        /// </summary>
        /// <param name="requestDelegate">Delegate used to call the API</param>
        public UnhandledExceptionMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ApiException errorModel;

            if (exception is ApiException apiException)
            {
                errorModel = new()
                {
                    Code = apiException.Code,
                    Message = apiException.Message,
                    StackTrace = apiException.StackTrace,
                    Detail = apiException.Detail,
                };
            }
            else
            {
                errorModel = new(exception);
            }

            context.Response.StatusCode = errorModel.Code ?? -1;

            context.Response.ContentType = MediaTypeNames.Application.Json;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(errorModel));
        }
    }
}
