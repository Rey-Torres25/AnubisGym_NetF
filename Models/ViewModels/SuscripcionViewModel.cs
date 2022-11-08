using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymAnubisNetF.Models.ViewModels
{
    public class SuscripcionViewModel
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
        public int PagoMensual { get; set; }
    }
}