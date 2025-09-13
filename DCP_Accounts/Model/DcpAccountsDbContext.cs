using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DCP_Accounts.Model;

public partial class DcpAccountsDbContext : DbContext
{
    public DcpAccountsDbContext()
    {
    }

    public DcpAccountsDbContext(DbContextOptions<DcpAccountsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblExpBub> TblExpBubs { get; set; }

    public virtual DbSet<TblExpend> TblExpends { get; set; }

    public virtual DbSet<TblExpendHead> TblExpendHeads { get; set; }

    public virtual DbSet<TblIncSub> TblIncSubs { get; set; }

    public virtual DbSet<TblIncome> TblIncomes { get; set; }

    public virtual DbSet<TblIncomeHead> TblIncomeHeads { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=DCP_Accounts_DB; Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblExpBub>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblExpBub");

            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.ExpCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ExpDetail)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ExpSubCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Uid)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("UID");
        });

        modelBuilder.Entity<TblExpend>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblExpend");

            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.ExpSubCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ExpenditurId).HasColumnName("ExpenditurID");
            entity.Property(e => e.Uid)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("UID");
        });

        modelBuilder.Entity<TblExpendHead>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblExpendHead");

            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.ExpCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ExpDetail)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Uid)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("UID");
        });

        modelBuilder.Entity<TblIncSub>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblIncSub");

            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.IncCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IncDetail)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IncSubCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Uid)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("UID");
        });

        modelBuilder.Entity<TblIncome>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblIncome");

            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.ExpenditurId).HasColumnName("ExpenditurID");
            entity.Property(e => e.IncDetail)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Uid)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("UID");
        });

        modelBuilder.Entity<TblIncomeHead>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblIncomeHead");

            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.IncCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IncDetail)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Uid)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("UID");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblUser");

            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.EmpId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("EmpID");
            entity.Property(e => e.EntryBy)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Uid)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("UID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
