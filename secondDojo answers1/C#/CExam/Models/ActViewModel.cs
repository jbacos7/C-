using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace CExam.Models
{
    public class ValidDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d >= DateTime.Now;
        }
    }
    public class ActViewModel
    {
        [Required (ErrorMessage= "You need to name your activity.")]
        [MinLength(2, ErrorMessage= "Activity must be more than 2 characters.")]
        public string ActName {get; set;}
        [Required]
        [ValidDate (ErrorMessage="Time must be in the future; specify AM or PM.")]
        public string ActTime {get; set;}
        [Required]
        [ValidDate (ErrorMessage="Date must be in the future.")]
        public DateTime Date {get; set;}    
        [Required]
        public int ActDuration {get; set;} 
        [Required]
        [MinLength(10, ErrorMessage= "Description must be more than 10 characters.")]
        public string Description {get; set;}

    }

}