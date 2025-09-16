using LifetimeDemo;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// lifetimes
builder.Services.AddTransient<TransientService>();
builder.Services.AddScoped<ScopedService>();
builder.Services.AddSingleton<SingletonService>();

builder.Services.AddControllers();

// -- Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Lifetime Demo API",
        Version = "v1",
        Description = "Demonstração de lifetimes: Transient, Scoped, Singleton"
    });
});

var app = builder.Build();

// -- Swagger UI (pode deixar sempre ligado ou só em Dev)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lifetime Demo API v1");
    c.RoutePrefix = string.Empty; // URL: /swagger
});

app.MapControllers();

app.Run();