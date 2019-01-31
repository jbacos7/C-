using System.ComponentModel.DataAnnotations;
namespace LostWoods.Models

{
    public class Woods
    {
        //create the schema in sequel- dojo table has id, name, other info needed
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(3, ErrorMessage = "Trail Name must be at least 3 characters.")]
        public string Name { get; set; }

        [Required]
        [Range(0,5000, ErrorMessage = "Trail length must be between 0 - 5000.")]
        public int Length { get; set; }

        [Required]
        [Range(-500,1500, ErrorMessage = "Please enter elevation change between -500 and 1500")]
        public int Elevation { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Trail description must be at least 10 characters.")]
        public string Description { get; set; }

        [Required]
        [Range(-180, 180, ErrorMessage = "Latitude between -180 and 180 degrees.")]
        public float Latitude { get; set; }

        [Required]
        [Range(-180, 180, ErrorMessage = "Longitude between -180 and 180 degrees.")]
        public float Longitude { get; set; }

    }
}