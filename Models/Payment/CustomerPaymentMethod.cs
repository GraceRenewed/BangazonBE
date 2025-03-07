using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class CustomerPaymentMethod
{
    public int Id { get; set; }
    [Required]
    public string CustomerUserUid { get; set; }  // Foreign key

    public PaymentType PaymentMethod { get; set; }  // Enum for payment type

    public string Details { get; set; }  // last 4 digits of card, ApplePay token

    // Navigation property (helps with EF Core relationships)
    public Customer Customer { get; set; }
}
