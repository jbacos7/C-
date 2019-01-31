using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace RazorFun.Controllers
{
    public class HomeController : Controller 
    {
        [HttpGet]
        [Route ("")]
        public IActionResult Index()
        {
            return View("Index");
        }
    }
    
}