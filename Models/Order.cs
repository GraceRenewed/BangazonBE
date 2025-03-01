using System;
using System.Reflection;

namespace Bangazon.Models;

public class Order
{
    public int Id { get; set; }
    public int CustomerUid { get; set; }
    public int SellerUid { get; set; }
    public int ProductId { get; set; }
    
    public int ProductTotal { get; set; }
    public decimal OrderTotal { get; set; }
    public int CustomerPaymentMethodId { get; set; }  // Which payment method was used

    public Boolean Open { get; set; }
    public Boolean Filled { get; set; }
    public Boolean Shipped { get; set; }

    // Navigation properties
    public Customer Customer { get; set; }
    public CustomerPaymentMethod PaymentMethod { get; set; }
    public Seller Seller { get; set; }
    public Product Product { get; set; }
}
