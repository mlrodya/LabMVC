using Microsoft.EntityFrameworkCore;
using CyfrowaBiblioteka.Models;

namespace CyfrowaBiblioteka.Data;

public class BibliotekaContext : DbContext
{
    public BibliotekaContext(DbContextOptions<BibliotekaContext> options)
        : base(options)
    {
    }

    public DbSet<Autor> Autor { get; set; } = default!;
    public DbSet<Ksiazka> Ksiazka { get; set; } = default!;
    public DbSet<Wypozyczenie> Wypozyczenie { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define relationships to ensure clean database structure
        modelBuilder.Entity<Ksiazka>()
            .HasOne(k => k.Autor)
            .WithMany(a => a.Ksiazki)
            .HasForeignKey(k => k.AutorId);

        modelBuilder.Entity<Wypozyczenie>()
            .HasOne(w => w.Ksiazka)
            .WithMany(k => k.Wypozyczenia)
            .HasForeignKey(w => w.KsiazkaId);
    }
}