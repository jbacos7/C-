using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace newproject.Controllers
{
    public class ControllerContact : Controller 
    {
        [HttpGet]
        [Route ("contact")]
        public string Contact()
        {
            return "Hello, you did it! This is the contacts page.";
        }

        [HttpGet]
        [Route ("profile")]
        public string Profile()
        {
            return "Hello, you did it! This is the profile page.";
        }

    }
    
}