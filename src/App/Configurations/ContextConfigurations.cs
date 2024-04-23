using Microsoft.EntityFrameworkCore;

namespace App.Configurations;

public static class ContextConfigurations
{
    internal static IServiceCollection ConfigureContext(this IServiceCollection services)
    {
        AddDbContext(services);
        AddServices(services);
        return services;
    }

    private static IServiceCollection AddDbContext(IServiceCollection services) =>
      services.AddDbContext<ApplicationContext>(/*options => options.Use(connectionString)*/);

    private static IServiceCollection AddServices(IServiceCollection services) => services
      .AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>))
      .AddScoped(typeof(IWritableRepository<>), typeof(WritableRepository<>))
      .AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
}