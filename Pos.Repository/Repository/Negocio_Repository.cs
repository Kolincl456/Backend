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
    public class Negocio_Repository : INegocio_Repository
    {
        private readonly PosContext _posContext;

        public Negocio_Repository(PosContext posContext) { 
            _posContext = posContext;
        }

        public async Task<Negocio> Create(Negocio negocio)
        {
            if(negocio == null)
            {
                throw new ArgumentNullException(nameof(negocio));
            }

            _posContext.Negocios.Add(negocio);
            await _posContext.SaveChangesAsync();
            return negocio;
        }

        public async Task<Negocio?> Get()
        {
            return await _posContext.Negocios.FirstOrDefaultAsync();
        }

        public async Task<Negocio> Update(Negocio negocio)
        {
            var negocioExistente = await _posContext.Negocios.FirstOrDefaultAsync(n => n.IdNegocio == negocio.IdNegocio);
            
            if(negocioExistente == null)
            {
                throw new KeyNotFoundException($"No se encontró el registro con el ID: { negocio.IdNegocio }.");
            }

            negocioExistente.RUC = negocio.RUC;
            negocioExistente.RazonSocial = negocio.RazonSocial;
            negocioExistente.Email = negocio.Email;
            negocioExistente.Telefono = negocio.Telefono;
            negocioExistente.Direccion = negocio.Direccion;
            negocioExistente.Propietario = negocio.Propietario;
            negocioExistente.Descuento = negocio.Descuento;

            _posContext.Negocios.Update(negocioExistente);
            await _posContext.SaveChangesAsync();
            return negocioExistente;
            
        }
    }
}
