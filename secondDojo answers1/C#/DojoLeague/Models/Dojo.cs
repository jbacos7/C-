using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DojoLeague.Models


{
    public class Dojo
    {
        //create the schema in sequel- dojo table has id, name, other info needed
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(3, ErrorMessage = "Dojo Name must be at least 3 characters.")]
        public string DojoName { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Location must be at least 5 characters.")]
        public string DojoLocation { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Description must be at least 8 characters.")]
        public string DojoDescription { get; set; }
        
        public IEnumerable<Ninja> ninjas { get; set; }

        public Dojo() {
            ninjas = new List<Ninja>();
        }
      
    }
}