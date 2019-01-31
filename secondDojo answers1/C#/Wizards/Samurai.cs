using System;
using System.Collections.Generic;

namespace Wizards
{
    public class Samurai : Human
    {    
        public Samurai (string name) : base (name)
        {
            Health = 200;
        }

        public void death_blow (object subject)
        {
            if (subject is Human)
            {
                Human victim = subject as Human;
                if (victim.Health < 50)
                {
                    victim.Health = 0;
                } 
                else
                {
                    this.Attack(victim);
                }
            }
        }
        public void mediate (object subject)
        {
            if (subject is Samurai)
            {
                Samurai victim = subject as Samurai;
                {
                    victim.Health = 100;
                }
            }
        }
    
    }
}