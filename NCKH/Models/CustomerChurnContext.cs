using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NCKH.Models;

public partial class CustomerChurnContext : DbContext
{
    public CustomerChurnContext()
    {
    }

    public CustomerChurnContext(DbContextOptions<CustomerChurnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-1999OGI;Database=CustomerChurn;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Customer");
            entity.HasKey(e => e.CustomerId);
            entity.Property(e => e.Contract).HasMaxLength(50);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("customerID");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasColumnName("gender");
            entity.Property(e => e.InternetService).HasMaxLength(50);
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.StreamingTv).HasColumnName("StreamingTV");
            entity.Property(e => e.Tenure).HasColumnName("tenure");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}