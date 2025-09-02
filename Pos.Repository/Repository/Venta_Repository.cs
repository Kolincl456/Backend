using Microsoft.EntityFrameworkCore;
using Pos.Model.Context;
using Pos.Model.Models;
using Pos.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Repository.Repository
{
    public class Venta_Repository : IVenta_Repository
    {
        private readonly PosContext _posContext;
        private readonly IDocumento_Repository _documento_Repository;
        public  Venta_Repository(PosContext poscontext,  IDocumento_Repository documento_Repository)
        {
            _posContext = poscontext;
            _documento_Repository = documento_Repository;
        }

        public async Task ActualizarStock(List<DetalleVenta> detalleVentas)
        {
            if(detalleVentas == null){
                throw new("La lista de detalles de venta está vacía");
            }
            foreach (var detalle in detalleVentas) { 
                var producto = await _posContext.Productos
                    .AsTracking()
                    .FirstOrDefaultAsync(p => p.IdProducto == detalle.IdProducto);

                if (producto == null) {
                    throw new KeyNotFoundException($"El producto con el ID: {detalle.IdProducto} no existe en el inventario.");
                }
                if(producto.Stock < detalle.Cantidad){
                    throw new InvalidCastException($"No hay suficientes stock para el producto: {producto.Descripcion}. " +
                        $"Stock Disponible: {producto.Stock}, cantidad solicitada: {detalle.Cantidad}.");
                }
                producto.Stock -= detalle.Cantidad;
            }
            await _posContext.SaveChangesAsync();
        }

        public async Task<Venta?> AnularVenta(int idVenta, string motivo, int idUsuario)
        {
            var venta = await _posContext.Ventas
                .Include(v => v.DetalleVentas)
                .FirstOrDefaultAsync(v => v.IdVenta == idVenta);
            if (venta == null) {
                throw new KeyNotFoundException($"La venta con el ID: {idVenta} no existe o fue eliminada.");
            }
            //Actualizar Venta
            venta.Estado = EstadoVenta.Anulada;
            venta.FechaAnulada = DateOnly.FromDateTime( DateTime.Today );
            venta.Motivo = motivo;
            venta.UsuarioAnula = idUsuario;
            //Actualizar stock del producto
            if (venta.DetalleVentas?.Any() == true) {
                foreach (var detalle in venta.DetalleVentas) {
                    var producto = await _posContext.Productos
                        .FindAsync(detalle.IdProducto);
                    if (producto != null) {
                        producto.Stock += detalle.Cantidad;
                    }
                }
            }
            await _posContext.SaveChangesAsync();
            return venta;
        }

        public async Task<List<Venta>> BuscarFecha(DateOnly FechaInicio, DateOnly FechaFin)
        {
            return await _posContext.Ventas
                .Where(v => v.Fecha >= FechaInicio && v.Fecha <= FechaFin)
                .ToListAsync();
        }

        public async Task<Venta> Create(Venta Venta)
        {
            using var transaction = await _posContext.Database.BeginTransactionAsync();
            try
            {
                var numeroDocumento = await _documento_Repository.Get();
                string documentoSiguiente;

                if (numeroDocumento != null)
                {
                    documentoSiguiente = "0001";
                    var documentoDocumento = new NumeroDocumento { Documento = documentoSiguiente };
                    await _documento_Repository.Create(numeroDocumento);
                }
                else
                {
                    var documentoActual = int.Parse(numeroDocumento.Documento);
                    documentoSiguiente = (documentoActual + 1).ToString("D4");
                }
                Venta.Factura = documentoSiguiente;
                if (string.IsNullOrEmpty(Venta.Factura))
                {
                    throw new InvalidOperationException("No se puede generar el número de factura. Inténtelo nuevamente.");
                }

                if (Venta.DetalleVentas?.Any() == true)
                {
                    await ActualizarStock(Venta.DetalleVentas.ToList());
                }

                _posContext.Add(Venta);
                await _posContext.SaveChangesAsync();

                if (numeroDocumento != null) {
                    numeroDocumento.Documento = documentoSiguiente;
                    await _documento_Repository.Update(numeroDocumento);
                }

                await transaction.CommitAsync();
                return Venta;
            }
            catch (Exception ex) { 
                await transaction.RollbackAsync(); 
                throw new Exception("Ocurrió un error al registrar la venta,", ex);
            }
        }

        public async Task<List<Venta>> GetAll()
        {
            return await _posContext.Ventas.Include(v => v.DetalleVentas).ToListAsync();
        }

        public async Task<List<DetalleVenta>> GetDetallesByIdVenta(int idVenta)
        {
            var detallesVenta = await _posContext.DetallesVenta
                .Where(dv => dv.IdVenta == idVenta)
                .ToListAsync();
            if(detallesVenta.Count == 0)
            {
                throw new InvalidOperationException($"No se encontraron detalles de venta para el ID de venta: {idVenta}. Verificar que el ID es correcto.");
            }
            return detallesVenta;
        }
    }
}
