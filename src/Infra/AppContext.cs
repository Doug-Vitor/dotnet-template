using System.Reflection;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    base.OnModelCreating(builder);
  }
}