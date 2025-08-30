using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }
        public string CodigoBarra { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        [ForeignKey(nameof(Categoria))]
        public int IdCategoria {  get; set; }
        public virtual Categoria? Categoria { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public string Estado { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
    }
}
