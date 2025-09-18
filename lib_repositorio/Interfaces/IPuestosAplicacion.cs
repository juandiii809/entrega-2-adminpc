using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IPuestosAplicacion
    {
        void Configurar(string StringConexion);
        List<Puestos> Listar();
        Puestos? Guardar(Puestos? entidad);
        Puestos? Modificar(Puestos? entidad);
        Puestos? Borrar(Puestos? entidad);
    }
}
