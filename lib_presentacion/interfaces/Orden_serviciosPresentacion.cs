using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentacion.interfaces
{
    public interface Orden_Orden_serviciosPresentacion
    {
        Task<List<Orden_servicios>> Listar();
        Task<List<Orden_servicios>> PorTipo(Orden_servicios? entidad);
        Task<Orden_servicios?> Guardar(Orden_servicios? entidad);
        Task<Orden_servicios?> Modificar(Orden_servicios? entidad);
        Task<Orden_servicios?> Borrar(Orden_servicios? entidad);
    }
}
