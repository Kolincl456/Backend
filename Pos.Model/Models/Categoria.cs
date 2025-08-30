using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model.Models
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }
        public string Descripcion {  get; set; } = string.Empty;
        public string Estado {  get; set; } = string.Empty;
        public DateTime FechaRegistro { get; private set; }
        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
