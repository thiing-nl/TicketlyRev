using System;
using Microsoft.AspNetCore.Mvc;
using Screend.Exceptions;
using Screend.Services;

namespace Screend.Controllers
{
    [Route("api/users")]
    public class UserController : BaseController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #region GetRoutes
        
        [HttpGet("me")]
        public IActionResult Me()
        {
            return Ok();
        }

        #endregion
        
        #region PostRoutes
       
        [HttpPost("authenticate")]
        public IActionResult Authenticate()
        {
            try
            {
                var user = _userService.Authenticate("Test", "test123");
                return Ok(user);
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }
        }

        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok();
        }
        
        #endregion

    }
}