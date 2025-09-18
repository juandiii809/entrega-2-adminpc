using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IComponentesAplicacion
    {
        void Configurar(string StringConexion);
        List<Componentes> Listar();
        Componentes? Guardar(Componentes? entidad);
        Componentes? Modificar(Componentes? entidad);
        Componentes? Borrar(Componentes? entidad);
    }
}
