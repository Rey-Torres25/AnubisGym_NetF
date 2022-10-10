using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymAnubisNetF.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage ="El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Edad { get; set; }
    }

    public class EditUserViewModel
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }

       
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Edad { get; set; }
    }
}