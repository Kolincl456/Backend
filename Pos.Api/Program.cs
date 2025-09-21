using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pos.Api.Middlewares;
using Pos.Model.Context;
using Pos.Model.Models;
using Pos.Repository.Interface;
using Pos.Repository.Repository;
using Pos.Service.Interface;
using Pos.Service.Service;
using System.Reflection;

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

//Configuración de ASP.NET Identity
builder.Services.AddIdentity<Usuario, IdentityRole<int>>().AddEntityFrameworkStores<PosContext>().AddDefaultTokenProviders();


//Configurar validaciones DTOs
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(Assembly.Load("Pos.Dto"));

//Configurar JWT
var secretKey = builder.Configuration["Jwt:secretKey"];
if (string.IsNullOrEmpty(secretKey))
{
    throw new InvalidOperationException("La clave secreta de JWT no está configurada");
}

// Registrar AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Registro de repositorios con sus interfaces
builder.Services.AddScoped<Rol_Repository>();
builder.Services.AddScoped<Categoria_Repository>();
builder.Services.AddScoped<Producto_Repository>();
builder.Services.AddScoped<INegocio_Repository, Negocio_Repository>();
builder.Services.AddScoped<IDocumento_Repository, Documento_Repository>();
builder.Services.AddScoped<IUsuario_Repository, Usuario_Repository>();
builder.Services.AddScoped<IVenta_Repository, Venta_Repository>();

//Registro de servicios con sus interfaces.
builder.Services.AddScoped<Rol_Service>();
builder.Services.AddScoped<Categoria_Service>();
builder.Services.AddScoped<Producto_Service>();
builder.Services.AddScoped<IUsuario_Service, Usuario_Service>();
builder.Services.AddScoped<IDocumento_Service, Documento_Service>();
builder.Services.AddScoped<INegocio_Service, Negocio_Service>();
builder.Services.AddScoped<IVenta_Service, Venta_Service>();

//Activación de las CORS.
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

//Middleware de excepciones personalizadas

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
