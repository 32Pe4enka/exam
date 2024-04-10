using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WorkKom.Models
{
    public partial class Airbilet2Context : DbContext
    {
        public Airbilet2Context()
        {
        }

        public Airbilet2Context(DbContextOptions<Airbilet2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Billet> Billets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                
                //optionsBuilder.UseSqlServer("строка подключения ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Billet>(entity =>
            {
                entity.HasKey(e => e.IdB)
                    .HasName("PK_DV");

                entity.Property(e => e.IdB).HasColumnName("ID_B");

                entity.Property(e => e.BillDp)
                    .HasColumnType("date")
                    .HasColumnName("BillDP");

                entity.Property(e => e.BillDv)
                    .HasColumnType("date")
                    .HasColumnName("BillDV");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
