using System;
using DojoValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace DojoValidation.Controllers

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

        
        }
    }
}
