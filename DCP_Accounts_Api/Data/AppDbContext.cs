using DCP_Accounts_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DCP_Accounts_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Expend> Expends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expend>(entity =>
            {
                entity.ToTable("tblExpend");
                entity.HasKey(e => e.ExpenditurID);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
