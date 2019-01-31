using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            // Multidimensional array declaration
            // This example contains 3 arrays -- each of these is length 2 -- all initialized to zeroes.
            int count = 0;
            int[,] array2D = new int[10, 10];
                {
                    for (int x = 0; x < 10; x ++);
                    for (int y = 0; y < 10; y++);
                    
                    array2D[x, y] = count;
                    count ++;
                }
            // This is equivalent to:
            //  int [,] array2D = new int[3,2]  {  { 0,0 }, { 0,0 }, { 0,0 } }; 
         
            Console.WriteLine(array2D[0, 1]);   // prints 0
            Console.WriteLine(array2D[1, 9]);   // prints 0

            // array2D [x,y] = count;
            // count ++;
            
        }
    }
}
