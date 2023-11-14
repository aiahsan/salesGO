﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using SalesGO.Services.Customer.DataContext.DataContext;

#nullable disable

namespace SalesGO.Services.Customer.DataContext.Migrations
{
    [DbContext(typeof(CustomerContext))]
    [Migration("20231114194753_v3")]
    partial class v3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SalesGO.Services.Customer.Model.Models.Setup_Customer", b =>
                {
                    b.Property<int>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customerId"));

                    b.Property<string>("businessId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("createdBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerBusinessName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerRepresentativeDesignation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerRepresentativeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerTelephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("updatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customerId");

                    b.ToTable("Setup_Customers");
                });

            modelBuilder.Entity("SalesGO.Services.Customer.Model.Models.Setup_Outlet", b =>
                {
                    b.Property<int>("outletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("outletId"));

                    b.Property<Point>("Location")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("createdBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("outletAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("outletContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("outletImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("outletLat")
                        .HasColumnType("float");

                    b.Property<double>("outletLong")
                        .HasColumnType("float");

                    b.Property<string>("outletName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("updatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("outletId");

                    b.HasIndex("customerId");

                    b.ToTable("Setup_Outlet");
                });

            modelBuilder.Entity("SalesGO.Services.Customer.Model.Models.Setup_Outlet", b =>
                {
                    b.HasOne("SalesGO.Services.Customer.Model.Models.Setup_Customer", "Customer")
                        .WithMany("Outlets")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SalesGO.Services.Customer.Model.Models.Setup_Customer", b =>
                {
                    b.Navigation("Outlets");
                });
#pragma warning restore 612, 618
        }
    }
}
