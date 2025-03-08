using System;
using System.ComponentModel.DataAnnotations; // use for Required method

namespace Bangazon.Models;

public class Product
{   
    public int Id {  get; set; }
    [Required]
    public string SellerUserUid { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "Product name cannot be longer than 50 characters")]
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    // public User User { get; set; }
}
