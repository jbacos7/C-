using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using LoginRegistration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

public class HomeController : Controller
{
    private LRContext _context;

    public HomeController (LRContext context)
    {
        _context = context;
    }
 
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("login")]
        public IActionResult loginpage()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string loginemail, string loginpw)
        {
            var Hasher = new PasswordHasher<User>();
            User usercheck = _context.Users.SingleOrDefault(user => user.Email == loginemail);
            if (usercheck == null || 0 == Hasher.VerifyHashedPassword(usercheck, usercheck.Password, loginpw))
            {
                ViewBag.Message = "You could not be logged in. Please try again.";
                return View("Login");
            }
            else
            {
                var activeuser = _context.Users.SingleOrDefault(user => user.Email ==loginemail);
                HttpContext.Session.SetString("Loggedinuser", activeuser.FirstName + " " + activeuser.LastName);
                HttpContext.Session.SetInt32("UserId", usercheck.UserId);
                return RedirectToAction("Success");
            }
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult UserRegistration(RegisterViewModel adduser)
        {
            if(ModelState.IsValid)
            {
                User UserInDB = _context.Users.SingleOrDefault(user => user.Email == adduser.Email);
                if (UserInDB != null)
                {
                    ViewBag.Message = "This email already exists in the database.";
                    return View("Index", adduser);
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                User AddUserinDB = new User
                {
                    FirstName = adduser.FirstName,
                    LastName = adduser.LastName,
                    Email = adduser.Email,
                    Password = adduser.Password,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                AddUserinDB.Password = Hasher.HashPassword(AddUserinDB, AddUserinDB.Password);
                _context.Add(AddUserinDB);
                _context.SaveChanges();
                AddUserinDB = _context.Users.SingleOrDefault(user => user.Email == AddUserinDB.Email);

                var activeuser = _context.Users.SingleOrDefault(user => user.Email ==adduser.Email);
                HttpContext.Session.SetString("Loggedinuser", activeuser.FirstName + " " + activeuser.LastName);

                HttpContext.Session.SetInt32("UserId", AddUserinDB.UserId);
                return RedirectToAction ("Success");
            }
            else
            {
                return View("Index", adduser);
            }
        }
        
        [HttpGet]
        [Route("Success")]
        public IActionResult Success() 
        {
            ViewBag.Loggedinuser = HttpContext.Session.GetString("Loggedinuser");
            return View("Success");
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
