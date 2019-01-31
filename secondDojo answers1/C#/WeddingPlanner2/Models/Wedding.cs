using System;
using System.Collections.Generic;

namespace WeddingPlanner2.Models
{
    public class Wedding
    {
        ////wedding properties
        public int WeddingId { get; set; }
        public string WedderOne { get; set; }
        public string WedderTwo { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public List<Guest> Guests { get; set; }

        ///foreign keys
        public User User { get; set; }
        public int UserId { get; set; }

        public Wedding()
        {
            Guests = new List<Guest>();
                        
        }
    }
}