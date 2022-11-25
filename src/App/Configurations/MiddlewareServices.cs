public static class MiddlewareServices
{
  internal static IApplicationBuilder AddMiddlewares(this IApplicationBuilder application) =>
    application.UseMiddleware<ErrorHandlerMiddleware>();
}