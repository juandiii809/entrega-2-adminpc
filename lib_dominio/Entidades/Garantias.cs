using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class garantias
    {
       public int Id { get; set; }
       public DateTime fecha_inicio { get; set; } 
       public DateTime fecha_fin { get; set; }
    }
}
