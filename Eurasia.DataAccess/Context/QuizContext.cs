using Eurasia.Domains.Entities.Relations;
using Microsoft.EntityFrameworkCore;

namespace Eurasia.DataAccess.Context
{
    public class QuizContext : DbContext
    {
        public DbSet<EurasiaQuizResult> EurasiaQuizResults { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EurasiaQuizResult>()
                .HasOne(r => r.User)
                .WithOne(u => u.QuizRecord)
                .HasForeignKey<EurasiaQuizResult>(r => r.UserId);

            modelBuilder.Entity<EurasiaQuizResult>()
                .HasIndex(r => r.UserId)
                .IsUnique();
        }
    }
}

