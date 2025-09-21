﻿using Pos.Model.Models;
using Pos.Repository.Interface;
using Pos.Repository.Repository;
using Pos.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Service
{
    public class Negocio_Service : INegocio_Service
    {
        private readonly INegocio_Repository _negocioRepository;

        public Negocio_Service(INegocio_Repository negocioRepository)
        {
            _negocioRepository = negocioRepository;
        }

        public async Task<Negocio?> Get()
        {
            var entidad = await _negocioRepository.Get();
            if (entidad == null)
            {
                return null;
            }
            return entidad;
        }

        public async Task<Negocio?> Save(Negocio negocio)
        {
            var entidadExistente = await _negocioRepository.Get();
            if (entidadExistente == null)
            {
                var entidadCreada = await _negocioRepository.Create(negocio);
                return entidadCreada;
            }
            else
            {
                negocio.IdNegocio = entidadExistente.IdNegocio;
                var entidadActualizada = await _negocioRepository.Update(negocio);
                return entidadActualizada;
            }
        }
    }
}
