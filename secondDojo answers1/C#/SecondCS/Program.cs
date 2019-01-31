using System;

namespace SecondCS
{
    class Program
    {
        static void Main(string[] args)
        {




//  Modify the previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5
//  (Optional) If you used modulus in the last step, try doing the same without using it. Vice-versa for those who didn't!


//Create a Loop that prints all values from 1-255
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
//  Create a new loop that prints all values from 1-100 that are divisible by 3 or 5, but not both
            for (int i = 1; i < 101; i++)
            {
                if ( i % 3 == 0 || i % 5 == 0)

                Console.WriteLine(i);
            }
//  Modify the previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5
           for (int i = 1; i < 101; i++)
            {
                if ( i % 3 == 0 && i % 5 != 0){
                    Console.WriteLine("Fizz- multiple of 3 - " + i);
                }
                if ( i % 3 != 0 && i % 5 == 0){
                    Console.WriteLine("Buzz- multiple of 5 - " + i);
                }
                if ( i % 3 == 0 && i % 5 == 0){
                    Console.WriteLine("FizzBuzz-both - " + i);
                }
            }
        }
    }
}
