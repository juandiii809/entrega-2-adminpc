using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Computadores
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Modelo { get; set; }
        public decimal Precio { get; set; }
        public int Marca { get; set; }
        [ForeignKey("Marca")]
        public Marcas? _marca { get; set; }
        public int Componente { get; set; }
        [ForeignKey("Componente")]
        public Componentes? _componente { get; set; }
    }
}
