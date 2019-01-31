using System;
using FormSubmission.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormSubmission.Controllers

{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route ("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost ("Result")]
        public IActionResult Process(SurveyViewModel submission)
        {
            if(ModelState.IsValid)
            {
                ViewBag.FirstName = submission.FirstName;
                ViewBag.LastName = submission.LastName;
                ViewBag.Age = submission.Age;
                ViewBag.Email = submission.Email;
                ViewBag.Password = submission.Password;

                // return RedirectToAction("Result");
                return View("Result");
            }

            else{
                ViewBag.error = "There was an error! Try again.";
                return View("Index");
            }

            Console.WriteLine(submission);
        }

        // [HttpGet ("result")]
        // public IActionResult result () {
        //     ViewBag.Name = 
        // }
        // ]
        
    }
}
