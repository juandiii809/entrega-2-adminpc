using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentacion.interfaces
{
    public interface IInventariosPresentacion
    {
        Task<List<Inventarios>> Listar();
        Task<List<Inventarios>> PorDescripcion(Inventarios? entidad);
        Task<Inventarios?> Guardar(Inventarios? entidad);
        Task<Inventarios?> Modificar(Inventarios? entidad);
        Task<Inventarios?> Borrar(Inventarios? entidad);
    }
}
