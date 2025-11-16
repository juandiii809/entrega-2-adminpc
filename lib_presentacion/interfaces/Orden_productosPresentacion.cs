using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentacion.interfaces
{
    public interface IOrden_productosPresentacion
    {
        Task<List<Orden_productos>> Listar();
        Task<List<Orden_productos>> PorTipo(Orden_productos? entidad);
        Task<Orden_productos?> Guardar(Orden_productos? entidad);
        Task<Orden_productos?> Modificar(Orden_productos? entidad);
        Task<Orden_productos?> Borrar(Orden_productos? entidad);
    }
}
