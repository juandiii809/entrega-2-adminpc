using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class ServiciosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Servicios>? lista;
        private Servicios? entidad;

        public ServiciosPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.Servicios!.ToList();
            return lista.Count > 0;
        }

        public decimal descuento()
        {
            if (this.entidad!.Precio > 1000)
            {
                return this.entidad.Precio * 0.6m;
            }
            return this.entidad.Precio;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Servicios()!;

            this.iConexion!.Servicios!.Add(this.entidad);
            this.iConexion!.SaveChanges();

            var precioFinal = descuento();

            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Nombre = "Test";

            var entry = this.iConexion!.Entry<Servicios>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Servicios!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
