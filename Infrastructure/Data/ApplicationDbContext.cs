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
            //modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            //modelBuilder.Entity<User>()
            //.HasDiscriminator(u => u.UserType)
            //.HasValue<User>(UserType.Customer)
            //.HasValue<User>(UserType.Seller)
            //.HasValue<User>(UserType.Admin);

            // Revisar si esto rompe la migracion, lo que esta haciendo es que a la hora de autentificar desde el swagger no falle
            // En la api catedra UserType es un string por eso funciona, el swagger no dice que tenemos enviar un int, entonces convertimos el int en un Enum
            modelBuilder
            .Entity<User>()
            .Property(e => e.UserType)
            .HasConversion<int>();

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
                },
                 new User
                {
                    Id = 7,
                    Name = "admin",
                    Password = "admin",
                    Email = "admin@gmail.com",
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

        //private order[] createorderdataseed()
        //{
        //    var users = createcustomersellerdataseed();

        //    var products = createproductdataseed();

        //    order[] result;
        //    result = [
        //        new order
        //        {
        //            id = 1,
        //            amountproducts = 5,
        //            paymentmethod = paymentmethod.cash,
        //            statusorder = statusorder.inprogress,
        //            customer = users[1], // maria
        //            seller = users[0], // gaston
        //            productsinorder = new list<product> { products[0] }
        //        },
        //        new order
        //        {
        //            id = 2,
        //            amountproducts = 3,
        //            paymentmethod = paymentmethod.banktransfer,
        //            statusorder = statusorder.inprogress,
        //            customer = users[3], // ana
        //            seller = users[0], // gaston
        //            productsinorder = new list<product> { products[1], products[2] }
        //        },
        //        new order
        //        {
        //            id = 3,
        //            amountproducts = 7,
        //            paymentmethod = paymentmethod.debitcard,
        //            statusorder = statusorder.cancelled,
        //            customer = users[3], // ana
        //            seller = users[4], // luis
        //            productsinorder = new list<product> { products[2]}
        //        },
        //        new order
        //        {
        //            id = 4,
        //            amountproducts = 2,
        //            paymentmethod = paymentmethod.creditcard,
        //            statusorder = statusorder.inprogress,
        //            customer = users[1], // maria
        //            seller = users[2], // juan
        //            productsinorder = new list<product> { products[0], products[2] }
        //        },
        //        new order
        //        {
        //            id = 1,
        //            amountproducts = 5,
        //            paymentmethod = paymentmethod.cash,
        //            statusorder = statusorder.inprogress,
        //            customerid = 2, // maria
        //            sellerid = 1,   // gaston
        //            productsinorder = new list<product> { new product { id = 1 } }
        //        },
        //        new order
        //        {
        //            id = 2,
        //            amountproducts = 3,
        //            paymentmethod = paymentmethod.banktransfer,
        //            statusorder = statusorder.inprogress,
        //            customerid = 4, // ana
        //            sellerid = 1,   // gaston
        //            productsinorder = new list<product> { new product { id = 2 }, new product { id = 3 } }
        //        },
        //        new order
        //        {
        //            id = 3,
        //            amountproducts = 7,
        //            paymentmethod = paymentmethod.debitcard,
        //            statusorder = statusorder.cancelled,
        //            customerid = 4, // ana
        //            sellerid = 5,   // luis
        //            productsinorder = new list<product> { new product { id = 3 } }
        //        },
        //        new order
        //        {
        //            id = 4,
        //            amountproducts = 2,
        //            paymentmethod = paymentmethod.creditcard,
        //            statusorder = statusorder.inprogress,
        //            customerid = 2, // maria
        //            sellerid = 3,   // juan
        //            productsinorder = new list<product> { new product { id = 1 }, new product { id = 3 } }
        //        }];
        //    return result;
        //}

    }
}
