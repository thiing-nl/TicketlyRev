using Microsoft.AspNetCore.Mvc;

namespace Screend.Controllers
{
    public class UserController : Controller
    {

        #region GetRoutes
        
        public IActionResult Me()
        {
            return Ok();
        }

        #endregion
        
        #region PostRoutes
       
        public IActionResult Authenticate()
        {
            return Ok();
        }

        public IActionResult Register()
        {
            return Ok();
        }
        
        #endregion

    }
}