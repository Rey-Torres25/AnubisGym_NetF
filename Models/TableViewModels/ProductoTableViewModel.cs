using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymAnubisNetF.Models.TableViewModels
{
    public class ProductoTableViewModel
    {
        public int Id { get; set; }
        public string NombreProd { get; set; }
        public int Stock { get; set; }
        public int Precio { get; set; }

        public string FechaRegistro { get; set; }
    }
}