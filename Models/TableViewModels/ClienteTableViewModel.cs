using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymAnubisNetF.Models.TableViewModels
{
    public class ClienteTableViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string FechaRegistro { get; set; }

        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int PagoMensual { get; set; }
    }
}