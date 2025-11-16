using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentacion.interfaces
{
    public interface IGarantiasPresentacion
    {
        Task<List<Garantias>> Listar();
        Task<List<Garantias>> PorTipo(Garantias? entidad);
        Task<Garantias?> Guardar(Garantias? entidad);
        Task<Garantias?> Modificar(Garantias? entidad);
        Task<Garantias?> Borrar(Garantias? entidad);
    }
}
