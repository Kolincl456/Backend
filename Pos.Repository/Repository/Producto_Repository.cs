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
    public class Producto_Repository : IRepository<Producto>
    {
        private readonly PosContext _posContext;
        public Producto_Repository(PosContext posContext)
        {
            _posContext = posContext;
        }

        public async Task<Producto> Create(Producto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _posContext.Productos.Add(entity);
            await _posContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var Producto = await _posContext.Productos.FindAsync(id);
            if (Producto == null)
            {
                return false;
            }
            _posContext.Productos.Remove(Producto);
            await _posContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Producto>> GetAll()
        {
            return await _posContext.Productos.ToListAsync();
        }

        public async Task<Producto?> GetById(int id)
        {
            return await _posContext.Productos.FindAsync(id);
        }

        public async Task<Producto> Update(Producto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var ProductoExistente = await _posContext.Productos.FirstOrDefaultAsync(p => p.IdProducto == entity.IdProducto);
            if (ProductoExistente == null)
            {
                throw new KeyNotFoundException($"No se encontró el Producto con el ID: {entity.IdProducto}");
            }

            ProductoExistente.CodigoBarra = entity.CodigoBarra;
            ProductoExistente.Descripcion = entity.Descripcion;
            ProductoExistente.IdCategoria = entity.IdCategoria;
            ProductoExistente.Estado = entity.Estado;

            _posContext.Productos.Update(ProductoExistente);
            await _posContext.SaveChangesAsync();
            return ProductoExistente;

        }
    }
}
