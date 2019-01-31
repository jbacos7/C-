using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models

{
    public class SurveyViewModel
    {
        [Required]
        [MinLength(4, ErrorMessage = "Must be at least 4 characters."), MaxLength(15)]
        public string FirstName { get; set; }

///////////////////////////////////////////////

        [Required]
        [MinLength(4, ErrorMessage = "Must be at least 4 characters."), MaxLength(15)]
        public string LastName { get; set; }


///////////////////////////////////////////////
        [Required]
        [Range(0, 150)] 
        public int Age { get; set; }


///////////////////////////////////////////////

        [EmailAddress]
        public string Email { get; set; }

///////////////////////////////////////////////
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password is required and must be at least 8 characters."), MaxLength(20)]
        public string Password { get; set; }

        
    }
}