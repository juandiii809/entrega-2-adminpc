using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IFacturasAplicacion
    {
        void Configurar(string StringConexion);
        List<Facturas> Listar();
        Facturas? Guardar(Facturas? entidad);
        Facturas? Modificar(Facturas? entidad);
        Facturas? Borrar(Facturas? entidad);
    }
}
