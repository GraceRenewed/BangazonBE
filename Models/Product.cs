using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // use for Required method

namespace Bangazon.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    public required string SellerUserUid { get; set; }
    public Seller? Seller { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Product name cannot be longer than 50 characters")]
    public required string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    public required string ImageUrl { get; set; }
}