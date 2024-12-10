using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API1Ant.Models;

public partial class AntiqueStoreContext : DbContext
{
    public AntiqueStoreContext()
    {
    }

    public AntiqueStoreContext(DbContextOptions<AntiqueStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Catalogue> Catalogues { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-GTT1Q8C\\SQLEXPRESS;Database=AntiqueStore; Integrated Security=True; TrustServerCertificate=False; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Catalogue>(entity =>
        {
            entity.ToTable("Catalogue");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Coin).HasColumnType("money");
            entity.Property(e => e.Mirror).HasColumnType("money");
            entity.Property(e => e.MusicBox).HasColumnType("money");
            entity.Property(e => e.Necklace).HasColumnType("money");
            entity.Property(e => e.Ring).HasColumnType("money");
            entity.Property(e => e.SilverClocks).HasColumnType("money");
            entity.Property(e => e.Vase).HasColumnType("money");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CatalogueId).HasColumnName("CatalogueID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Catalogue).WithMany(p => p.Clients)
                .HasForeignKey(d => d.CatalogueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clients_Catalogue");

            entity.HasOne(d => d.Order).WithMany(p => p.Clients)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clients_Order");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Place)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ClientsId).HasColumnName("ClientsID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.HasOne(d => d.Clients).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ClientsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Clients");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Order");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
