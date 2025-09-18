using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Inventarios
    {
        [Key]public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int Piezas_Disponibles { get; set; }
        public int Producto { get; set; }
        [ForeignKey("Producto")]
        public Productos? _Producto { get; set; }
    }
}
