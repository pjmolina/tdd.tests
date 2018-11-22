using Microsoft.EntityFrameworkCore;
using Unir.Aggregates.Asignaturas;
using Unir.Aggregates.Estudios;
using Unir.Aggregates.Planes;

namespace Unir.Repositories.Impl.Context
{
    public class PlanesDbContext : DbContext
    {
        public PlanesDbContext(DbContextOptions<PlanesDbContext> options)
            : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plan>(e => { e.HasKey(d => d.Id); });
            modelBuilder.Entity<Asignatura>(e => { 
                e.HasKey(d => d.Id);
                e.HasData(
                    new Asignatura { Id = 1, Nombre = "Análisis Matemático", Optativa = false },
                    new Asignatura { Id = 2, Nombre = "BI", Optativa = true },
                    new Asignatura { Id = 3, Nombre = "Matemática Numérica", Optativa = false });

            });
            modelBuilder.Entity<Estudio>(e => { 
                e.HasKey(d => d.Id); 
                e.HasData(new Estudio { Id = 1, Nombre = "Matemática", AprobadoAneca = true }); 
            });
            modelBuilder.Entity<TraduccionEstudio>(e => { 
                e.HasKey(d => d.Id);
                e.Property(d => d.Id).ValueGeneratedOnAdd();
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }

}