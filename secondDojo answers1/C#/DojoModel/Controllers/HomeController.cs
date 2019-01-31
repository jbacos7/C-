using System;
using DojoModel.Models;
using Microsoft.AspNetCore.Mvc;
namespace DojoModel.Controllers

{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route ("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost ("")]
        public IActionResult Process(SurveyViewModel submission)
        {       
            if(ModelState.IsValid)
            {
                ViewBag.Name = submission.Name;
                ViewBag.Language = submission.Language;
                ViewBag.Location = submission.Location;
                ViewBag.Comment = submission.Comment;

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
