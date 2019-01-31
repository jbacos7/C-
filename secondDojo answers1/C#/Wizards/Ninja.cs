using System;
using System.Collections.Generic;


namespace Wizards
{
    public class Ninja : Human
    {    
        public Ninja (string name) : base (name)
        {
            Dexterity = 175;
        }

        public void get_away (object subject)
        {
            if (subject is Ninja)
            {
                Ninja victim = subject as Ninja;
                victim.Health -= 15;
            }
        }
    }
}