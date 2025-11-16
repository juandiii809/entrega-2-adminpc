using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentacion.interfaces
{
    public interface ProductosPresentacion
    {
        Task<List<Productos>> Listar();
        Task<List<Productos>> PorTipo(Productos? entidad);
        Task<Productos?> Guardar(Productos? entidad);
        Task<Productos?> Modificar(Productos? entidad);
        Task<Productos?> Borrar(Productos? entidad);
    }
}

