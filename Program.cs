using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonDbContext>(builder.Configuration["BangazonDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.MapGet("/api/customers", (BangazonDbContext db) =>
{
    
   return db.Customers.ToList();
});

app.MapGet("/api/customers/{userUid}", (BangazonDbContext db, string userUid) =>
{
    return db.Customers
        .Include(c => c.Orders)
        .SingleOrDefault(c => c.UserUid == userUid);
});

app.MapPost("/api/customers", (BangazonDbContext db, Customer customer) =>
{
    db.Customers.Add(customer);
    db.SaveChanges();
    return Results.Created($"/api/customers/{customer.UserUid}", customer);
});

app.MapDelete("/api/customers/{userUid}", (BangazonDbContext db, string userUid) =>
{
    Customer customer = db.Customers.SingleOrDefault(customer => customer.UserUid == userUid);
    if (customer == null)
    {
        return Results.NotFound();
    }
    db.Customers.Remove(customer);
    db.SaveChanges();
    return Results.NoContent();

});

app.MapPut("/api/customers/{userUid}", (BangazonDbContext db, string userUid, Customer customer) =>
{
    Customer customerToUpdate = db.Customers.SingleOrDefault(customer => customer.UserUid == userUid);
    if (customerToUpdate == null)
    {
        return Results.NotFound();
    }
    customerToUpdate.CustomerUserName = customer.CustomerUserName;
    customerToUpdate.ImageUrl = customer.ImageUrl;
    customerToUpdate.FirstName = customer.FirstName;
    customerToUpdate.LastName = customer.LastName;
    customerToUpdate.Email = customer.Email;
    customerToUpdate.Address = customer.Address;
    customerToUpdate.City = customer.City;
    customerToUpdate.State = customer.State;
    customerToUpdate.Zip = customer.Zip;

    db.SaveChanges();
    return Results.NoContent();
});

app.MapGet("/api/sellers", (BangazonDbContext db) =>
{

    return db.Sellers.ToList();
});

app.MapGet("/api/sellers/{userUid}", (BangazonDbContext db, string userUid) =>
{
    return db.Sellers
        .Include(c => c.Orders)
        .Include(c => c.Products)
        .SingleOrDefault(c => c.UserUid == userUid);
});

app.MapPost("/api/sellers", (BangazonDbContext db, Seller seller) =>
{
    db.Sellers.Add(seller);
    db.SaveChanges();
    return Results.Created($"/api/sellers/{seller.UserUid}", seller);
});

app.MapDelete("/api/sellers/{userUid}", (BangazonDbContext db, string userUid) =>
{
    Seller seller = db.Sellers.SingleOrDefault(seller => seller.UserUid == userUid);
    if (seller == null)
    {
        return Results.NotFound();
    }
    db.Sellers.Remove(seller);
    db.SaveChanges();
    return Results.NoContent();

});

app.MapPut("/api/sellers/{userUid}", (BangazonDbContext db, string userUid, Seller seller) =>
{
    Seller sellerToUpdate = db.Sellers.SingleOrDefault(seller => seller.UserUid == userUid);
    if (sellerToUpdate == null)
    {
        return Results.NotFound();
    }
    sellerToUpdate.SellerUserName = seller.SellerUserName;
    sellerToUpdate.ImageUrl = seller.ImageUrl;
    sellerToUpdate.Email = seller.Email;
    sellerToUpdate.City = seller.City;
    sellerToUpdate.StateOrCountry = seller.StateOrCountry;
    sellerToUpdate.ProductsSold = seller.ProductsSold;

    db.SaveChanges();
    return Results.NoContent();
});

app.MapGet("/api/products", (BangazonDbContext db) =>
{

    return db.Products.ToList();
});

// app.MapPost("/api/products", (BangazonDbContext db, Product newProd) =>
// {
    // db.Products.Add(newProd);
    // db.SaveChanges();
    // return Results.Created($"/api/products/{newProd.Id}", newProd);
// });

app.MapGet("/api/orders", (BangazonDbContext db) =>
{

    return db.Orders.ToList();
});

app.Run();