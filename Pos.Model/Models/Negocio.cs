using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model.Models
{
    public class Negocio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNegocio { get; set; }
        public string RUC { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono {  get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Propietario { get; set; } = string.Empty;
        public decimal Descuento {  get; set; }
        public DateTime FechaRegistro { get; private set; } 
    }
}
