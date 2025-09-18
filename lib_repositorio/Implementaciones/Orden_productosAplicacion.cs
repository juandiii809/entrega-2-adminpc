using lib_dominio.Entidades;
using lib_repositorio.Interfaces;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Implementaciones
{
    public class Orden_productosAplicacion : IOrden_productosAplicacion
    {
        private IConexion? IConexion = null;

        public Orden_productosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Orden_productos? Borrar(Orden_productos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Orden_productos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Orden_productos? Guardar(Orden_productos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            // Operaciones
            this.IConexion!.Orden_productos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Orden_productos> Listar()
        {
            return this.IConexion!.Orden_productos!.Take(20).ToList();
        }

        public Orden_productos? Modificar(Orden_productos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            var entry = this.IConexion!.Entry<Orden_productos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
