using Serilog;
using StudentManager.Shared.Exceptions;
using System.Net;
using System.Text.Json;
using ILogger = Serilog.ILogger;

namespace StudentManager.API.Infrastructure.ExceptionMiddleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
            _logger = Log.ForContext<ExceptionHandlingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); // Tiếp tục xử lý request
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Đã xảy ra lỗi không mong muốn");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorResponse = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Đã xảy ra lỗi hệ thống. Vui lòng thử lại sau.",
                    Detail = ex.Message // Bạn có thể bỏ Detail khi deploy production
                };

                var result = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(result);
            }
        }
    }
}
