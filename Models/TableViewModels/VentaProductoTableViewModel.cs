using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymAnubisNetF.Models.TableViewModels
{
    public class VentaProductoTableViewModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public string Cantidad { get; set; }
        public string Precio { get; set; }
        public string FechaCompra { get; set; }
        public string Total { get; set; }
    }
}