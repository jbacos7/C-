using System;
using Human;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Tim = new Human("Tim");
            System.Console.WriteLine(Tim);
            Human Zach = new Human("Zach");

            Tim.Attack (Zach);

            System.Console.WriteLine (Tim.Name);
            System.Console.WriteLine (Zach.Health);
        
        }
    }
}
