using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IGarantiasAplicacion
    {
        void Configurar(string StringConexion);
        List<Garantias> Listar();
        Garantias? Guardar(Garantias? entidad);
        Garantias? Modificar(Garantias? entidad);
        Garantias? Borrar(Garantias? entidad);
    }
}
