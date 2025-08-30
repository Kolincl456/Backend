using Pos.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Dto.Dto
{
    public class ProductoDto
    {
        public int IdProducto { get; set; }
        public string CodigoBarra { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public string CategoriaDescripcion { get; set; } = string.Empty;
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
