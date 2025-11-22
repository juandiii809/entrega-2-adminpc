using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentacion.interfaces
{
    public interface IEmpleadosPresentacion
    {
        Task<List<Empleados>> Listar();
        Task<List<Empleados>> PorNombre(Empleados? entidad);
        Task<Empleados?> Guardar(Empleados? entidad);
        Task<Empleados?> Modificar(Empleados? entidad);
        Task<Empleados?> Borrar(Empleados? entidad);
    }
}
