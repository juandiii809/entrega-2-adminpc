using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Implementaciones
{
    public class PuestosAplicacion : IPuestosAplicacion
    {
        private IConexion? IConexion = null;

        public PuestosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Puestos? Borrar(Puestos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Puestos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Puestos? Guardar(Puestos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            // Operaciones
            this.IConexion!.Puestos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Puestos> Listar()
        {
            return this.IConexion!.Puestos!.Take(20).ToList();
        }

        public Puestos? Modificar(Puestos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            var entry = this.IConexion!.Entry<Puestos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
