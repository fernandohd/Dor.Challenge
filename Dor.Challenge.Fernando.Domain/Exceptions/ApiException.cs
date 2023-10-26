using Newtonsoft.Json;
using System.Collections;
using System.Net;
using System.Reflection;
using System.Text;

namespace Dor.Challenge.Fernando.Domain.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException() { }

        public ApiException(Exception? exception, bool isInner = false)
        {
            Code = isInner ? null : (int)HttpStatusCode.InternalServerError;
            Message = exception?.Message;
            StackTrace = CleanStackTrace(exception?.StackTrace);
            Data = exception?.Data;
            HelpLink = exception?.HelpLink;
            HResult = exception?.HResult;
            InnerException = isInner ? null : new ApiException(exception?.InnerException, true);
            Source = exception?.Source;
        }

        public int? Code { get; set; }

        public new string? Message { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Detail { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new string? StackTrace { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new IDictionary? Data { get; set; } = null;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new ApiException? InnerException { get; set; } = null;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new string? HelpLink { get; set; } = null;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new string? Source { get; set; } = null;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new int? HResult { get; set; } = null;


        private static string? CleanStackTrace(string? stackTrace)
        {
            if (stackTrace is null) return null;

            var builder = new StringBuilder();

            var name = Assembly.GetExecutingAssembly().GetName().Name!.Split('.')[0];

            using (var reader = new StringReader(stackTrace))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null) break;

                    if (!line.Contains(name!)) continue;

                    builder.AppendLine(line);
                }
            }

            return builder.ToString();
        }
    }
}
