using System;
using System.ComponentModel.DataAnnotations;

namespace CExam.Models
{
    public class Join
    {
        [Key]
        public int JoinId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ActId { get; set; }
        public Act Act { get; set; }

    }
}