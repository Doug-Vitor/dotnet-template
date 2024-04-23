using App.Configurations;

DotNetEnv.Env.Load("../../.env");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddVersioning();
builder.Services.ConfigureCors();

builder.Services.ConfigureSwagger();
builder.Services.ConfigureContext();

var app = builder.Build();

app.AddSwagger();
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.AddMiddlewares();

app.Run();