using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Componentes>? Componentes { get; set; }
        DbSet<Marcas>? Marcas { get; set; }
        DbSet<Servicios>? Servicios { get; set; }
        DbSet<garantias>? Garantias { get; set; }
        DbSet<Puestos>? Puestos { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}