using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pos.Model.Context;
using Pos.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

//Obtener y validar la cadena y conexión de la base de datos.
var connetionsString = builder.Configuration.GetConnectionString("Connection");
if (string.IsNullOrEmpty(connetionsString))
{
    throw new InvalidOperationException("La cadena de conexión 'Connection' no está configurada.");
}

builder.Services.AddDbContext<PosContext>(options =>
{
    options.UseNpgsql(connetionsString);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Registro de repositorios con sus interfaces
builder.Services.AddScoped<Rol_Repository>();
builder.Services.AddScoped<Categoria_Repository>();
builder.Services.AddScoped<Producto_Repository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
