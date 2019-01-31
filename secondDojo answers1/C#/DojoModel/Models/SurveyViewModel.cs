using System.ComponentModel.DataAnnotations;
namespace DojoModel.Models
{
    public class SurveyViewModel
    {
        [Required]
        [
            MinLength(2, ErrorMessage = "Uh oh, not long enough!"), 
            MaxLength(15)
        ]
        public string Name { get; set; }

        [Required]
        public string Location { get ; set; }

        [Required]
        [
            MinLength(2, ErrorMessage = "Uh oh, not long enough!"), 
            MaxLength(15)
        ]
        [Display(Name="My FAV Language")]
        public string Language { get; set; }


        [
            MinLength(2, ErrorMessage = "Uh oh, not long enough!"), 
            MaxLength(15)
        ]
        public string Comment { get; set; }

    }
}