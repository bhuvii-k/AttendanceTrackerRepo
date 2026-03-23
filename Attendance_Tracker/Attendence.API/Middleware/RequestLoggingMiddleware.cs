using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using log4net;

namespace AttendanceTracker.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly ILog _log = LogManager.GetLogger(typeof(RequestLoggingMiddleware));

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // 🔹 Extract user info from JWT
            var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Anonymous";
            var username = context.User?.FindFirst(ClaimTypes.Name)?.Value ?? "Anonymous";

            try
            {
                // 🔹 Request log
                _log.Info($"Request: {context.Request.Method} {context.Request.Path} | UserId: {userId} | Username: {username}");

                await _next(context);

                // 🔹 Response log
                if (context.Response.StatusCode < 400)
                {
                    _log.Info($"SUCCESS: {context.Request.Path} | Status: {context.Response.StatusCode} | UserId: {userId}");
                }
                else
                {
                    _log.Warn($"FAILURE: {context.Request.Path} | Status: {context.Response.StatusCode} | UserId: {userId}");
                }
            }
            catch (Exception ex)
            {
                _log.Error($"EXCEPTION: {context.Request.Path} | UserId: {userId}", ex);
                throw;
            }
        }
    }
}