using Domain.Entities;
using Domain.Enum;
using Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderNotification> OrderNotifications { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<User>()
            .Property(e => e.UserType)
            .HasConversion<int>();




            modelBuilder.Entity<User>().HasData(CreateCustomerSellerDataSeed());
            modelBuilder.Entity<Product>().HasData(CreateProductDataSeed());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            base.OnModelCreating(modelBuilder);
        }

        private User[] CreateCustomerSellerDataSeed()
        {
            User[] result = new User[]
            {
                    new User
                    {
                        Id = 1,
                        Name = "Gaston",
                        LastName = "Koch",
                        Password = "1",
                        Email = "gaston@gmail.com",
                        RegisterDate = DateTime.ParseExact("06/06/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        UserType = Domain.Enum.UserType.Seller
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Alejandro",
                        LastName = "Di Stefano",
                        Password = "2",
                        Email = "alejandro@gmail.com",
                        RegisterDate =  DateTime.ParseExact("05/04/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        UserType = Domain.Enum.UserType.Customer
                    },
                    new User
                    {
                        Id = 3,
                        Name = "Juan",
                        LastName = "Gomez",
                        Password = "3",
                        Email = "juan@gmail.com",
                        RegisterDate = DateTime.ParseExact("01/02/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        UserType = Domain.Enum.UserType.Seller
                    },
                    new User
                    {
                        Id = 4,
                        Name = "Ana",
                        LastName = "Lopez",
                        Password = "4",
                        Email = "ana@gmail.com",
                        RegisterDate = DateTime.ParseExact("10/05/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        UserType = Domain.Enum.UserType.Customer
                    },
                    new User
                    {
                        Id = 5,
                        Name = "Luis",
                        LastName = "Franco",
                        Password = "123",
                        Email = "luis@gmail.com",
                        RegisterDate = DateTime.ParseExact("15/03/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        UserType = Domain.Enum.UserType.Seller
                    },
                     new User
                    {
                        Id = 7,
                        Name = "admin",
                        LastName = string.Empty,
                        Password = "admin",
                        Email = "admin",
                        RegisterDate = DateTime.ParseExact("15/03/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        UserType = Domain.Enum.UserType.Admin
                    }
            };

            return result;
        }



        private Product[] CreateProductDataSeed()
        {
            Product[] result;
            result = [
                new Product
                    {
                        Id = 1,
                        Name = "Remera",
                        Price = 100.00f,
                        Description = "Talle L color blanco",
                        Stock = 50,
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Pantalon",
                        Price = 200.00f,
                        Description = "Talle 44 jean",
                        Stock = 30,
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Zapatos",
                        Price = 300.00f,
                        Description = "Talle 40 de color negro",
                        Stock = 20,
                    }];
            return result;
        }

        //private Order[] CreateOrderDataSeed()
        //{
        //    return new Order[]
        //    {
        //        new Order(
        //            customer: new User { Id = 2, Name = "Maria", LastName = "Perez", Password = "2", Email = "maria@gmail.com", RegisterDate = DateTime.ParseExact("05/04/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), UserType = Domain.Enum.UserType.Customer },
        //            seller: new User { Id = 1, Name = "Gaston", LastName = "Koch", Password = "1", Email = "gaston@gmail.com", RegisterDate = DateTime.ParseExact("06/06/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), UserType = Domain.Enum.UserType.Seller },
        //            productsInOrder: new Product[]
        //            {
        //                new Product { Id = 1, Name = "Remera", Price = 100.00f, Description = "Talle L color blanco", Stock = 50 }
        //            }
        //        )
        //        {
        //            Id = 1,
        //            AmountProducts = 1,
        //            PaymentMethod = PaymentMethod.CreditCard,
        //            StatusOrder = StatusOrder.InProgress
        //        },
        //        new Order(
        //            customer: new User { Id = 4, Name = "Ana", LastName = "Lopez", Password = "4", Email = "ana@gmail.com", RegisterDate = DateTime.ParseExact("10/05/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), UserType = Domain.Enum.UserType.Customer },
        //            seller: new User { Id = 3, Name = "Juan", LastName = "Gomez", Password = "3", Email = "juan@gmail.com", RegisterDate = DateTime.ParseExact("01/02/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), UserType = Domain.Enum.UserType.Seller },
        //            productsInOrder: new Product[]
        //            {
        //                new Product { Id = 2, Name = "Pantalon", Price = 200.00f, Description = "Talle 44 jean", Stock = 30 }
        //            }
        //        )
        //        {
        //            Id = 2,
        //            AmountProducts = 1,
        //            PaymentMethod = PaymentMethod.BankTransfer,
        //            StatusOrder = StatusOrder.Finished,
        //        }
        //    };
        //}

    }
}
