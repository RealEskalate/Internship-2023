using System.Net;
using System.Text.Json;
using CineFlex.Application.Responses;

namespace API.MiddleWares
{
    public class ExceptionHandler
    {

        public readonly RequestDelegate _next;
        public readonly IHostEnvironment _env;
        public readonly ILogger<ExceptionHandler> _logger;
        public static JsonSerializerOptions options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        private BaseCommandResponse<Object> response { get; set; }

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger, IHostEnvironment env)
        {
            _env = env;
            _next = next;
            _logger = logger;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            bool failed = false;

            try
            {
                await _next(context);
            }
            
            catch (Exception ex)
            {
                failed = true;
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _logger.LogError(ex, ex.Message);
                response.Message = "ServerError Internal Error";
                response.Success = false;
                response.Value = ex;
            }
            finally
            {
                if (failed)
                {
                    context.Response.ContentType = "application/json";
                    var json = JsonSerializer.Serialize(response, options);
                    await context.Response.WriteAsync(json);

                }

            }
        }


    }
}



