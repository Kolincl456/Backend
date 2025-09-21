using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace Pos.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        //RequestDelegate, representa el siguiente middleware en el pipeline
        private readonly RequestDelegate _next;

        //ILogger, registra los errores
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        //Método principal que se ejecuta en cada solicitud HTTP
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                //Capturar cualquier excepcion
                await _next(context);
            }
            catch (Exception ex) {
                //Registra la excepción
                _logger.LogError(ex, "Se capturó una excepción inesperada.");
                //Genera una respuesta Http
                await HandleExceptionAsync(context, ex);
            }
        }

        //Método construye una respuesta HTTP en formato JSON cuando ocurre una expción;

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //Obtiene la ruta donde ocurrió el error
            var path = context.Request.Path;
            context.Response.ContentType = "application/json";

            //Asingar un código de estado HTTP según el tipo de excepción

            context.Response.StatusCode = ex switch
            {
                KeyNotFoundException => (int)HttpStatusCode.NotFound,                           //404: Recurso no encontrado
                ArgumentException or ArgumentNullException => (int)HttpStatusCode.BadRequest,   //400: Datos inválidos
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,                //401: No autorizado
                DbUpdateException => (int)HttpStatusCode.Unauthorized,                          //500: Error de base de datos
                _ => (int)HttpStatusCode.InternalServerError,                                   //500: Error génerico
            };

            //Construir mensaje de error personalizado
            var errorResponse = new
            {
                StatusCode = context.Response.StatusCode, //Código de estado HTTP
                Message = context.Response.StatusCode == 500 ? "Ocurrió un error interno en el servidor." : ex.Message,
                Detail = context.Response.StatusCode == 500 && !context.Request.Host.Host.Contains("localhost") ? "Contacte al administrador del sistema " : ex.Message,
                Path = path,
                Timestamp = DateTime.UtcNow,
            };

            //Serializar el JSON en camelCase

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var errorJson = JsonSerializer.Serialize(errorResponse, options);

            //Escribir la respuesta en el cuerpo de la respuesta HTTP
            await context.Response.WriteAsync(errorJson);
        }
    }
}
