using Microsoft.EntityFrameworkCore;
using Bangazon.Models;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System;

public class BangazonDbContext : DbContext
{

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<CustomerPaymentMethod> CustomerPaymentMethods { get; set; }

    public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerPaymentMethod>()
            .Property(cpm => cpm.PaymentMethod)
            .HasConversion<string>();

        modelBuilder.Entity<Customer>().HasData(new Customer[]
        {
            new Customer {UserUid = "1", CustomerUserName = "TestCust1", ImageUrl = "https://img.freepik.com/free-vector/cute-rat-face-with-smiley-face_1308-146750.jpg?t=st=1741049605~exp=1741053205~hmac=995443f80f9f469eb7671d40911a8551d91981b3c05e96bbefcc26ab1c0d56d0&w=740",
            FirstName = "Test1", LastName = "Brook", Email = "brook@email.com", Address = "123 Main st", City = "Midland", State = "NC", Zip = 20451 },
            new Customer {UserUid = "2", CustomerUserName = "TestCust2", ImageUrl = "https://img.freepik.com/free-vector/cute-mouse-cartoon-character_1308-140064.jpg?t=st=1741049847~exp=1741053447~hmac=164e23b0d9c44047635d3b19a774d338cbe09db323b73f287e0cfb70de7f0570&w=74",
            FirstName = "Test2", LastName = "Bee", Email = "bee@email.com", Address = "671 Main St", City = "Greenville", State = "NC", Zip = 45643 },
        });
        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new Order { Id = 401, CustomerUserUid = "1", SellerUserUid = "21", CustomerPaymentMethodId = 601, ProductId = 201, ProductTotal = 1, 
                OrderTotal = 5, Open = true, DateCreated = new DateTime(2025/2/28), Filled = false, Shipped = false, DateShipped = null},
            new Order { Id = 402, CustomerUserUid = "2", SellerUserUid = "22", CustomerPaymentMethodId = 602, ProductId = 202, ProductTotal = 2, 
                OrderTotal = 10, Open = false, DateCreated = new DateTime(2025/2/25), Filled = true, Shipped = true, DateShipped = new DateTime(2025/3/2)},
        });
       modelBuilder.Entity<Product>().HasData(new Product[]
        {
            new Product {Id = 201, SellerUserUid = "21", Name = "Cat Toy", Price = 5, Quantity = 5, ImageUrl="https://pixabay.com/photos/cat-toy-to-play-domestic-cat-4994140/", Description = "Your cat will love this"},
            new Product {Id = 202, SellerUserUid = "22", Name = "Dog Treats", Price = 8, Quantity = 1, ImageUrl="https://cdn.pixabay.com/photo/2014/05/21/18/08/dog-bones-350092_640.jpg", Description = "Yummy"},
        });
        modelBuilder.Entity<Seller>().HasData(new Seller[]
        {
            new Seller {UserUid = "21", SellerUserName = "Cats R Us", ImageUrl= "https://cdn.pixabay.com/photo/2021/11/22/04/28/animal-6815808_1280.jpg", Email = "cats@mail.com", City = "Cleveland", StateOrCountry = "OH", ProductsSold = true},
            new Seller {UserUid = "22", SellerUserName = "All Pets Food", ImageUrl = "https://cdn.pixabay.com/photo/2014/05/21/18/08/dog-bones-350092_640.jpg", Email = "Petsfood@mail.com", City = "London", StateOrCountry = "England", ProductsSold = true},
            new Seller {UserUid = "23", SellerUserName = "The Bird Store", ImageUrl= "https://cdn.pixabay.com/photo/2020/01/03/22/14/birdhouse-4739277_640.jpg", Email = "birds@mail.com", City = "Austin", StateOrCountry = "TX", ProductsSold = false},
        });
        modelBuilder.Entity<CustomerPaymentMethod>().HasData(new CustomerPaymentMethod[]
        {
            new CustomerPaymentMethod {Id = 601, CustomerUserUid = "1", PaymentMethod = PaymentType.ApplePay, Details = "applepay_user_1234"},
            new CustomerPaymentMethod {Id = 602, CustomerUserUid = "2", PaymentMethod = PaymentType.GooglePay, Details = "googlepay_user_5678"},
            new CustomerPaymentMethod {Id = 603, CustomerUserUid = "1", PaymentMethod = PaymentType.PayPal, Details = "paypal_user_test@example.com"},
            new CustomerPaymentMethod {Id = 604, CustomerUserUid = "2", PaymentMethod = PaymentType.CreditCard, Details = "4111-XXXX-XXXX-1234"},
        });
    }
}
        