using System;
using System.Collections.Generic;


namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print all the numbers from 1 to 255.
            // for (var i=0; i < 256; i ++ ){
            //     Console.WriteLine(i);
            // }
            
            // Print odd numbers between 1-255
            // for (var i=1; i < 256; i= i+2){
            //     Console.WriteLine(i);
            // }
            
            // Print the numbers from 0 to 255, but this time, also print the sum of the numbers that have been printed so far. For example, your output should be something like this:
            // int sum = 0;
            // for (var i= 1; i < 256; i++)
            // {
            //     sum = sum + i;
            //     Console.WriteLine(sum);
            // }
                
            // Given an array X, say [1,3,5,7,9,13], write a function that would iterate through each member of the array and print each value on the screen. Being able to loop through each member of the array is extremely important.

            // int sum = 0;
            // for (var i= 1; i < 256; i++)
            // {
            //     sum = sum + i;
            //     Console.WriteLine(sum);
            // }


            // public static void PrintArray(params int[] vals)
            // {
            // foreach (var val in vals)
            // {
            //     Console.WriteLine(val);
            // }
            // }

            // Write a function that takes any array and prints the maximum value in the array. Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), or even a mix of positive numbers, negative numbers and zero.

            // public static void FindMax(params int[] maxNum)
            // {
            // int max = maxNum[0];
            // foreach (var i in maxNum)
            // {
            //     if (i > max)
            //     {
            //         max = i;
            //     }
            // }
            // Console.WriteLine("Max: " + max);
            // }

            // Write a function that takes an array and prints the AVERAGE of the values in the array. For example, for an array [2, 10, 3], your program should print an average of 5. Again, make sure you come up with a simple base case and write instructions to solve that base case first, then test your instructions for other complicated cases. You can use a count function with this assignment.
            // public static void Avg(params int[] nums)
            // {
            // int sum = 0;
            // foreach (var num in nums)
            // {
            //     sum = sum + num;
            // }
            // Console.WriteLine("avg: " + (sum / (nums.Length)));
            // }

            // Write a function that creates an array 'y' that contains all the odd numbers between 1 to 255. When the program is done, 'y' should have the value of [1, 3, 5, 7, ... 255].
            // public static void OddArray(){   
            // var y = new List<int> ();
            // for (int i = 1; i < 256; i++)
            // {
            //     if (i % 2 == 1)
            //     {
            //         y.Add(i);
            //     }
            // }
            // Console.WriteLine("array y: ");
            // foreach (var i in y)
            // {
            //     Console.Write( + i +", ");
            // }

            // Write a function that takes an array and returns the number of values in that array whose value is greater than a given value y. For example, if array = [1, 3, 5, 7] and y = 3. After your program is run it will return 2 (since there are two values in the array that are greater than 3).
            // public static void GetY(int y, params int[] CompareVals)
            // {
            // int count = 0;
            // foreach (var i in CompareVals)
            // {
            //     if (CompareVals > y)
            //     {
            //         count++;
            //     }  
            // }
            // Console.WriteLine($"Number is greater than {y}: {count}");
            // }
            
            // Given any array x, say [1, 5, 10, -2], create a function that multiplies each value in the array by itself. When the program is done, the array x should have values that have been squared, say [1, 25, 100, 4].

            // public static void Square(params int[] x)
            // {
            // for (int i = 0; i < x.length; i++)
            // {
            //     x[i] = x[i] * x[i];
            // }
            // Console.WriteLine("Squared Values: ");
            // foreach (var val in x)
            // {
            // Console.WriteLine(val + ", ");
            // }
            // Console.WriteLine("");
            // }

            // Given any array x, say [1, 5, 10, -2], create a function that replaces any negative number with the value of 0. When the program is done, x should have no negative values, say [1, 5, 10, 0].
            // public static void NoNeg(params int[] x)
            // {
            // for (int i = 0; i < x.length; i++)
            // {
            //     if (x[i] < 0)
            //     {
            //         x[i] = 0;
            //     }
            // }
            // Console.WriteLine("No negative numbers:");
            // foreach (var i in x)
            // {
            //     Console.WriteLine(i + ", ");
            // }
            // }

            // Given any array x, say [1, 5, 10, -2], create a function that prints the maximum number in the array, the minimum value in the array, and the average of the values in the array.

            // public static void MinMaxAvg(params int[] x)
            // {
            // GetMax(x);
            // GetAvg(x);
            // int min = x[0];
            // for (int i = 1; i < x.Length; i++)
            // {
            //     if (x[i] < min)
            //     {
            //         min = x[i];
            //     }
            // }
            // Console.WriteLine("minimum: " + min);
            // Console.WriteLine("maximum: " + max);
            // Console.WriteLine("average: " + avg);
            // }

            // Given any array x, say [1, 5, 10, 7, -2], create a function that shifts each number by one to the front and adds '0' to the end. For example, when the program is done,  if the array [1, 5, 10, 7, -2] is passed to the function, it should become [5, 10, 7, -2, 0].
            // public static void ShiftArray(List<int> shift)
            // {
            // shift.RemoveAt(0);
            // shift.Add(0);
            // foreach (var i in shift)
            // {
            //     Console.WriteLine(shift + ", ");
            // }
            // Console.WriteLine(" [ ] ");

            // Write a function that takes an array of numbers and replaces any negative number with the string 'Dojo'. For example, if array x is initially [-1, -3, 2] your function should return an array with values ['Dojo', 'Dojo', 2].
            public static void NegString(List<object> numbers)
            {
            for (int i = 0; i < numbers.Count; i++)
            {
                if ((int)numbers[i] < 0)
                {
                    numbers[i] = "Dojo";
                }
            }
            foreach (var i in numbers)
            {
                Console.WriteLine(i);
            }
            // Console.WriteLine();

        }
    }
}