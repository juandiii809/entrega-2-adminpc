using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentacion.interfaces
{
    public interface PuestosPresentacion
    {
        Task<List<Puestos>> Listar();
        Task<List<Puestos>> PorTipo(Puestos? entidad);
        Task<Puestos?> Guardar(Puestos? entidad);
        Task<Puestos?> Modificar(Puestos? entidad);
        Task<Puestos?> Borrar(Puestos? entidad);
    }
}
