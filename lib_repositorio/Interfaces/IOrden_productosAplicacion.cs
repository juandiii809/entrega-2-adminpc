using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorio.Interfaces
{
    public interface IOrden_productosAplicacion
    {
        void Configurar(string StringConexion);
        List<Orden_productos> Listar();
        Orden_productos? Guardar(Orden_productos? entidad);
        Orden_productos? Modificar(Orden_productos? entidad);
        Orden_productos? Borrar(Orden_productos? entidad);
    }
}
