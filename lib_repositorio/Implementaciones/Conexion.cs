using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Componentes>? Componentes { get; set; }
        public DbSet<Marcas>? Marcas { get; set; }
        public DbSet<Servicios>? Servicios { get; set; }
        public DbSet<garantias>? Garantias { get; set; }
        public DbSet<Puestos>? Puestos { get; set; }
    }
}