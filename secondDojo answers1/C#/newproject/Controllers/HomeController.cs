using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace newproject.Controllers
{
    public class HomeController : Controller 
    {
        [HttpGet]
        [Route ("")]
        public string Index()
        {
            return "Hello, you did it! This is the index page.";
        }

    }
    
}