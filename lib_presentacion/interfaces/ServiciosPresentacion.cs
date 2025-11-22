using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentacion.interfaces
{
    public interface IServiciosPresentacion
    {
        Task<List<Servicios>> Listar();
        Task<List<Servicios>> PorNombre(Servicios? entidad);
        Task<Servicios?> Guardar(Servicios? entidad);
        Task<Servicios?> Modificar(Servicios? entidad);
        Task<Servicios?> Borrar(Servicios? entidad);
    }

}
