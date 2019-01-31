using System.Collections.Generic;

namespace WeddingPlanner2.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Wedding> Weddings { get; set; }
        public List<Guest> Guests { get; set; }

        public User()
        {
            Guests = new List<Guest>();
            Weddings = new List<Wedding>();
    
        }

    }
}