using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymAnubisNetF.Models.ViewModels
{
    public class VentaProdViewModel
    {
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public string Cantidad { get; set; }
        public string Fecha { get; set; }
        public string Precio { get; set; }
        public string Total { get; set; }
    }
}