using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IServiciosAplicacion
    {
        void Configurar(string StringConexion);
        List<Servicios> Listar();
        Servicios? Guardar(Servicios? entidad);
        Servicios? Modificar(Servicios? entidad);
        Servicios? Borrar(Servicios? entidad);
    }
}
