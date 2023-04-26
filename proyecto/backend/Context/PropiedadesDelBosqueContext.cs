using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Context;

public partial class PropiedadesDelBosqueContext : DbContext
{
    public PropiedadesDelBosqueContext()
    {
    }

    public PropiedadesDelBosqueContext(DbContextOptions<PropiedadesDelBosqueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  {
        var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        string? conString = MyConfig.GetValue<string>("database:conString");
        if (conString == null) throw new Exception("No se encontró la cadena de conexión");
        optionsBuilder.UseMySQL(conString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("properties");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Photo)
                .HasMaxLength(255)
                .HasColumnName("photo");
            entity.Property(e => e.State)
                .HasMaxLength(255)
                .HasColumnName("state");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Beds)
                .HasColumnType("int")
                .HasColumnName("beds");
            entity.Property(e => e.Baths)
                .HasColumnType("int")
                .HasColumnName("baths");
            entity.Property(e => e.WeekRent)
                .HasColumnType("int")
                .HasColumnName("weekRent");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasColumnName("model");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
