using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using BankAccounts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

public class HomeController : Controller
{
    private BankContext _context;

    public HomeController (BankContext context)
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
                HttpContext.Session.SetInt32("UserId", usercheck.UserId);
                return RedirectToAction("Account", "Bank", new { accountNum = HttpContext.Session.GetInt32("UserId")});
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
                HttpContext.Session.SetInt32("UserId", AddUserinDB.UserId);
                return RedirectToAction ("Account", "Bank", new { accountNum = HttpContext.Session.GetInt32("UserId")});
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
            return View("Success");
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }



        [HttpGet]   
        [Route("account/{accnumber}")]
        public IActionResult Account(int accnumber)
        {
              // if (accnumber != (int)HttpContext.Session.GetInt32("UserId"))
              //   {
              //     HttpContext.Session.Clear();
              //     return RedirectToAction("Login", "Register");
              //   }
            List<Transaction> MyTransactions = _context.Transactions.Where(transaction => transaction.UserId == accnumber).OrderByDescending(transaction => transaction.CreatedAt).ToList();
            ViewBag.MyTransactions = MyTransactions;
            Console.WriteLine(ViewBag.MyTransactions.Count);
            ViewBag.Balance = 0;
            foreach (Transaction trans in MyTransactions)
            {
                ViewBag.Balance += trans.Amount;
            }
            if (ViewBag.Balance <= 0)
            {
                ViewBag.Minimum = 0;
            } 
            else
            {
                ViewBag.Minimum = 0 - ViewBag.Balance;
            }
            ViewBag.Accountholder = _context.Users.SingleOrDefault(user => user.UserId == accnumber).FirstName;
            return View();
            } 
        }      
            [HttpPost]
            [Route("Transact")]
            public IActionResult TransactsA(double Amount)
            {
              Console.WriteLine($"The amount received from the transaction form is {Amount}.");
              User Transactor = _context.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("UserId"));
              double balance = 0;
              List<Transaction> MyTransactions = _context.Transactions.Where(transaction => transaction.UserId == Transactor.UserId).ToList();
              foreach (Transaction trans in MyTransactions)
              {
                balance += (double)trans.Amount;
              }
              if (balance + Amount >= 0 && Transactor != null)
              {
                // new transaction
                Transaction NewTransaction = new Transaction {
                  Amount = (decimal)Amount,
                  CreatedAt = DateTime.Now,
                  UpdatedAt = DateTime.Now,
                  UserId = Transactor.UserId
                };
                _context.Transactions.Add(NewTransaction);
                _context.SaveChanges();
                return RedirectToAction("Account", new { accountNum = HttpContext.Session.GetInt32("UserId")});
              }
              else
              {
                // return error message
                return View("Account");
              }
            }
        