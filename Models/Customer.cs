using System;
using System.Collections.Generic; // for List
using System.ComponentModel.DataAnnotations; // use for Required method

namespace Bangazon.Models;

public class Customer
{
    [Required]
    public string UserUid { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "Customer user name cannot be longer than 50 characters")]
    public string CustomerUserName { get; set; }
    public string ImageUrl { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
    public string FirstName { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string Address { get; set; }
    public int OrderId { get; set; }

    public User User { get; set; }
    public List<Order> Orders { get; set; }
    public List<CustomerPaymentMethod> PaymentMethods { get; set; }
}
