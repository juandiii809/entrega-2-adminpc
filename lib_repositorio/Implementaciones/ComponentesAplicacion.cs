using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorio.Implementaciones
{
    public class ComponentesAplicacion : IComponentesAplicacion
    {
        private IConexion? IConexion = null;

        public ComponentesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Componentes? Borrar(Componentes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Componentes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Componentes? Guardar(Componentes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            // Operaciones
            this.IConexion!.Componentes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Componentes> Listar()
        {
            return this.IConexion!.Componentes!.Take(20).ToList();
        }

        public Componentes? Modificar(Componentes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            var entry = this.IConexion!.Entry<Componentes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
