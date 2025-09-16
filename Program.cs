var builder = WebApplication.CreateBuilder(args);

// Registro dos serviços
builder.Services.AddTransient<TransientService>();
builder.Services.AddScoped<ScopedService>();
builder.Services.AddSingleton<SingletonService>();

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();
app.Run();
