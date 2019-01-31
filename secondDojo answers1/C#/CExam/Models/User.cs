using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CExam.Models
{
    public class User
    {
    [Key]
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Act> Acts {get; set;}
    public List<Join> Joins {get; set;}
    public User()
        {
            Acts = new List<Act>();
            Joins = new List<Join>();
        }

    }
  
}