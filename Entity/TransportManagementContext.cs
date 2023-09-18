using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace netCoreTransportMgmt.Entity;

public partial class TransportManagementContext : DbContext
{
    public TransportManagementContext()
    {
    }

    public TransportManagementContext(DbContextOptions<TransportManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DriverDetail> DriverDetails { get; set; }

    public virtual DbSet<RouteDetail> RouteDetails { get; set; }

    public virtual DbSet<TransportDetail> TransportDetails { get; set; }

    public virtual DbSet<TypeDetail> TypeDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-IDK5662;Database=TransportManagement;user=sa;password=1234;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DriverDetail>(entity =>
        {
            entity.HasKey(e => e.DriverId);

            entity.ToTable("DriverDetail");

            entity.Property(e => e.ContactNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DateAvailable).HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Route).WithMany(p => p.DriverDetails)
                .HasForeignKey(d => d.RouteId)
                .HasConstraintName("FK_DriverDetail_RouteDetail");
        });

        modelBuilder.Entity<RouteDetail>(entity =>
        {
            entity.HasKey(e => e.RouteId);

            entity.ToTable("RouteDetail");

            entity.Property(e => e.Destination)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Origin)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TransportDetail>(entity =>
        {
            entity.HasKey(e => e.TransportId);

            entity.ToTable("TransportDetail");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.Driver).WithMany(p => p.TransportDetails)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK_TransportDetail_DriverDetail");

            entity.HasOne(d => d.Route).WithMany(p => p.TransportDetails)
                .HasForeignKey(d => d.RouteId)
                .HasConstraintName("FK_TransportDetail_RouteDetail");

            entity.HasOne(d => d.Type).WithMany(p => p.TransportDetails)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_TransportDetail_TypeDetail");
        });

        modelBuilder.Entity<TypeDetail>(entity =>
        {
            entity.HasKey(e => e.TypeId);

            entity.ToTable("TypeDetail");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
