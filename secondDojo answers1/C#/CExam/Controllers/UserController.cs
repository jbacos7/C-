using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using CExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using CExam.Data;

namespace CExam.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
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
        [Route("register")]
        public IActionResult registerpage()
        {
            return View("Register");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult loginpage()
        {
            return View("Login");
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string loginemail, string loginpw)
        {
            var Hasher = new PasswordHasher<User>();
            User usercheck = _context.Users.SingleOrDefault(user => user.Email == loginemail);

            if (usercheck == null || loginpw == null)
            {
                ViewBag.Message = "You could not be logged in. Please try again.";
                return View("Login");
            }
            else
            {
                if (0 == Hasher.VerifyHashedPassword(usercheck, usercheck.Password, loginpw))
                {
                    ViewBag.Message = "You could not be logged in. Please try again.";
                    return View("Login");
                }

                var activeuser = _context.Users.SingleOrDefault(user => user.Email == loginemail);
                HttpContext.Session.SetString("Loggedinuser", activeuser.FirstName + " " + activeuser.LastName);
                HttpContext.Session.SetInt32("UserId", usercheck.UserId);
                return RedirectToAction("Dashboard");
            }
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel adduser)
        {
            if (ModelState.IsValid)
            {
                User UserInDB = _context.Users.SingleOrDefault(user => user.Email == adduser.Email);
                if (UserInDB != null)
                {
                    ViewBag.Message = "This email already exists in the database.";
                    return View("Register", adduser);
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                User AddUserinDB = new User
                {
                    FirstName = adduser.FirstName,
                    LastName = adduser.LastName,
                    Email = adduser.Email,
                    Password = adduser.Password,
                };
                AddUserinDB.Password = Hasher.HashPassword(AddUserinDB, AddUserinDB.Password);
                _context.Add(AddUserinDB);
                _context.SaveChanges();
                AddUserinDB = _context.Users.SingleOrDefault(user => user.Email == AddUserinDB.Email);

                var activeuser = _context.Users.SingleOrDefault(user => user.Email == adduser.Email);
                HttpContext.Session.SetString("Loggedinuser", activeuser.FirstName + " " + activeuser.LastName);
                HttpContext.Session.SetInt32("UserId", AddUserinDB.UserId);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Register", adduser);
            }
        }

        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index");
            }

            {
                List<Act> AllActs = _context.Acts.Include(w => w.Joins).ThenInclude(g => g.User).OrderByDescending(g => g.Date).ToList();
                User loginuser = _context.Users.SingleOrDefault(a => a.UserId == UserId);

                ViewBag.loginuser = loginuser;
                ViewBag.Acts = AllActs;
                ViewBag.UserId = UserId;

                HttpContext.Session.SetInt32("UserId", loginuser.UserId);
                HttpContext.Session.SetString("UserName", loginuser.FirstName);
                ViewBag.Loggedinuser = HttpContext.Session.GetString("Loggedinuser");

                return View();
            }
        }

        [HttpGet]
        [Route("addnew")]
        public IActionResult AddActivity()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index");
            }
            TempData["UserId"] = UserId;
            return View("AddNew");
        }

        [HttpPost]
        [Route("AddNew")]
        public IActionResult CreateActivity(ActViewModel AddNewActivity, int UserId)
        {
            if (ModelState.IsValid)
            {
                Act thisactivity = new Act
                {
                    ActName = AddNewActivity.ActName,
                    ActTime = AddNewActivity.ActTime,
                    Date = AddNewActivity.Date,
                    ActDuration = AddNewActivity.ActDuration,
                    Description = AddNewActivity.Description,
                    User = _context.Users.SingleOrDefault(user => user.UserId == UserId)
                };
                _context.Add(thisactivity);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("AddNew");
            }
        }

        [HttpGet]
        [Route("act/show/{ActId}")]
        public IActionResult Activity(int ActId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index");
            }

            Act thisAct = _context.Acts
                .Include(w => w.Joins)
                .ThenInclude(a => a.User)
                .SingleOrDefault(p => p.ActId == ActId);
            ViewBag.ThisAct = thisAct;

            User loginuser = _context.Users.SingleOrDefault(a => a.UserId == UserId);

            ViewBag.loginuser = loginuser;
            ViewBag.UserId = UserId;

            HttpContext.Session.SetInt32("UserId", loginuser.UserId);
            HttpContext.Session.SetString("UserName", loginuser.FirstName);
            ViewBag.Loggedinuser = HttpContext.Session.GetString("Loggedinuser");

            return View();



        }



        [HttpGet]
        [Route("act/join/{ActId}")]
        public IActionResult JoinAct(int ActId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index");
            }
            Join newJoin = new Join
            {
                UserId = (int)HttpContext.Session.GetInt32("UserId"),
                ActId = ActId
            };

            User addtolist = _context.Users.SingleOrDefault(a => a.UserId == newJoin.UserId);
            addtolist.Joins.Add(newJoin);

            Act addguest = _context.Acts.SingleOrDefault(a => a.ActId == newJoin.ActId);
            addguest.Joins.Add(newJoin);

            Join going = _context.Joins.SingleOrDefault(p => p.UserId == (int)HttpContext.Session.GetInt32("UserId") && p.ActId == ActId);
            if (going == null)
            {
                // ViewBag.Guest = GuestLoggedIn;
                TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
                TempData["UserName"] = HttpContext.Session.GetString("UserName");
                _context.Add(newJoin);
                _context.SaveChanges();
                System.Console.WriteLine(newJoin.UserId);
            }
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("act/remove/{ActId}")]
        public IActionResult UnJoin(int ActId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index");
            }

            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            Join RemoveJoin = _context.Joins.SingleOrDefault(a => a.UserId == (int)HttpContext.Session.GetInt32("UserId") && a.ActId == ActId);
            if (RemoveJoin != null)
            {
                _context.Joins.Remove(RemoveJoin);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }


        [HttpGet]
        [Route("act/delete/{ActId}")]
        public IActionResult Delete(int ActId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index");
            }

            Act todelete = _context.Acts.SingleOrDefault(a => a.UserId == (int)HttpContext.Session.GetInt32("UserId") && a.ActId == ActId);
            if (todelete != null)
            {
                _context.Acts.Remove(todelete);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }








    }
}



