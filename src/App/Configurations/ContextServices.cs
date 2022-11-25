using Microsoft.EntityFrameworkCore;

public static class ContextServices
{
    internal static IServiceCollection ConfigureContext(this IServiceCollection services, string connectionString)
    {
        AddDbContext(services, connectionString);
        AddServices(services);
        return services;
    }

    private static IServiceCollection AddDbContext(IServiceCollection services, string connectionString) =>
      services.AddDbContext<ApplicationContext>(/*options => options.Use(connectionString)*/);

    private static IServiceCollection AddServices(IServiceCollection services) => services
      .AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>))
      .AddScoped(typeof(IWritableRepository<>), typeof(WritableRepository<>))
      .AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
}