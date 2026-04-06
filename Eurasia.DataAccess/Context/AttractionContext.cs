using Eurasia.Domains.Entities.AttractionData;
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
    }
}