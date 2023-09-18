using CarAnnouncements.ToDoItems;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CarAnnouncements.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<System.Threading.Tasks.Task> logger)
        {
            _logger = logger;
            _next = next;
        }
        public async System.Threading.Tasks.Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async System.Threading.Tasks.Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string jsonResponse = JsonConvert.SerializeObject(new Response()
            {
                Status = context.Response.StatusCode.ToString(),
                Message = "Internal Server Error from the custom middleware."
            });
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}

