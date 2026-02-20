using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Middleware;

public class ExceptionsHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionsHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    public static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = exception switch
        {
            KeyNotFoundException => HttpStatusCode.NotFound,
            InvalidOperationException => HttpStatusCode.Conflict,
            ArgumentException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };

        var problemDetails = new ProblemDetails
        {
            Status = (int)statusCode,
            Title = exception.Message,
            Type = $"https://httpstatuses.com/{(int)statusCode}"
        };

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = (int)statusCode;
        
        return context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
    }
}