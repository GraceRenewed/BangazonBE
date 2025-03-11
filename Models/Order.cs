using System;
using System.Reflection; // use for DateTime
using System.ComponentModel.DataAnnotations; // use for DataType/DisplayFormat in date
using System.ComponentModel.DataAnnotations.Schema;

namespace Bangazon.Models;

public class Order
{
    public int Id { get; set; }

    [Required]
    public required string CustomerUserUid { get; set; }
    
    [Required]
    public required string SellerUserUid { get; set; }
    
    public int ProductId { get; set; }
    
    public int ProductTotal { get; set; }
    
    [Required]
    [DisplayFormat(DataFormatString = "{0:C}")]
    public required decimal OrderTotal { get; set; }
    
    [ForeignKey("PaymentMethod")]
    public int CustomerPaymentMethodId { get; set; }  // Which payment method was used

    public Boolean Open { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateCreated { get; set; }
    
    public Boolean Filled { get; set; }

    public Boolean Shipped { get; set; }
    
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? DateShipped {  get; set; }

    // Navigation properties
    public Customer? Customer { get; set; }
    public CustomerPaymentMethod? PaymentMethod { get; set; }
    public Seller? Seller { get; set; }
    public Product? Product { get; set; }
}
