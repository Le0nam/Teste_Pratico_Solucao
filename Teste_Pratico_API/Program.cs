using Teste_Pratico_API.Data;
using Teste_Pratico_API.Repositories;
using Teste_Pratico_API.Services;
using Microsoft.EntityFrameworkCore;
using Teste_Pratico_API.Data;
using Teste_Pratico_API.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Permite o localhost:3000 (onde o React está rodando)
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Services.AddControllers();


// Add services to the container.
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("House")));

builder.Services.AddScoped<IAnuncioRepository, AnuncioRepository>();

builder.Services.AddScoped<AnuncioService>(); // Registra o AnuncioService como um serviço injetável

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();


app.MapControllers();

app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
