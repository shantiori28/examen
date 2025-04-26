using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Data

    public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categoria { get; set; }
    public DbSet<Productos> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aquí puedes configurar relaciones, restricciones, etc.
        modelBuilder.Entity<Productos>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Productos)
            .HasForeignKey(p => p.CategoriaId)
            .OnDelete(DeleteBehavior.Cascade); // Ejemplo: Si se elimina una categoría, se eliminan sus productos.
    }
}

