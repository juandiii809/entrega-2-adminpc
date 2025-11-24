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
    public class PagosAplicacion: IPagosAplicacion
    {
        private IConexion? IConexion = null;

        public PagosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Pagos? Borrar(Pagos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Auditorias!.Add(new Auditorias
            {
                Fecha = DateTime.Now,
                Descripcion = $"Se elimino el pago {entidad.Id}"
            });
            this.IConexion!.Pagos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Pagos? Guardar(Pagos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            // Operaciones
            this.IConexion!.Auditorias!.Add(new Auditorias
            {
                Fecha = DateTime.Now,
                Descripcion = $"Se creó el pago {entidad.Id}"
            });
            this.IConexion!.Pagos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Pagos> Listar()
        {
            return this.IConexion!.Pagos!.Take(20).ToList();
        }

        public Pagos? Modificar(Pagos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Auditorias!.Add(new Auditorias
            {
                Fecha = DateTime.Now,
                Descripcion = $"Se modifico el pago {entidad.Id}"
            });
            var entry = this.IConexion!.Entry<Pagos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Pagos> PorTipo(Pagos? entidad)
        {
            return this.IConexion!.Pagos!
                .Where(x => x.Tipo_pago!.Contains(entidad!.Tipo_pago!))
                .Take(50)
                .ToList();
        }
    }
}
