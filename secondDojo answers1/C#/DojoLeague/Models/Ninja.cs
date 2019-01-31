using System.ComponentModel.DataAnnotations;
namespace DojoLeague.Models
{
    public class Ninja
    {
        //create the schema in sequel- ninja table has id, name, other info needed
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(3, ErrorMessage = "Ninja Name must be at least 3 characters.")]
        public string NinjaName { get; set; }

        [Required]
        public int NinjaLevel { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Description must be at least 8 characters.")]
        public string NinjaDescription { get; set; }

        [Required]
        public int dojo_id { get; set; }

        public Dojo dojo { get; set; }
    }
}