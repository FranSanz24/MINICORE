using MINICORE.ApiService.Data;
using MINICORE.ApiService.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de la cadena de conexi�n
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()));

builder.Services.AddAutoMapper(typeof(Program));

// Agregar servicios
builder.Services.AddScoped<ComisionService>();

// Agregar controladores
builder.Services.AddControllers();

var app = builder.Build();

// Configuraci�n de middleware
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
