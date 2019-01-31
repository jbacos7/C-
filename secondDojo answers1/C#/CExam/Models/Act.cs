using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CExam.Models
{
    public class Act
    {
        [Key]
        ///activity properties
        public int ActId {get; set;}
        public string ActName {get; set;}
        public string ActTime {get; set;}
        public DateTime Date {get; set;}

        public int ActDuration {get; set;}
        public string Description {get; set;}
        public List<Join> Joins {get; set;}

        ///FKs
        public User User {get; set;}
        public int UserId {get; set;}

        public Act()
        {
            Joins = new List<Join>();
                        
        }


    }
}