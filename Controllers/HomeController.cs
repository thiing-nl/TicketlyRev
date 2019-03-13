using Microsoft.AspNetCore.Mvc;

namespace Screend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
