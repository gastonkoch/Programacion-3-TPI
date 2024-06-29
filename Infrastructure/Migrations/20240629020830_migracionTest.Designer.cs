﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240629020830_migracionTest")]
    partial class migracionTest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmountProducts")
                        .HasColumnType("int(4.0)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SellerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusOrder")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SellerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Entities.OrderNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("OrderNotifications");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<float>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int(4.0)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Talle L color blanco",
                            Name = "Remera",
                            Price = 100f,
                            Stock = 50
                        },
                        new
                        {
                            Id = 2,
                            Description = "Talle 44 jean",
                            Name = "Pantalon",
                            Price = 200f,
                            Stock = 30
                        },
                        new
                        {
                            Id = 3,
                            Description = "Talle 40 de color negro",
                            Name = "Zapatos",
                            Price = 300f,
                            Stock = 20
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime");

                    b.Property<int>("UserType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "gaston@gmail.com",
                            LastName = "Koch",
                            Name = "Gaston",
                            Password = "1",
                            RegisterDate = new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserType = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "alejandro@gmail.com",
                            LastName = "Di Stefano",
                            Name = "Alejandro",
                            Password = "2",
                            RegisterDate = new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserType = 0
                        },
                        new
                        {
                            Id = 3,
                            Email = "juan@gmail.com",
                            LastName = "Gomez",
                            Name = "Juan",
                            Password = "3",
                            RegisterDate = new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserType = 1
                        },
                        new
                        {
                            Id = 4,
                            Email = "ana@gmail.com",
                            LastName = "Lopez",
                            Name = "Ana",
                            Password = "4",
                            RegisterDate = new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserType = 0
                        },
                        new
                        {
                            Id = 5,
                            Email = "luis@gmail.com",
                            LastName = "Franco",
                            Name = "Luis",
                            Password = "123",
                            RegisterDate = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserType = 1
                        },
                        new
                        {
                            Id = 7,
                            Email = "admin",
                            LastName = "",
                            Name = "admin",
                            Password = "admin",
                            RegisterDate = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserType = 2
                        });
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrdersWithProductsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductsInOrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrdersWithProductsId", "ProductsInOrderId");

                    b.HasIndex("ProductsInOrderId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.HasOne("Domain.Entities.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Domain.Entities.OrderNotification", b =>
                {
                    b.HasOne("Domain.Entities.Order", null)
                        .WithMany("OrderNotifications")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Domain.Entities.User", null)
                        .WithMany("OrderNotifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("Domain.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersWithProductsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsInOrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderNotifications");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("OrderNotifications");
                });
#pragma warning restore 612, 618
        }
    }
}
