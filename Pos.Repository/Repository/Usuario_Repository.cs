using Microsoft.AspNetCore.Identity;
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
    public class Usuario_Repository : IUsuario_Repository
    {
        private readonly PosContext _posContext;
        private readonly UserManager <Usuario> _usuarioManager;
        
        public Usuario_Repository(PosContext posContext, UserManager<Usuario> usuarioManager)
        {
            _posContext = posContext;
            _usuarioManager = usuarioManager;
        }

        public async Task<Usuario> Create(Usuario entity, string pass)
        {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            entity.UserName = entity.Email;
            var result = await _usuarioManager.CreateAsync(entity, pass);
            if (!result.Succeeded) {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var usuario = await _posContext.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            _posContext.Usuarios.Remove(usuario);
            await _posContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await _posContext.Usuarios.Include(u => u.Rol).ToListAsync();
        }

        public async Task<Usuario?> GetByEmail(string email)
        {
            return await _posContext.Usuarios.Include(u => u.Rol).FirstOrDefaultAsync(u => u.Email == email);    
        }

        public async Task<Usuario?> GetById(int id)
        {
            return await _posContext.Usuarios.Include(u => u.Rol).FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task<string> GetRolById(int id)
        {
            var usuario = await _posContext.Usuarios.Include(u => u.Rol).FirstOrDefaultAsync(u => u.IdUsuario == id);
            return usuario?.Rol?.Descripcion ?? string.Empty;
        }

        public async Task<Usuario> Update(Usuario entity, string pass)
        {
            var usuarioExistente = await _posContext.Usuarios.Include(u => u.Rol).FirstOrDefaultAsync(u => u.IdUsuario == entity.IdUsuario);
            if (usuarioExistente == null) {
                throw new KeyNotFoundException($"No se encontró el usuario con el ID: { entity.IdUsuario }.");
            }
            usuarioExistente.Nombres = entity.Nombres;
            usuarioExistente.Apellidos = entity.Apellidos;
            usuarioExistente.IdRol = entity.IdRol;
            usuarioExistente.Telefono = entity.Telefono;
            usuarioExistente.UserName = entity.UserName;
            if (!string.IsNullOrEmpty(pass)) {
                var PasswordHasher = new PasswordHasher<Usuario>();
                usuarioExistente.PasswordHash = PasswordHasher.HashPassword(usuarioExistente, pass);
            }
            usuarioExistente.Estado = entity.Estado;

            _posContext.Usuarios.Update(usuarioExistente);
            await _posContext.SaveChangesAsync();
            return usuarioExistente;
        }
    }
}
