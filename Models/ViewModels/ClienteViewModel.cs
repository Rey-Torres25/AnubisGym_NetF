using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymAnubisNetF.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }


        public string FechaRegistro { get; set; }
    }

    public class EditClienteViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

    }
}