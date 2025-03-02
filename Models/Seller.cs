using Microsoft.Win32;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class Seller
{
    [Required]
    public string UserUid { get; set; }
    [Required]
    public string SellerUserName { get; set; }
    public string ImageUrl { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string City { get; set; }
    public string StateOrCountry { get; set; }
    public string ProductId {  get; set; }
    public Boolean ProductsSold {  get; set; }

    public User User { get; set; }
    public List<Product> Products { get; set; }