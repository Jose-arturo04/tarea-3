using Microsoft.EntityFrameworkCore;
using ProductCrudApp.Data;
using ProductCrudApp.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar servicios al contenedor.
builder.Services.AddControllers();

// 2. REGISTRAR LA BASE DE DATOS
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("Tarea3Db"));

// Configuración de OpenAPI/Swagger
builder.Services.AddOpenApi();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();