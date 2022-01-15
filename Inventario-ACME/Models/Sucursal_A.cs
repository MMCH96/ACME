using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario_ACME.Models
{
    public class Sucursal_A
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("Producto")]
        [Required(ErrorMessage = "El id del producto no puede estar vacio")]
        [Display(Name ="Id del Producto")]
        public int product_id { get; set; }

        [Required(ErrorMessage = "La cantidad no puede estar vacia")]
        [Display(Name = "Cantidad")]
        public float cantidad { get; set; }

        [ForeignKey("product_id")]
        public virtual Producto Producto { get; set; }
    }
}
