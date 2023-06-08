using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PsychologyApp.WebApi.Entities;

namespace PsychologyApp.WebApi.Models;

public partial class PsychologyContext : DbContext
{
    public PsychologyContext()
    {
    }

    public PsychologyContext(DbContextOptions<PsychologyContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=psychology;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<Psychologist>()
                .ToTable("psychologist");        
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientNote> PatientNotes { get; set; }
    public DbSet<Psychologist> Psychologist { get; set; }    
    public DbSet<Shedule> Shedule { get; set; }
    public DbSet<Therapy> Therapies { get; set; } 
    
    


}
