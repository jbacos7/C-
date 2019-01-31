using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Restaurant.Models;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private RestContext _context;

    public HomeController (RestContext context)
    {
        _context = context;
    }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("AddReview")]
        public IActionResult AddReview(User user) {
            if(user.Date > DateTime.Now) {
                ModelState.AddModelError("Date", "Visit must be in the past.");
            }
            if(ModelState.IsValid) {
                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Review");
            }
            else {
                ViewBag.errors = ModelState.Values;
                return View("Index");
            }  
        }

        [HttpGet]
        [Route("Review")]
        public IActionResult AllReviews(){
            var userreviews=_context.Users.Where(review=>review.Id!=0).ToList();
            Console.WriteLine(userreviews);
            ViewBag.userreviews=userreviews;
            return View("Review");

    }
}