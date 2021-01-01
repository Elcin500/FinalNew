﻿// <auto-generated />
using System;
using FinalHomeSale.Models.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalHomeSale.Migrations
{
    [DbContext(typeof(HomeSaleDbContext))]
    [Migration("20201223192331_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("FinalHomeSale.Models.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FinalHomeSale.Models.Entity.Home", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Agency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Agent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 12, 23, 23, 23, 30, 379, DateTimeKind.Local).AddTicks(1586));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Garage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Room")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Homes");
                });

            modelBuilder.Entity("FinalHomeSale.Models.Entity.HomeImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HomeId");

                    b.ToTable("HomeImages");
                });

            modelBuilder.Entity("FinalHomeSale.Models.Entity.Home", b =>
                {
                    b.HasOne("FinalHomeSale.Models.Entity.Category", "Category")
                        .WithMany("Homes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FinalHomeSale.Models.Entity.HomeImage", b =>
                {
                    b.HasOne("FinalHomeSale.Models.Entity.Home", "Home")
                        .WithMany("Images")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");
                });

            modelBuilder.Entity("FinalHomeSale.Models.Entity.Category", b =>
                {
                    b.Navigation("Homes");
                });

            modelBuilder.Entity("FinalHomeSale.Models.Entity.Home", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
