using System;
using Microsoft.AspNetCore.Mvc;
using Screend.Exceptions;

namespace Screend.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleException(Exception exception)
        {
            switch (exception)
            {
                case NotFoundException _:
                    return NotFound(exception.Message);
                case BadRequestException _:
                    return BadRequest(exception.Message);
                case ForbiddenException _:
                    return StatusCode(403, exception.Message);
                default:
                    return StatusCode(500, exception.Message);
            }
        }
    }
}