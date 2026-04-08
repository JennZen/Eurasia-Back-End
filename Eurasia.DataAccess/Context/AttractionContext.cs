using Eurasia.Domains.Entities.AttractionData;
using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Entities.Language;
using Eurasia.Domains.Entities.Relations;
using Eurasia.Domains.Enums.Eurasia;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

            modelBuilder.Ignore<CountryLanguage>();
            modelBuilder.Ignore<Language>();

            modelBuilder.Entity<CountryData>().ToTable("Countries", t => t.ExcludeFromMigrations());

            modelBuilder.Entity<AttractionData>()
                .HasOne(a => a.Country)
                .WithMany()
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CountryData>()
                .Property(e => e.Continents)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                          .Select(Enum.Parse<Continents>).ToList());

            modelBuilder.Entity<CountryData>()
                .Property(e => e.Regions)
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}