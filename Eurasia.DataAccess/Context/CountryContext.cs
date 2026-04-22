using Eurasia.DataAccess;
using Eurasia.Domains.Entities.Country;
using Microsoft.EntityFrameworkCore;
public class CountryContext : DbContext
{
    public DbSet<CountryData> Countries { get; set; }
    public DbSet<Language> Language { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Continent> Continents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(DbSession.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CountryData>()
            .HasIndex(c => c.Name)
            .IsUnique();

        modelBuilder.Entity<Language>()
            .HasIndex(l => l.Name)
            .IsUnique();

        modelBuilder.Entity<Region>()
            .HasIndex(r => r.Name)
            .IsUnique();

        modelBuilder.Entity<Continent>()
            .HasIndex(c => c.Name)
            .IsUnique();

        modelBuilder.Entity<CountryData>()
            .HasMany(c => c.Languages)
            .WithMany(l => l.Countries)
            .UsingEntity(j => j.ToTable("CountryLanguages"));

        modelBuilder.Entity<CountryData>()
            .HasMany(c => c.Regions)
            .WithMany(r => r.Countries)
            .UsingEntity(j => j.ToTable("CountryRegions"));

        modelBuilder.Entity<CountryData>()
            .HasMany(c => c.Continents)
            .WithMany(cn => cn.Countries)
            .UsingEntity(j => j.ToTable("CountryContinents"));
    }
}