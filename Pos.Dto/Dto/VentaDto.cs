using Pos.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Dto.Dto
{
    public class VentaDto
    {
        public int IdVenta { get; set; }
        public string? Factura { get; set; }
        public DateOnly Fecha { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public int IdUsuario { get; set; }
        public EstadoVenta Estado { get; set; } = EstadoVenta.Activa;
        public DateOnly? FechaAnulada { get; set; }
        public string? Motivo { get; set; }
        public int? UsuarioAnula { get; set; }
        public virtual ICollection<DetalleVentaDto>? DetalleVentas { get; set; }
    }
}
