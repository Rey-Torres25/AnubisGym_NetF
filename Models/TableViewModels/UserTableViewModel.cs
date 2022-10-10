using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymAnubisNetF.Models.TableViewModels
{
    //ViewModels para mostrar algunos datos de las tablas por ejemplo para las Vistas
    public class UserTableViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string NombreUsuario { get; set; }
        public int Edad { get; set; }


    }
}