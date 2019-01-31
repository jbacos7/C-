using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using TheWall.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TheWall.Data;

namespace TheWall.Controllers
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
        public IActionResult Register(RegViewModel adduser)
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
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                ViewBag.AllMessages = _context.Messages
                    .Include(post => post.User)
                    .OrderByDescending(post => post.CreatedAt)
                    .Include(post => post.Comments)
                    .ThenInclude(comment => comment.User)
                    .ToList();
                int? logId = HttpContext.Session.GetInt32("UserId");
                ViewBag.LoggedUser = _context.Users.SingleOrDefault(user => user.UserId == logId);
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Route("PostMessage")]
        public IActionResult postamessage(Message message)
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                Message NewMessage = new Message
                {
                    MessageText = message.MessageText,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserId = (int)HttpContext.Session.GetInt32("UserId")
                };
                _context.Messages.Add(NewMessage);
                _context.SaveChanges();
                ViewBag.AllMessages = _context.Messages
                  .Include(post => post.User)
                  .OrderByDescending(post => post.CreatedAt)
                  .Include(post => post.Comments)
                    .ThenInclude(thisComment => thisComment.User)
                  .ToList();
                int? logId = HttpContext.Session.GetInt32("UserId");
                ViewBag.LoggedUser = _context.Users.SingleOrDefault(user => user.UserId == logId);
                ModelState.Clear();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Route("PostComment")]
        public IActionResult postacomment(string CommentText, int MessageId)
        {
            Console.WriteLine("Message ID is: " + MessageId);
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                Comment NewComment = new Comment
                {
                    CommentText = CommentText,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    MessageId = MessageId,
                    UserId = (int)HttpContext.Session.GetInt32("UserId")
                };
                _context.Comments.Add(NewComment);
                _context.SaveChanges();
                ViewBag.AllMessages = _context.Messages
                  .Include(post => post.User)
                  .OrderByDescending(post => post.CreatedAt)
                  .Include(post => post.Comments)
                    .ThenInclude(thisComment => thisComment.User)
                  .ToList();
                int? logId = HttpContext.Session.GetInt32("UserId");
                ViewBag.LoggedUser = _context.Users.SingleOrDefault(user => user.UserId == logId);
                ModelState.Clear();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

    }
}

