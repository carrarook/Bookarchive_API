using Application.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace API.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
        }
        catch (APIException ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.UnprocessableEntity);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var result = JsonConvert.SerializeObject(new
        {
            Errors = exception.Message,
            StatusCode = (int)statusCode
        });

        return context.Response.WriteAsync(result);
    }
}
