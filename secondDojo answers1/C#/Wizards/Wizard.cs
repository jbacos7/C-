using System;
using System.Collections.Generic;


namespace Wizards
{
    public class Wizard : Human
    {
        public Wizard(string name) : base (name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 25;
            Dexterity = 3;
            Health = 50;
        }
        public void heal (object target)
        {
            Wizard name = target as Wizard;
            if (name == null)
            {
                Console.WriteLine("Did not heal.");
            }
            else{
                name.Health += Intelligence * 10;
            }
        }
    }
}