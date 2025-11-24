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
    public class ClientesAplicacion : IClientesAplicacion
    {
        private IConexion? IConexion = null;

        public ClientesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Clientes? Borrar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Auditorias!.Add(new Auditorias
            {
                Fecha = DateTime.Now,
                Descripcion = $"Se elimino el cliente {entidad.Nombre}"
            });
            this.IConexion!.Clientes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Clientes? Guardar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            // Operaciones
            this.IConexion!.Auditorias!.Add(new Auditorias
            {
                Fecha = DateTime.Now,
                Descripcion = $"Se creó el cliente {entidad.Nombre}"
            });
            this.IConexion!.Clientes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

            
        }

        public List<Clientes> Listar()
        {
            return this.IConexion!.Clientes!.Take(20).ToList();
        }

        public Clientes? Modificar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones

            this.IConexion!.Auditorias!.Add(new Auditorias
            {
                Fecha = DateTime.Now,
                Descripcion = $"Se modifico el cliente {entidad.Nombre}"
            });
            var entry = this.IConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Clientes> PorNombre(Clientes? entidad)
        {
            return this.IConexion!.Clientes!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .Take(50)
                .ToList();
        }
    }
}
