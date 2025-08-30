using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model.Models
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVenta { get; set; }
        public string? Factura { get; set; }
        public DateOnly Fecha { get; set; }
        public string Dni {  get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public EstadoVenta Estado { get; set; } = EstadoVenta.Activa;
        public DateOnly? FechaAnulada { get; set; }
        public string? Motivo { get; set; }
        public int? UsuarioAnula {  get; set; }
        public virtual ICollection<DetalleVenta>? DetalleVentas { get; set; }
    }

    public enum EstadoVenta
    {
        Activa =  1,
        Anulada = 0
    }
}
