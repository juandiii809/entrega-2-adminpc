using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentacion.interfaces
{
    public interface PagosPresentacion
    {
        Task<List<Pagos>> Listar();
        Task<List<Pagos>> PorTipo(Pagos? entidad);
        Task<Pagos?> Guardar(Pagos? entidad);
        Task<Pagos?> Modificar(Pagos? entidad);
        Task<Pagos?> Borrar(Pagos? entidad);
    }
}

