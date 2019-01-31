using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string ReviewerName { get; set; }
        [Required(ErrorMessage = "Restaurant name is required.")]

        public string RestaurantName { get; set; }        
        [Required]
        [MinLength(10, ErrorMessage = "Review must be at least 10 characters.")]
        public string Review { get; set; }
                
        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Stars are required.")]
        public int Stars { get; set; }

    
    }
}