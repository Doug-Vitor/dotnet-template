namespace App.Configurations;

public static class MiddlewareConfigurations
{
  internal static IApplicationBuilder AddMiddlewares(this IApplicationBuilder application) =>
    application.UseMiddleware<ErrorHandlerMiddleware>();
}