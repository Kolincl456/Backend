using Microsoft.VisualBasic;
using Pos.Model.Models;
using Pos.Repository.Interface;
using Pos.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Service
{
    public class Venta_Service : IVenta_Service
    {
        private readonly IVenta_Repository _ventaRepository;
    
        public Venta_Service(IVenta_Repository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public async Task<Venta?> AnularVenta(int idVenta, string motivo, int idUsuario)
        {
            return await _ventaRepository.AnularVenta(idVenta, motivo, idUsuario);
        }

        public async Task<List<Venta>> BuscarFecha(DateOnly FechaInicio, DateOnly FechaFin)
        {
            return await _ventaRepository.BuscarFecha(FechaInicio, FechaFin);
        }

        public async Task<Venta> Create(Venta Venta)
        {
            return await _ventaRepository.Create(Venta);
        }

        public async Task<List<Venta>> GetAll()
        {
            return await _ventaRepository.GetAll();
        }

        public async Task<List<DetalleVenta>> GetDetallesByIdVenta(int idVenta)
        {
            return await _ventaRepository.GetDetallesByIdVenta(idVenta);
        }
    }
}
