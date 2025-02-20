using _2._Domain.Exceptions;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace _1._API.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                if (error is AggregateException aggregateException)
                {
                    error = aggregateException.InnerException ?? error;
                }

                var statusCode = error switch
                {
                    DuplicateDataException => (int)HttpStatusCode.Conflict, // 409
                    InvalidActionException => (int)HttpStatusCode.UnprocessableEntity, // 422
                    NotFoundException => (int)HttpStatusCode.NotFound, // 404
                    _ => (int)HttpStatusCode.InternalServerError // 500
                };

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                var errorResponse = new
                {
                    statusCode,
                    message = error?.Message,
                    errorType = error.GetType().Name
                };

                response.StatusCode = statusCode;
                await response.WriteAsync(JsonSerializer.Serialize(errorResponse, options));
            }
        }
    }
}
