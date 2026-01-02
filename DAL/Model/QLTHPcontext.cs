using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Model
{
    public partial class QLTHPcontext : DbContext
    {
        public QLTHPcontext()
            : base("name=QLTHPcontext")
        {
        }

        public virtual DbSet<DSLOP> DSLOP { get; set; }
        public virtual DbSet<DSSV> DSSV { get; set; }
        public virtual DbSet<HEDT> HEDT { get; set; }
        public virtual DbSet<HOCPHI> HOCPHI { get; set; }
        public virtual DbSet<THUHP> THUHP { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DSLOP>()
                .Property(e => e.MALO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSLOP>()
                .Property(e => e.MAHE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSLOP>()
                .HasMany(e => e.DSSV)
                .WithRequired(e => e.DSLOP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DSSV>()
                .Property(e => e.MASV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSSV>()
                .Property(e => e.MALO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSSV>()
                .HasMany(e => e.THUHP)
                .WithRequired(e => e.DSSV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HEDT>()
                .Property(e => e.MAHE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HEDT>()
                .HasMany(e => e.DSLOP)
                .WithRequired(e => e.HEDT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOCPHI>()
                .Property(e => e.MAHP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOCPHI>()
                .HasMany(e => e.THUHP)
                .WithRequired(e => e.HOCPHI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUHP>()
                .Property(e => e.MASV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THUHP>()
                .Property(e => e.MAHP)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
