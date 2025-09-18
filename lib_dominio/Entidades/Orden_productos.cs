using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Orden_productos
    {
        [Key]public int Id { get; set; }
        public int Cantidad { get; set; }
        public int Producto { get; set; }
        [ForeignKey("Producto")]
        public int Orden { get; set; }
        [ForeignKey("Orden")]
        public Productos? _Producto { get; set; }
        public Orden_servicios? _Orden_servicios { get; set; }
    }
}
