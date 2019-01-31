using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace Portfolio2.Controllers
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