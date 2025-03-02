using System;
// using System.ComponentModel; // use annotation in enum
using System.Reflection; // use for DateTime
using System.ComponentModel.DataAnnotations; // use for DataType/DisplayFormat in date

namespace Bangazon.Models;

public class Order
{
    public int Id { get; set; }
    public int CustomerUid { get; set; }
    public int SellerUid { get; set; }
    public int ProductId { get; set; }
    
    public int ProductTotal { get; set; }
    
    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal OrderTotal { get; set; }
    public int CustomerPaymentMethodId { get; set; }  // Which payment method was used

    public Boolean Open { get; set; }
    [DateType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Created { get; set; }
    
    public Boolean Filled { get; set; }

    public Boolean Shipped { get; set; }
    [DateType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Shipped {  get; set; }

    // Navigation properties
    public Customer Customer { get; set; }
    public CustomerPaymentMethod PaymentMethod { get; set; }
    public Seller Seller { get; set; }
    public Product Product { get; set; }
}
