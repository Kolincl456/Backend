using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model.Models
{
    public class DetalleVenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetalleVenta { get; set; }
        [ForeignKey(nameof(Venta))]
        public int IdVenta { get; set; }
        public virtual Venta? Venta { get; set; }

        [ForeignKey(nameof(Producto))]
        public int IdProducto {  get; set; }
        public virtual Producto? Producto { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

    }
}
