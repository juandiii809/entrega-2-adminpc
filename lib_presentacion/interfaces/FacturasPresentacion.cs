using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentacion.interfaces
{
    public interface IFacturasPresentacion
    {
        Task<List<Facturas>> Listar();
        Task<List<Facturas>> PorDescripcion(Facturas? entidad);
        Task<Facturas?> Guardar(Facturas? entidad);
        Task<Facturas?> Modificar(Facturas? entidad);
        Task<Facturas?> Borrar(Facturas? entidad);
    }
}
