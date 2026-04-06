using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Entities.Language;
using Eurasia.Domains.Entities.Relations;
using Eurasia.Domains.Enums.Eurasia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eurasia.DataAccess.Context
{
    public class CountryContext : DbContext
    {
        public DbSet<CountryData> Countries { get; set; }
        public DbSet<CountryLanguage> CountryLanguages { get; set; }
        public DbSet<Language> Languages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>()
                .ToTable("Languages");

            modelBuilder.Entity<CountryLanguage>()
                .HasKey(cl => new { cl.CountryId, cl.LanguageId });

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
