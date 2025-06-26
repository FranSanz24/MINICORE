using MINICORE.ApiService.Data;
using MINICORE.ApiService.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Configuración de la cadena de conexión
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()));

builder.Services.AddAutoMapper(typeof(Program));

// Agregar servicios
builder.Services.AddScoped<ComisionService>();

// Agregar controladores
builder.Services.AddControllers();

var app = builder.Build();

// Configuración de middleware
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
