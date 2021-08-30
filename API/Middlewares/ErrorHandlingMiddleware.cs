using Common.Errors;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExpectionAsync(httpContext, e);
            }
        }

        private async Task HandleExpectionAsync(HttpContext httpContext, Exception e)
        {
            Object error = null;
            switch (e)
            {
                case RestException re:
                    error = re.Error;
                    Log.Error(e, "Rest Error");
                    httpContext.Response.StatusCode = (int)re.Code;
                    break;
                case Exception ex:
                    error = String.IsNullOrEmpty(ex.Message) ? "Error" : ex.Message;
                    Log.Error(ex, "Server Error");
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
                default:
                    break;
            }

            httpContext.Response.ContentType = "application/json";
            if (error != null)
            {
                var result = JsonSerializer.Serialize(new
                {
                    error
                });

                await httpContext.Response.WriteAsync(result);
            }
        }
    }
}
