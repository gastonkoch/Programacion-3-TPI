using Domain.Entities;
using Domain.Enum;
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

            modelBuilder.Entity<User>()
            .HasDiscriminator<UserType>("UserType")
            .HasValue<User>(UserType.Customer)
            .HasValue<User>(UserType.Seller);

            modelBuilder.Entity<User>().HasData(CreateCustomerSellerDataSeed());

            modelBuilder.Entity<Product>().HasData(CreateProductDataSeed());

            //modelBuilder.Entity<Order>().HasData(CreateOrderDataSeed());




            base.OnModelCreating(modelBuilder);


            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

        }

        private User[] CreateCustomerSellerDataSeed()
        {
            User[] result = new User[]
            {
        new User
        {
            Id = 1,
            Name = "Gaston",
            Password = "1",
            Email = "gaston@gmail.com",
            RegisterDate = DateTime.ParseExact("06/06/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            UserType = Domain.Enum.UserType.Seller
        },
        new User
        {
            Id = 2,
            Name = "Maria",
            Password = "2",
            Email = "maria@gmail.com",
            RegisterDate =  DateTime.ParseExact("05/04/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            UserType = Domain.Enum.UserType.Customer
        },
        new User
        {
            Id = 3,
            Name = "Juan",
            Password = "3",
            Email = "juan@gmail.com",
            RegisterDate = DateTime.ParseExact("01/02/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            UserType = Domain.Enum.UserType.Seller
        },
        new User
        {
            Id = 4,
            Name = "Ana",
            Password = "4",
            Email = "ana@gmail.com",
            RegisterDate = DateTime.ParseExact("10/05/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            UserType = Domain.Enum.UserType.Customer
        },
        new User
        {
            Id = 5,
            Name = "Luis",
            Password = "5",
            Email = "luis@gmail.com",
            RegisterDate = DateTime.ParseExact("15/03/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            UserType = Domain.Enum.UserType.Seller
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
        //    var users = CreateCustomerSellerDataSeed();

        //    var products = CreateProductDataSeed();

        //    Order[] result;
        //    result = [
        //        //new Order
        //        //{
        //        //    Id = 1,
        //        //    AmountProducts = 5,
        //        //    PaymentMethod = PaymentMethod.Cash,
        //        //    StatusOrder = StatusOrder.InProgress,
        //        //    Customer = users[1], // Maria
        //        //    Seller = users[0], // Gaston
        //        //    ProductsInOrder = new List<Product> { products[0] }
        //        //},
        //        //new Order
        //        //{
        //        //    Id = 2,
        //        //    AmountProducts = 3,
        //        //    PaymentMethod = PaymentMethod.BankTransfer,
        //        //    StatusOrder = StatusOrder.InProgress,
        //        //    Customer = users[3], // Ana
        //        //    Seller = users[0], // Gaston
        //        //    ProductsInOrder = new List<Product> { products[1], products[2] }
        //        //},
        //        //new Order
        //        //{
        //        //    Id = 3,
        //        //    AmountProducts = 7,
        //        //    PaymentMethod = PaymentMethod.DebitCard,
        //        //    StatusOrder = StatusOrder.Cancelled,
        //        //    Customer = users[3], // Ana
        //        //    Seller = users[4], // Luis
        //        //    ProductsInOrder = new List<Product> { products[2]}
        //        //},
        //        //new Order
        //        //{
        //        //    Id = 4,
        //        //    AmountProducts = 2,
        //        //    PaymentMethod = PaymentMethod.CreditCard,
        //        //    StatusOrder = StatusOrder.InProgress,
        //        //    Customer = users[1], // Maria
        //        //    Seller = users[2], // Juan
        //        //    ProductsInOrder = new List<Product> { products[0], products[2] }
        //        //}
        //        new Order
        //        {
        //            Id = 1,
        //            AmountProducts = 5,
        //            PaymentMethod = PaymentMethod.Cash,
        //            StatusOrder = StatusOrder.InProgress,
        //            CustomerId = 2, // Maria
        //            SellerId = 1,   // Gaston
        //            ProductsInOrder = new List<Product> { new Product { Id = 1 } }
        //        },
        //        new Order
        //        {
        //            Id = 2,
        //            AmountProducts = 3,
        //            PaymentMethod = PaymentMethod.BankTransfer,
        //            StatusOrder = StatusOrder.InProgress,
        //            CustomerId = 4, // Ana
        //            SellerId = 1,   // Gaston
        //            ProductsInOrder = new List<Product> { new Product { Id = 2 }, new Product { Id = 3 } }
        //        },
        //        new Order
        //        {
        //            Id = 3,
        //            AmountProducts = 7,
        //            PaymentMethod = PaymentMethod.DebitCard,
        //            StatusOrder = StatusOrder.Cancelled,
        //            CustomerId = 4, // Ana
        //            SellerId = 5,   // Luis
        //            ProductsInOrder = new List<Product> { new Product { Id = 3 } }
        //        },
        //        new Order
        //        {
        //            Id = 4,
        //            AmountProducts = 2,
        //            PaymentMethod = PaymentMethod.CreditCard,
        //            StatusOrder = StatusOrder.InProgress,
        //            CustomerId = 2, // Maria
        //            SellerId = 3,   // Juan
        //            ProductsInOrder = new List<Product> { new Product { Id = 1 }, new Product { Id = 3 } }
        //        }];
        //    return result;
        //}

    }
}
