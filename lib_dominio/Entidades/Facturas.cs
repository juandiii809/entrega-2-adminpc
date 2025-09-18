using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Facturas
    {
        [Key] public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Descripcion { get; set; }
        public decimal Valor_total { get; set; }
        public int Pago { get; set; }
        [ForeignKey("Pago")]
        public int Garantia { get; set; }
        [ForeignKey("Garantia")]
        public int Orden { get; set; }
        [ForeignKey("Orden")]
        public Pagos? _Pago { get; set; }
        public Garantias? _Garantia { get; set; }
        public Orden_servicios? Orden_servicios { get; set; }
    }
}
