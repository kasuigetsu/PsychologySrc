﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PsychologyApp.WebApi.Models;

#nullable disable

namespace PsychologyApp.WebApi.Migrations
{
    [DbContext(typeof(PsychologyContext))]
    [Migration("20230604154356_AddPatientNotesTable")]
    partial class AddPatientNotesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PsychologyApp.WebApi.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Anamnesis")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("anamnesis");

                    b.Property<DateTime?>("BirthdayDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birthday_date");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email_address");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsReceiveNotif")
                        .HasColumnType("boolean")
                        .HasColumnName("is_receive_notif");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("patronymic");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("PsychologistId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("psychologist_id");

                    b.Property<string>("Recommendations")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("recommendations");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("pk_patients");

                    b.HasIndex("EmailAddress")
                        .IsUnique()
                        .HasDatabaseName("ix_patients_email_address");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasDatabaseName("ix_patients_phone_number");

                    b.ToTable("patients", (string)null);
                });

            modelBuilder.Entity("PsychologyApp.WebApi.Entities.PatientNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_patient_notes");

                    b.ToTable("patient_notes", (string)null);
                });

            modelBuilder.Entity("PsychologyApp.WebApi.Entities.Psychologist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BirthdayDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birthday_date");

                    b.Property<string>("EducationInfo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("education_info");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email_address");

                    b.Property<string>("ExperienceInfo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("experience_info");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsReceiveNotif")
                        .HasColumnType("boolean")
                        .HasColumnName("is_receive_notif");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("patronymic");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.Property<string>("Unicode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("unicode");

                    b.Property<string>("Weekends")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("weekends");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.HasKey("Id")
                        .HasName("pk_psychologist");

                    b.HasIndex("EmailAddress")
                        .IsUnique()
                        .HasDatabaseName("ix_psychologist_email_address");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasDatabaseName("ix_psychologist_phone_number");

                    b.HasIndex("Unicode")
                        .IsUnique()
                        .HasDatabaseName("ix_psychologist_unicode");

                    b.ToTable("psychologist", (string)null);
                });

            modelBuilder.Entity("PsychologyApp.WebApi.Entities.Shedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("appointment_date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<int>("NotifStatus")
                        .HasColumnType("integer")
                        .HasColumnName("notif_status");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.Property<int>("PsychologistId")
                        .HasColumnType("integer")
                        .HasColumnName("psychologist_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<int>("TherapyId")
                        .HasColumnType("integer")
                        .HasColumnName("therapy_id");

                    b.HasKey("Id")
                        .HasName("pk_shedule");

                    b.ToTable("shedule", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
