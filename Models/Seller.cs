using Microsoft.Win32;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class Seller
{
    [Key]
    public required string UserUid { get; set; }
    
    [Required]
    public required string SellerUserName { get; set; }
    public string? ImageUrl { get; set; }
    
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string City { get; set; }

    [Required]
    public required string StateOrCountry { get; set; }
    public Boolean ProductsSold { get; set; }

    public List<Product> Products { get; set; } = new List<Product>();
    public List<Order> Orders { get; set; } = new List<Order>();
}