using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentacion.interfaces
{
    public interface IComponentesPresentacion
    {
        Task<List<Componentes>> Listar();
        Task<List<Componentes>> PorNombre(Componentes? entidad);
        Task<Componentes?> Guardar(Componentes? entidad);
        Task<Componentes?> Modificar(Componentes? entidad);
        Task<Componentes?> Borrar(Componentes? entidad);
    }
}
