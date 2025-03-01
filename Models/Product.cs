using System;

namespace Bangazon.Models;

public class Product
{
    [Required]
    public UserId { get; set; }
    

    public User User { get; set; }
}
