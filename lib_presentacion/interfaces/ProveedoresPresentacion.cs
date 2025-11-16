using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentacion.interfaces
{
    public interface IProveedoresPresentacion
    {
        Task<List<Proveedores>> Listar();
        Task<List<Proveedores>> PorTipo(Proveedores? entidad);
        Task<Proveedores?> Guardar(Proveedores? entidad);
        Task<Proveedores?> Modificar(Proveedores? entidad);
        Task<Proveedores?> Borrar(Proveedores? entidad);
    }
}

