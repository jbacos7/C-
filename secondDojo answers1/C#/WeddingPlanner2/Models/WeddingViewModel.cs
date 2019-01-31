using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WeddingPlanner2.Models
{
    public class ValidDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d >= DateTime.Now;
        }
    }
    public class WeddingViewModel
    {
        // [Required (ErrorMessage= "You need to marry someone.")]
        // [MinLength(2, ErrorMessage= "You need to marry someone.")]
        public string WedderOne { get; set; }
        // [Required (ErrorMessage= "You need to marry someone.")]
        // [MinLength(2, ErrorMessage= "You need to marry someone.")]
        public string WedderTwo { get; set; }
        // [Required]
        // [ValidDate(ErrorMessage = "Date must be in the future")]
        public DateTime Date { get; set; }
        // [Required]
        // [MinLength(2, ErrorMessage= "You need to add a location.")]
        public string Address { get; set; }
    }
}