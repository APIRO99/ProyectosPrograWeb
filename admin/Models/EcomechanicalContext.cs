using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace admin.Models;

public partial class EcomechanicalContext : DbContext
{
    public EcomechanicalContext()
    {
    }

    public EcomechanicalContext(DbContextOptions<EcomechanicalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Testimonial> Testimonials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=127.0.0.1;userid=ECOMEC_ADMIN;password=4356ybtwea4b6w34h7b56;database=ECOMECHANICAL;TreatTinyAsBoolean=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PRIMARY");

            entity.ToTable("CLIENTS");

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.ClientEmail)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("client_email");
            entity.Property(e => e.ClientName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("client_name");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PRIMARY");

            entity.ToTable("SERVICES");

            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.ServiceDescription)
                .IsRequired()
                .HasColumnType("text")
                .HasColumnName("service_description");
            entity.Property(e => e.ServiceName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("service_name");
            entity.Property(e => e.ServicePrice)
                .HasPrecision(10)
                .HasColumnName("service_price");
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.HasKey(e => e.TestimonialId).HasName("PRIMARY");

            entity.ToTable("TESTIMONIALS");

            entity.HasIndex(e => e.ClientId, "client_id");

            entity.HasIndex(e => e.ServiceId, "service_id");

            entity.Property(e => e.TestimonialId).HasColumnName("testimonial_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.ClientName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("client_name");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.TestimonialText)
                .IsRequired()
                .HasColumnType("text")
                .HasColumnName("testimonial_text");

            entity.HasOne(d => d.Client).WithMany(p => p.Testimonials)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TESTIMONIALS_ibfk_2");

            entity.HasOne(d => d.Service).WithMany(p => p.Testimonials)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TESTIMONIALS_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
