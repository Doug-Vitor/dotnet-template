using Microsoft.AspNetCore.Mvc.Versioning;

internal static class VersioningServices
{
  internal static IServiceCollection AddVersioning(this IServiceCollection services) => services.AddApiVersioning(options =>
  {
    options.DefaultApiVersion = new(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                        new QueryStringApiVersionReader(),
                                                        new HeaderApiVersionReader("x-api-version"),
                                                        new MediaTypeApiVersionReader("x-api-version"));
  });
}