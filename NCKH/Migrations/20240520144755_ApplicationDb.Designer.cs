﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NCKH.Models;

#nullable disable

namespace NCKH.Migrations
{
    [DbContext(typeof(CustomerChurnContext))]
    [Migration("20240520144755_ApplicationDb")]
    partial class ApplicationDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NCKH.Models.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("customerID");

                    b.Property<string>("Churn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contract")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Dependents")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceProtection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("gender");

                    b.Property<string>("InternetService")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("MonthlyCharges")
                        .HasColumnType("float");

                    b.Property<string>("MultipleLines")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OnlineBackup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OnlineSecurity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaperlessBilling")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Partner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneService")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("SeniorCitizen")
                        .HasColumnType("tinyint");

                    b.Property<string>("StreamingMovies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreamingTv")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("StreamingTV");

                    b.Property<string>("TechSupport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Tenure")
                        .HasColumnType("tinyint")
                        .HasColumnName("tenure");

                    b.Property<double?>("TotalCharges")
                        .HasColumnType("float");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}