using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using QuotingDojo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using System.Data;
using MySql.Data.MySqlClient;



namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
	[HttpGet]
	[Route("")]
    public IActionResult Index()
    {
            return View();
    }

	[HttpPost]
	[Route("quotes")]
    public IActionResult Process(string nameinput, string quoteinput)
        {
            DbConnector.Execute($"INSERT INTO post(Name, Quote, created_at, updated_at) VALUES ('{nameinput}','{quoteinput}', NOW(), NOW());");
            var result = DbConnector.Query("SELECT * FROM post");
            ViewBag.display = result;
            return View("Quotes");

		}
    }
}