using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymAnubisNetF.Models.ViewModels
{
    public class ProductoViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre Producto")]
        public string NombreProd { get; set; }

        [Required]
        [Display(Name = "Cantidad de producto")]
        public int Stock { get; set; }

        [Required]
        [Display(Name = "Precio de producto")]
        public int Precio { get; set; }
        public string FechaRegistro { get; set; }
    }

    public class EditProductoViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre Producto")]
        public string NombreProd { get; set; }

        [Required]
        [Display(Name = "Cantidad de producto")]
        public int Stock { get; set; }

        [Required]
        [Display(Name = "Precio de producto")]
        public int Precio { get; set; }
        public string FechaRegistro { get; set; }
    }
}