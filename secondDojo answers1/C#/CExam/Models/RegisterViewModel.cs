using System.ComponentModel.DataAnnotations;

namespace CExam.Models
{
    public class RegisterViewModel
    {
    
    [Required]
    [MinLength(2, ErrorMessage = "First name must be at least 2 characters and letters only.")]
    [RegularExpression(@"^[a-zA-z]+$")]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Last name must be at least 2 characters and letters only.")]
    [RegularExpression(@"^[a-zA-z]+$")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters, and contain at least 1 letter, 1 number, and 1 special character.")]
    [RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z])(?=.*[\W_]).{3,}$")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "Password and password confirmation fields must match.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
  }
}
