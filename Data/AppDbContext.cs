using SICPMonolithic.Models;
using Microsoft.EntityFrameworkCore;

namespace SICPMonolithic.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Enumerado> Enumerados { get; set; }
        public DbSet<BienPatrimonial> BienesPatrimoniales { get; set; }
        public DbSet<Procedimiento> Procedimientos { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Ajuste> Ajustes { get; set; }
        public DbSet<AjusteDetalle> AjusteDetalles { get; set; }
        public DbSet<ProcedimientoInventario> ProcedimientoBiens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Enumerado>()
                .HasMany(p => p.BienesPatrimoniales)
                .WithOne(p => p.Categoria!)
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder
                .Entity<BienPatrimonial>()
                .HasOne(p => p.Categoria)
                .WithMany(p => p.BienesPatrimoniales)
                .HasForeignKey(p => p.CategoriaId);
           




            //Procedimiento

            modelBuilder.Entity<Procedimiento>()
                .HasOne(r => r.ProcedimientoTipo)
                .WithMany(r => r.ProcedimientoTipos)
                .HasForeignKey(r => r.ProcedimientoTipoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
           
            modelBuilder.Entity<Procedimiento>()
               .HasOne(r => r.Causal)
               .WithMany(r=> r.Causals)
               .HasForeignKey(r => r.CausalId)
               .OnDelete(DeleteBehavior.ClientSetNull);                       
            //Areas
            modelBuilder.Entity<Area>()
               .HasOne(r => r.Sede)
               .WithMany(r => r.Sedes)
               .HasForeignKey(r => r.SedeId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Area>()
               .HasOne(r => r.Dependencia)
               .WithMany(r=> r.Dependencias)
               .HasForeignKey(r => r.DependenciaId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Area>()
              .HasOne(r => r.EstadoArea)
              .WithMany(r=> r.EstadoAreas)
              .HasForeignKey(r => r.EstadoAreaId)
              .OnDelete(DeleteBehavior.Restrict);

            //Inventario
            modelBuilder.Entity<Inventario>()
         .HasOne(r => r.AnexoTipo)
         .WithMany()
         .HasForeignKey(r => r.AnexoTipoId)
         .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inventario>()
               .HasOne(r => r.EstadoCondicion)
               .WithMany(r=> r.EstadoCondicions)
               .HasForeignKey(r => r.EstadoCondicionId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inventario>()
              .HasOne(r => r.EstadoBien)
              .WithMany(r => r.EstadoBiens)
              .HasForeignKey(r => r.EstadoBienId)
              .OnDelete(DeleteBehavior.Restrict);
          
            modelBuilder.Entity<Inventario>()
              .HasOne(r => r.Procedimiento)
              .WithMany(r => r.Inventarios)
              .HasForeignKey(r => r.ProcedimientoId)
              .OnDelete(DeleteBehavior.Restrict);

            //Ajustes
           

       
        }
    }
}
