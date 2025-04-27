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
    }
} 