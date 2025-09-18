using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorio.Interfaces
{
    public interface IOrden_serviciosAplicacion
    {
        void Configurar(string StringConexion);
        List<Orden_servicios> Listar();
        Orden_servicios? Guardar(Orden_servicios? entidad);
        Orden_servicios? Modificar(Orden_servicios? entidad);
        Orden_servicios? Borrar(Orden_servicios? entidad);
    }
}
