using System;
using System.Collections.Generic; // for List
using System.ComponentModel.DataAnnotations; // use for Required method

namespace Bangazon.Models;

public class Customer
{
    [Key]
    public required string UserUid { get; set; }
    
    [Required]
    [StringLength(50, ErrorMessage = "Customer user name cannot be longer than 50 characters")]
    public required string CustomerUserName { get; set; }
    public string? ImageUrl { get; set; }
    
    [Required]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
    public required string FirstName { get; set; }
    
    [Required]
    [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]
    public required string LastName { get; set; }
    
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public int Zip { get; set; }


    // public User User { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();
    public List<CustomerPaymentMethod> PaymentMethods { get; set; } = new List<CustomerPaymentMethod>();
}
