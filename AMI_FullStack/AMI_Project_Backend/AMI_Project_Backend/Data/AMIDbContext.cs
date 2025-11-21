using System;
using System.Collections.Generic;
using AMI_Project_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace AMI_Project_Backend.Data;

public partial class AMIDbContext : DbContext
{
    public AMIDbContext()
    {
    }

    public AMIDbContext(DbContextOptions<AMIDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Billing> Billings { get; set; }

    public virtual DbSet<Consumer> Consumers { get; set; }

    public virtual DbSet<Meter> Meters { get; set; }

    public virtual DbSet<MeterReading> MeterReadings { get; set; }

    public virtual DbSet<OrgUnit> OrgUnits { get; set; }

    public virtual DbSet<Tariff> Tariffs { get; set; }

    public virtual DbSet<TariffSlab> TariffSlabs { get; set; }
    //public virtual  DbSet<OrgUnit> OrgUnits { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            
            optionsBuilder.UseSqlServer("Name=ConnectionStrings:connectedDb");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Billing>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Billing__11F2FC6A3E063136");

            entity.ToTable("Billing", "ami");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.GeneratedDate)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.MeterSerialNo).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.UnitsConsumed).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.Consumer).WithMany(p => p.Billings)
                .HasForeignKey(d => d.ConsumerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Billing__Consume__52593CB8");

            entity.HasOne(d => d.MeterSerialNoNavigation).WithMany(p => p.Billings)
                .HasForeignKey(d => d.MeterSerialNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Billing__MeterSe__534D60F1");
        });

        modelBuilder.Entity<Consumer>(entity =>
        {
            entity.HasKey(e => e.ConsumerId).HasName("PK__Consumer__63BBE9BA1E814C1F");

            entity.ToTable("Consumer", "ami");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("system");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Latitude).HasColumnType("decimal(10, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(10, 6)");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Active");
            entity.Property(e => e.UpdatedAt).HasPrecision(3);
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);

            entity.HasOne(d => d.OrgUnit).WithMany(p => p.Consumers)
                .HasForeignKey(d => d.OrgUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consumer__OrgUni__4222D4EF");

            entity.HasOne(d => d.Tariff).WithMany(p => p.Consumers)
                .HasForeignKey(d => d.TariffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consumer__Tariff__4316F928");
        });

        modelBuilder.Entity<Meter>(entity =>
        {
            entity.HasKey(e => e.MeterSerialNo).HasName("PK__Meter__5C498B0FA1BF04E1");

            entity.ToTable("Meter", "ami");

            entity.HasIndex(e => e.MeterSerialNo, "IX_Meter_Serial").IsUnique();

            entity.Property(e => e.MeterSerialNo).HasMaxLength(50);
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Firmware).HasMaxLength(50);
            entity.Property(e => e.Iccid)
                .HasMaxLength(30)
                .HasColumnName("ICCID");
            entity.Property(e => e.Imsi)
                .HasMaxLength(30)
                .HasColumnName("IMSI");
            entity.Property(e => e.InstallTsUtc).HasPrecision(3);
            entity.Property(e => e.IpAddress).HasMaxLength(45);
            entity.Property(e => e.Manufacturer).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Active");

            entity.HasOne(d => d.Consumer).WithMany(p => p.Meters)
                .HasForeignKey(d => d.ConsumerId)
                .HasConstraintName("FK__Meter__ConsumerI__4BAC3F29");
        });

        modelBuilder.Entity<MeterReading>(entity =>
        {
            entity.HasKey(e => e.ReadingId).HasName("PK__MeterRea__C80F9C4EB71AFD5B");

            entity.ToTable("MeterReading", "ami");

            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Kwh).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MeterSerialNo).HasMaxLength(50);
            entity.Property(e => e.ReadingDate).HasPrecision(3);

            entity.HasOne(d => d.MeterSerialNoNavigation).WithMany(p => p.MeterReadings)
                .HasForeignKey(d => d.MeterSerialNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MeterRead__Meter__4E88ABD4");
        });

        modelBuilder.Entity<OrgUnit>(entity =>
        {
            entity.HasKey(e => e.OrgUnitId).HasName("PK__OrgUnit__4A793BEE34F974C0");

            entity.ToTable("OrgUnit", "ami");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Parent).WithMany(p => p.Children)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__OrgUnit__ParentI__38996AB5");
        });

        modelBuilder.Entity<Tariff>(entity =>
        {
            entity.HasKey(e => e.TariffId).HasName("PK__Tariff__EBAF9DB388E6A331");

            entity.ToTable("Tariff", "ami");

            entity.Property(e => e.BaseRate).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.TaxRate).HasColumnType("decimal(18, 4)");
        });

        modelBuilder.Entity<TariffSlab>(entity =>
        {
            entity.HasKey(e => e.TariffSlabId).HasName("PK__TariffSl__64EAAA22C2755796");

            entity.ToTable("TariffSlab", "ami");

            entity.Property(e => e.FromKwh).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.RatePerKwh).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.ToKwh).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.Tariff).WithMany(p => p.TariffSlabs)
                .HasForeignKey(d => d.TariffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TariffSla__Tarif__3E52440B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C0B81B05C");

            entity.ToTable("User", "ami");

            entity.HasIndex(e => e.Username, "UQ__User__536C85E43C2733E0").IsUnique();

            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
