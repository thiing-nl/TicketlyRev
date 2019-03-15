using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Screend.Exceptions;
using Screend.Services;

namespace Screend.Filters
{
    public class LocationFilter : IAsyncActionFilter
    {
        private readonly ILocationService _locationService; 
        
        public LocationFilter(ILocationService locationService)
        {
            _locationService = locationService;
        }
        
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("X-Location-Id"))
            {
                var resultContext = await next();
            }
            else
            {
                throw new ForbiddenException("You cannot perform this request without an Location provided!");
            }
        }
    }
}