using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Dto.Dto
{
    public class NegocioDto
    {
        public int IdNegocio { get; set; }
        public string RUC { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Propietario { get; set; } = string.Empty;
        public decimal Descuento { get; set; }
    }
}
