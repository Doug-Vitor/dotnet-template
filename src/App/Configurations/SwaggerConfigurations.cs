using System.Reflection;

namespace App.Configurations;

public static class SwaggerConfigurations
{
  internal static IServiceCollection ConfigureSwagger(this IServiceCollection services) =>
    services.AddSwaggerGen(options => options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml")));

  internal static WebApplication AddSwagger(this WebApplication app)
  {
    if (app.Environment.IsDevelopment()) app.UseSwagger().UseSwaggerUI();
    return app;
  }
}