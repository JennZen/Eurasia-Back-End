using Eurasia.Domains.Entities.User;
using Eurasia.Domains.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.DataAccess.Context
{
    public class UserContext : DbContext
    {
        public DbSet<UserData> Users { get; set; }
        public DbSet<UserFavoriteCountry> UserFavoriteCountries { get; set; }
        public DbSet<UserFavoriteAttraction> UserFavoriteAttractions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFavoriteCountry>()
                .HasKey(x => new { x.UserId, x.CountryId });

            modelBuilder.Entity<UserFavoriteAttraction>()
                .HasKey(x => new { x.UserId, x.AttractionId });
        }
    }
}
