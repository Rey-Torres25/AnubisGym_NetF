using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymAnubisNetF.Models.TableViewModels
{
    public class AsistenciaTableViewModel
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }

    }
}