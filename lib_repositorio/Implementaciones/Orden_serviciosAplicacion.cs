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
    public class Orden_serviciosAplicacion : IOrden_serviciosAplicacion
    {
        private IConexion? IConexion = null;

        public Orden_serviciosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Orden_servicios? Borrar(Orden_servicios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Orden_servicios!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Orden_servicios? Guardar(Orden_servicios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            // Operaciones
            this.IConexion!.Orden_servicios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Orden_servicios> Listar()
        {
            return this.IConexion!.Orden_servicios!.Take(20).ToList();
        }

        public Orden_servicios? Modificar(Orden_servicios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            var entry = this.IConexion!.Entry<Orden_servicios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
