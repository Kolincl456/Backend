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
    public class Categoria_Repository : IRepository<Categoria>
    {
        private readonly PosContext _posContext;

        public Categoria_Repository(PosContext posContext)
        {
            _posContext = posContext;
        }

        public async Task<Categoria> Create(Categoria entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _posContext.Categorias.Add(entity);
            await _posContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var Categoria = await _posContext.Categorias.FindAsync(id);
            if (Categoria == null)
            {
                return false;
            }
            _posContext.Categorias.Remove(Categoria);
            await _posContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Categoria>> GetAll()
        {
            return await _posContext.Categorias.ToListAsync();
        }

        public async Task<Categoria?> GetById(int id)
        {
            return await _posContext.Categorias.FindAsync(id);
        }

        public async Task<Categoria> Update(Categoria entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var CategoriaExistente = await _posContext.Categorias.FirstOrDefaultAsync(c => c.IdCategoria == entity.IdCategoria);
            if (CategoriaExistente == null)
            {
                throw new KeyNotFoundException($"No se encontró el Categoria con el ID: {entity.IdCategoria}");
            }

            CategoriaExistente.Descripcion = entity.Descripcion;
            CategoriaExistente.Estado = entity.Estado;

            _posContext.Categorias.Update(CategoriaExistente);
            await _posContext.SaveChangesAsync();
            return CategoriaExistente;

        }
    }
}
