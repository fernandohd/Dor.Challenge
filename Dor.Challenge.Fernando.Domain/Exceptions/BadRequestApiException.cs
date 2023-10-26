using System.Net;
using System.Runtime.CompilerServices;

namespace Dor.Challenge.Fernando.Domain.Exceptions
{
    public class BadRequestApiException : ApiException
    {
        public BadRequestApiException(string? message = null, [CallerFilePath] string? filePath = null, [CallerMemberName] string? method = null, [CallerLineNumber] int? line = null)
        {
            Code = (int)HttpStatusCode.BadRequest;
            Message = message;
            StackTrace = $"On {filePath}; line: {line}";
            Detail = $"Method name: {method}";
        }
    }
}
