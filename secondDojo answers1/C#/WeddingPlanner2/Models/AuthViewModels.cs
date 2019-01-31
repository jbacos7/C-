using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner2.Models
{
    public class AuthViewModel
    {
        public Login LoginForm { get; set;}
        public RegisterViewModel RegForm { get; set; }
    }
}