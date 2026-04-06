using Eurasia.DataAccess;
using Eurasia.Domains.Entities.News;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Eurasia.DataAccess.Context
{
    public class NewsContext : DbContext
    {
        public DbSet<NewsData> News { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionString);
        }
    }
}