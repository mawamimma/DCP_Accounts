using DCP_Accounts_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DCP_Accounts_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets for all your tables
        public DbSet<Expend> Expends { get; set; }
        public DbSet<ExpendHead> ExpendHeads { get; set; }
        public DbSet<ExpBub> ExpBubs { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeHead> IncomeHeads { get; set; }
        public DbSet<IncSub> IncSubs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Expend
            modelBuilder.Entity<Expend>(entity =>
            {
                entity.ToTable("tblExpend");
                entity.HasKey(e => e.ExpenditurID);
            });

            // ExpendHead
            modelBuilder.Entity<ExpendHead>(entity =>
            {
                entity.ToTable("tblExpendHead");
                entity.HasKey(e => e.ExpendHeadID);
            });

            // ExpBub
            modelBuilder.Entity<ExpBub>(entity =>
            {
                entity.ToTable("tblExpBub");
                entity.HasKey(e => e.ExpSubCode);
            });

            // Income
            modelBuilder.Entity<Income>(entity =>
            {
                entity.ToTable("tblIncome");
                entity.HasKey(e => e.ExpenditurID); // Or IncomeID if your DB uses it
            });

            // IncomeHead
            modelBuilder.Entity<IncomeHead>(entity =>
            {
                entity.ToTable("tblIncomeHead");
                entity.HasKey(e => e.IncomeHeadID);
            });

            // IncSub
            modelBuilder.Entity<IncSub>(entity =>
            {
                entity.ToTable("tblIncSub");
                entity.HasKey(e => e.IncSubID);
            });

            // User
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("tblUser");
                entity.HasKey(e => e.UserID);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
