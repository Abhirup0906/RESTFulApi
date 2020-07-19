using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace RESTFulApi.Web.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomMddleware
    {
        private readonly RequestDelegate _next;
        ILogger<CustomMddleware> logger;
        public CustomMddleware(RequestDelegate next, ILogger<CustomMddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            logger.LogInformation("Custom middleware is executing");
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMddleware>();
        }
    }
}
