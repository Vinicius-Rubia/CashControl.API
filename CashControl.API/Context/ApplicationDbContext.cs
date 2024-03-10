using CashControl.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CashControl.API.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BankStatementModel> BankStatements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankStatementModel>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.Property(bs => bs.Amount).HasColumnType("decimal(18, 2)");
                entity.Property(bs => bs.Created_At).HasDefaultValueSql("GETDATE()");
                entity.Property(bs => bs.Updated_At).HasDefaultValueSql("GETDATE()");
               
            });
        }
    }
}
