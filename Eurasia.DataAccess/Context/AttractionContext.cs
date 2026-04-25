using Eurasia.Domains.Entities.AttractionData;
using Microsoft.EntityFrameworkCore;

namespace Eurasia.DataAccess.Context
{
    public class AttractionContext : DbContext
    {
        public DbSet<AttractionData> Attractions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Continent>();
            modelBuilder.Ignore<Region>();
            modelBuilder.Ignore<Language>();

            modelBuilder.Entity<CountryData>(b =>
            {
                b.Ignore(c => c.Continents);
                b.Ignore(c => c.Regions);
                b.Ignore(c => c.Languages);
                b.ToTable("Countries", t => t.ExcludeFromMigrations());
            });

            modelBuilder.Entity<AttractionData>()
                .HasOne(a => a.Country)
                .WithMany()
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}