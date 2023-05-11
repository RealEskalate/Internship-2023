using BlogApp.Application.Exceptions;
using BlogApp.Application.Responses;
using Newtonsoft.Json;

namespace BlogApp.API.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Call the next middleware in the pipeline
            await _next(context);
        }
        catch (Exception ex)
        {
            // Log the error
            Console.WriteLine($"An error occurred: {ex}");

            switch (ex)
            {
                case BadRequestException badRequestException:
                {
                    var response = new Result<string>()
                    {
                        Success = false,
                        Message = badRequestException.Message,
                        Errors = new List<string> { badRequestException.Message }
                    };
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    break;
                }
                case NotFoundException notFoundException:
                {
                    var response = new Result<string>()
                    {
                        Success = false,
                        Message = notFoundException.Message,
                        Errors = new List<string> { notFoundException.Message }
                    };
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = 404;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    break;
                }
                case ValidationException validationException:
                {
                    var response = new Result<string>()
                    {
                        Success = false,
                        Message = validationException.Message,
                        Errors = validationException.Errors
                    };
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    break;
                }
                default:
                {
                    var response = new Result<string>()
                    {
                        Success = false,
                        Message = ex.Message,
                        Errors = new List<string> { ex.Message }
                    };
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    break;
                }
            }
        }
    }
}