//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymAnubisNetF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            this.asistencia = new HashSet<asistencia>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string fecha_registro { get; set; }
        public int idStatus { get; set; }
        public Nullable<int> idCompra { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<asistencia> asistencia { get; set; }
        public virtual status status { get; set; }
        public virtual venta_prod venta_prod { get; set; }
    }
}
