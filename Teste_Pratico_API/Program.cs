using Microsoft.EntityFrameworkCore;
using Teste_Pratico_Contex;
using Teste_Pratico_Repository;
using Teste_Pratico_Service;

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

builder.Services.AddDbContext<Data>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("House"),
        b => b.MigrationsAssembly("Teste_Pratico_API")));


builder.Services.AddScoped<AnuncioRepository>();

builder.Services.AddScoped<AnuncioService>();

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
