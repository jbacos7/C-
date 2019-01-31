using System.ComponentModel.DataAnnotations;
namespace DojoValidation.Models

{
    public class SurveyViewModel
    {
        [Required]
        [ MinLength(3, ErrorMessage = "Must be at least 3 characters."), MaxLength(15) ]
        public string Name { get; set; }

///////////////////////////////////////////////

        [Required]
        public string Location { get ; set; }

///////////////////////////////////////////////

        [Required]
        [MinLength(3, ErrorMessage = "Must be at least 3 characters."), MaxLength(15)]
        [Display (Name = "Favorite Language : ")]
        public string Language { get; set; }

///////////////////////////////////////////////

        
        [MinLength(7, ErrorMessage = "Must be at least 7 characters."), MaxLength(30)]
        public string Comment { get; set; }

        
    }
}