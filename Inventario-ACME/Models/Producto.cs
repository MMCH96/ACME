using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario_ACME.Models
{
    public class Producto
    {
        [Key]
        [Display(Name ="ID")]
        public int id { get; set; }

        [Required(ErrorMessage ="El nombre no puede estar vacio")]
        [StringLength(50,ErrorMessage ="El {0} debe ser al menos {2} y maximo {1} caracteres",MinimumLength = 5)]
        [Display(Name ="Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El codigo de barras no puede estar vacio")]
        [Display(Name = "Codigo de Barras")]
        public int codigo_barras { get; set; }

        [Required(ErrorMessage = "El precio no puede estar vacio")]
        [Display(Name = "Precio")]
        public float precio { get; set; }

        
    }
}
