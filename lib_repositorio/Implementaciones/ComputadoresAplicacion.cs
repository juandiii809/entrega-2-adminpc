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
    public class ComputadoresAplicacion : IComputadoresAplicacion
    {
        private IConexion? IConexion = null;

        public ComputadoresAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Computadores? Borrar(Computadores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Auditorias!.Add(new Auditorias
            {
                Fecha = DateTime.Now,
                Descripcion = $"Se elimino el computador {entidad.Nombre}"
            });
            this.IConexion!.Computadores!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Computadores? Guardar(Computadores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            // Operaciones
            this.IConexion!.Auditorias!.Add(new Auditorias
            {
                Fecha = DateTime.Now,
                Descripcion = $"Se creó el computador {entidad.Nombre}"
            });
            this.IConexion!.Computadores!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Computadores> Listar()
        {
            return this.IConexion!.Computadores!.Take(20).ToList();
        }

        public Computadores? Modificar(Computadores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Auditorias!.Add(new Auditorias
            {
                Fecha = DateTime.Now,
                Descripcion = $"Se modifico el computador {entidad.Nombre}"
            });
            var entry = this.IConexion!.Entry<Computadores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Computadores> PorNombre(Computadores? entidad)
        {
            return this.IConexion!.Computadores!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .Take(50)
                .ToList();
        }
    }
}
