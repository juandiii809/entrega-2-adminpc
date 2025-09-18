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

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class FacturasPrueba
    {
        private readonly IConexion? iConexion;
        private List<Facturas>? lista;
        private Facturas? entidad;

        public FacturasPrueba()
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
            this.lista = this.iConexion!.Facturas!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Facturas()!;

            this.iConexion!.Facturas!.Add(this.entidad);
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Descripcion = "Test";

            var entry = this.iConexion!.Entry<Facturas>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Facturas!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }

}
