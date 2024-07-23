namespace CotizacionAPI.Infraestructura.Persistencia;

using Microsoft.EntityFrameworkCore;
using CotizacionAPI.Dominio.Entidades;

public class DataBaseContext : DbContext
{

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public DataBaseContext(DbContextOptions options) : base(options)
    {        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().ToTable("Usuarios");
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(x => x.Id);
        });

        base.OnModelCreating(modelBuilder);
    }
}
