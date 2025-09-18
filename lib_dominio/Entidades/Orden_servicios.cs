using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Orden_servicios
    {
        [Key]public int Id { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
        public int Servicio { get; set; }
        public int Cliente { get; set; }
        public int Empleado { get; set; }
        
        [ForeignKey("Servicio")] public Servicios? _Servicio { get; set; }
        [ForeignKey("Cliente")] public Clientes? _cliente { get; set; }
        [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
    }
}
