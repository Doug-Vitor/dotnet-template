var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddVersioning();

builder.Services.ConfigureSwagger();
builder.Services.ConfigureContext(builder.Configuration.GetConnectionString("Default"));

var app = builder.Build();

app.AddSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.AddMiddlewares();

app.Run();