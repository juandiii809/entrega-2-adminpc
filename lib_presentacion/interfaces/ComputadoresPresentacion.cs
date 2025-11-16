using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentacion.interfaces
{
    public interface ComputadoresPresentacion
    {
        Task<List<Computadores>> Listar();
        Task<List<Computadores>> PorTipo(Computadores? entidad);
        Task<Computadores?> Guardar(Computadores? entidad);
        Task<Computadores?> Modificar(Computadores? entidad);
        Task<Computadores?> Borrar(Computadores? entidad);
    }
}
