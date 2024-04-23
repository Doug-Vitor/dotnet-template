namespace App.Configurations;

public static class CorsConfigurations
{
  internal static IServiceCollection ConfigureCors(this IServiceCollection services) =>
    services.AddCors(options =>
    {
      foreach (var key in Origins.KnownOrigins.Keys)
      {
        string[] origins;
        Origins.KnownOrigins.TryGetValue(key, out origins!);
        options.AddPolicy(
          key,
          policy => policy.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod().Build()
        );
      }
    });
}