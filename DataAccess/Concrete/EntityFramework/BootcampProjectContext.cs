using Core.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework;

public class BootcampProjectContext : DbContext
{
    private readonly IConfiguration? _configuration;

    public BootcampProjectContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public BootcampProjectContext()
    {
        _configuration = null;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=BootcampProject.db");
        }
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<Bootcamp> Bootcamps { get; set; }
    public DbSet<Blacklist> Blacklists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User configuration
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<User>()
            .Property(u => u.NationalIdentity)
            .IsRequired()
            .HasMaxLength(11);

        // Instructor configuration
        modelBuilder.Entity<Instructor>()
            .Property(i => i.CompanyName)
            .HasMaxLength(100);

        // Applicant configuration
        modelBuilder.Entity<Applicant>()
            .Property(a => a.About)
            .HasMaxLength(500);

        // Employee configuration
        modelBuilder.Entity<Employee>()
            .Property(e => e.Position)
            .HasMaxLength(100);

        // Application configuration
        modelBuilder.Entity<Application>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<Application>()
            .HasOne(a => a.Applicant)
            .WithMany()
            .HasForeignKey(a => a.ApplicantId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Application>()
            .HasOne(a => a.Bootcamp)
            .WithMany(b => b.Applications)
            .HasForeignKey(a => a.BootcampId)
            .OnDelete(DeleteBehavior.Restrict);

        // Bootcamp configuration
        modelBuilder.Entity<Bootcamp>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<Bootcamp>()
            .Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Bootcamp>()
            .HasOne(b => b.Instructor)
            .WithMany()
            .HasForeignKey(b => b.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Blacklist configuration
        modelBuilder.Entity<Blacklist>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<Blacklist>()
            .Property(b => b.Reason)
            .IsRequired()
            .HasMaxLength(500);

        modelBuilder.Entity<Blacklist>()
            .HasOne(b => b.Applicant)
            .WithMany()
            .HasForeignKey(b => b.ApplicantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 