using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Garantias
    {
        [Key] public int Id { get; set; }
        public string? Fecha_inicio { get; set; }
        public string? Fecha_fin { get; set; }
    }
}
