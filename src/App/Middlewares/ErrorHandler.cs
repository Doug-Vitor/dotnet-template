using System.Net;
using System.Text.Json;

public class ErrorHandlerMiddleware
{
  private readonly RequestDelegate _next;

  private static Dictionary<Type, int> SupportedExceptionsWithStatusCode = new()
    {
        { typeof(Exception), (int)HttpStatusCode.InternalServerError },
        { typeof(ArgumentNullException), (int)HttpStatusCode.BadRequest },
        { typeof(NotFoundException), (int)HttpStatusCode.NotFound }
    };

  public ErrorHandlerMiddleware(RequestDelegate next) => _next = next;

  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (Exception error)
    {
      await HandleExceptionAsync(context, error);
    }
  }

  private Task HandleExceptionAsync(HttpContext context, Exception exception)
  {
    context.Response.ContentType = "application/json";
    context.Response.StatusCode = context.Response.StatusCode > 0 ? context.Response.StatusCode : SupportedExceptionsWithStatusCode.GetValueOrDefault(exception.GetType(), 500);

    ErrorResponseDTO errorResponse = new(context.Response.StatusCode);
    errorResponse.AddMessage(exception.Message);

    return context.Response.WriteAsync(errorResponse.ToJson());
  }
}