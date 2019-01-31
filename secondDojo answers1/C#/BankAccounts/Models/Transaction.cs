using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
  public class Transaction
  {
    public int TransactionId { get; set; }
    [Required]
    [RegularExpression(@"^\d+\.\d{0,2}$")]
    public Decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int UserId { get; set; }
    public User Accountholder { get; set; }
  }
}
