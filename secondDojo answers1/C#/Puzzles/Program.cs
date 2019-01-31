using System;
using System.Collections.Generic;


namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a function called RandomArray() that returns an integer array
            // Create an array to hold integer values 0 through 9
            // List<int> nums = new List<int>();
            //     for(int i = 0; i< 10 ; i++)
            //     {
            //         nums.Add(i);
            //         Console.WriteLine(nums[i]);
            //     }   

            // Place 10 random integer values between 5-25 into the array
            
            // List<int> nums = new List<int>();
    //                 for(int i = 5; i< 25 ; i++)
    //                 {
    //                 // Random rand = new Random();
    //                 // for (int i = 0; i < nums.Length; i++)
    //                 {
    // //                 int y = rand.Next(nums.Length);
    // //                 string temp = nums[s];
    // //                 Names[y] = Names[x];
    // //                 Names[x] = temp;
    // //             }

            // Print the min and max values of the array




            // Print the sum of all the values


            //Build a function Names that returns an array of strings

            // Create an array with the values: Todd, Tiffany, Charlie, Geneva, Sydney
            // Shuffle the array and print the values in the new order
            // Return an array that only includes names longer than 5 characters


            // Dictionary<string,string> Names = new Dictionary<string,string>();
            // // Create an array with the values: Todd, Tiffany, Charlie, Geneva, Sydney
            // {
            // Names.Add("Name", "Todd");
            // Names.Add("Name", "Tiffany");
            // Names.Add("Name", "Charlie");
            // Names.Add("Name", "Geneva");
            // Names.Add("Name", "Sydney");

            // foreach (var entry in Names)
            // // foreach (KeyValuePair<string,string> entry in Names)
            // Console.WriteLine(entry.Key + " - " + entry.Value);
            // }

            // // Return an array that only includes names longer than 5 characters
            // {
            // if (string "Name" > int(5){
            // Console.WriteLine("Name is greater than 5 characters", {Name})
            // }
            // else (string "Name" <= int(5)){
            //     Console.WriteLine( )
            // }



    //         public static string[] Names()
    //         {
    //             string[] Names = { "Todd", "Tiffany", "Charlie", "Geneva", "Sydney" };
    //             Random rand = new Random();
    //             for (int i = 0; i < Names.Length; i++)
    //             {
    //                 int first = rand.Next(Names.Length);
    //                 string temp = Names[idx];
    //                 Names[first] = Names[x];
    //                 Names[x] = temp;
    //             }
    //             List<string> Five = new List<string>();
    //             foreach (var x in Names)
    //             {
    //                 Console.WriteLine(x);
    //                 if (x.Length > 5)
    //                 {
    //                     Five.Add(x);
    //                 }
    //             }

    //             foreach (var person in Five)
    //             {
    //                 Console.WriteLine(person);
    //             }
    //             return Five.ToArray();
    //         }
    //         static void Main(string[] args)
    //         {
    //             Names();


    // string[] myCars = new string[4] { "Mazda Miata", "Ford Model T", "Dodge Challenger", "Nissan 300zx"}; 
    // foreach (string car in myCars)
    // {
    // // We no longer need the index, because variable 'car' already contains each indexed value
    // Console.WriteLine("I own a {0}", car);
    // }

        Dictionary<string,string> profile = new Dictionary<string,string>();
        {
        //Almost all the methods that exists with Lists are the same with Dictionaries
        profile.Add("Name", "Speros");
        // profile.Add("Name", "Evan");
        // profile.Add("Name", "Amanda");

        profile.Add("Language", "PHP");
        // profile.Add("Language", "C#");
        // profile.Add("Language", "Python");
        }
        // profile.Add("Location", "Greece");
        // profile.Add("Location", "NYC");
        // profile.Add("Location", "LA");
        //can be used for ONE of the above - NOT ALL 
        // Console.WriteLine("Instructor Profile");
        // Console.WriteLine("Name - " + profile["Name"]);
        // Console.WriteLine("From - " + profile["Location"]);
        // Console.WriteLine("Favorite Language - " + profile["Language"]);

        //can be used for ALL the above
        //The var keyword takes the place of a type in type-inference
        foreach (KeyValuePair<string,string> entry in profile)
        {
        Console.WriteLine(entry.Key + " - " + entry.Value);
        }




            }
        }
    }
