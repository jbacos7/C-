using System;
using System.Collections.Generic;

namespace Wizards
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Evan = new Human("Evan");
            Human Jason = new Human("Jason");
            Evan.Attack(Jason);
            Jason.Attack(Evan);
            Console.WriteLine("Evan's health is {0} and Jason's health is {1}. ", Evan.Health, Jason.Health);

            Wizard Amanda = new Wizard("Amanda");
            Ninja Natalie = new Ninja("Natalie");
            Samurai Jon = new Samurai("Jon");
            Samurai Lee = new Samurai ("Lee");
            Jon.death_blow(Amanda);
            Jon.death_blow(Natalie);
            Lee.death_blow(Jon);

            System.Console.WriteLine("*********");
            Console.WriteLine("Amanda's health is {0} and Natalie's health is {1}. ", Amanda.Health, Natalie.Health);
            Jason.Attack(Evan);            
            Lee.death_blow(Jon);
            Console.WriteLine("Jon's health is {0}.", Jon.Health );
            System.Console.WriteLine("*********");
            Jon.mediate(Jon);
            Console.WriteLine("Jon's health is {0}.", Jon.Health );


        }
    }
}
