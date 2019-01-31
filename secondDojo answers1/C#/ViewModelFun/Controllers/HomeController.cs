using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using ViewModelFun.Models;
namespace ViewModelFun.Controllers

{
    public class HomeController : Controller 
    {
        [HttpGet]
        [Route ("")]
        public IActionResult Index()
        {

            ViewData["Index"] = "This is the homepage";
            Index thisIndex = new Index()
            {
            message = "This is a message from Home Controller."
            };
            // Console.WriteLine($"Message class message is: {thisIndex.message}");
            return View(thisIndex);
        }

        [HttpGet]
        [Route ("number")]
        public IActionResult Numbers()
        {
            ViewData["Numbers"] = "Hi , here are some numbers: ";
            Numbers number = new Numbers()
            {
                nums =  new int[] {0,20,40,60,80,100}
            };
            // Console.WriteLine($"Array of numbers : {number.nums}");
            return View(number);
        }

        [HttpGet]
        [Route ("user")]

        public IActionResult User()
        {
            ViewData["User"] = "Hello, here is a user: ";
            User user = new User()
            {
                thisuser = "Mickey Mouse"
            };
            return View(user);
        }

        [HttpGet]
        [Route ("users")]

         public IActionResult Users()
        {
            ViewData["Message"] = "Here are some of the users : ";
            Users users = new Users()
            {
                listofusers = new List<string>{ "Donald Duck", "Minnie Mouse", "Daisy", "Goofy", "Pluto" }
            };
            // System.Console.WriteLine($"Users class is: {users.listofusers}");
            return View(users);
        }
    }
}