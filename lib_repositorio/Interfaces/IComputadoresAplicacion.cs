using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IComputadoresAplicacion
    {
        void Configurar(string StringConexion);
        List<Computadores> Listar();
        Computadores? Guardar(Computadores? entidad);  
        Computadores? Modificar(Computadores? entidad);
        Computadores? Borrar(Computadores? entidad);
    }
}
