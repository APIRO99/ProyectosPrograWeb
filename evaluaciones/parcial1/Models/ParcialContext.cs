using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace parcial1.Models;

public partial class ParcialContext : DbContext
{
    public ParcialContext()
    {
    }

    public ParcialContext(DbContextOptions<ParcialContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<PersonalInformation> PersonalInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=127.0.0.1;userid=PARCIAL;password=4356ybtwea4b6w34h7b56;database=PARCIAL;TreatTinyAsBoolean=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("appointment");

            entity.HasIndex(e => e.PersonalInformationDoctorId, "fk_doctor_id");

            entity.HasIndex(e => e.PersonalInformationPatientId, "fk_patient_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppointmentDate)
                .HasColumnType("date")
                .HasColumnName("appointment_date");
            entity.Property(e => e.AppointmentTime)
                .HasColumnType("time")
                .HasColumnName("appointment_time");
            entity.Property(e => e.PersonalInformationDoctorId).HasColumnName("personal_information_doctor_id");
            entity.Property(e => e.PersonalInformationPatientId).HasColumnName("personal_information_patient_id");

            entity.HasOne(d => d.PersonalInformationDoctor).WithMany(p => p.AppointmentPersonalInformationDoctors)
                .HasForeignKey(d => d.PersonalInformationDoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_doctor_id");

            entity.HasOne(d => d.PersonalInformationPatient).WithMany(p => p.AppointmentPersonalInformationPatients)
                .HasForeignKey(d => d.PersonalInformationPatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_patient_id");
        });

        modelBuilder.Entity<PersonalInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("personal_information");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
