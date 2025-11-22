using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentacion.interfaces
{
    public interface IComputadoresPresentacion
    {
        Task<List<Computadores>> Listar();
        Task<List<Computadores>> PorNombre(Computadores? entidad);
        Task<Computadores?> Guardar(Computadores? entidad);
        Task<Computadores?> Modificar(Computadores? entidad);
        Task<Computadores?> Borrar(Computadores? entidad);
    }
}
