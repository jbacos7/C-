using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
  public class RegisterViewModel
  {
    [Required]
    [MinLength(2)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "Password and password confirmation fields must match.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
  
  }
}
