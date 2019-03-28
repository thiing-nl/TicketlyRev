using System.Runtime.InteropServices;
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
            var parsed = int.TryParse(context.HttpContext.Request.Headers["X-Location-Id"], out var locationId);
            
            if (parsed && _locationService.CheckExists(locationId)) {
                context.HttpContext.Items.Add("Location", _locationService.Get(locationId));
                await next();
                return;
            }
            
           throw new ForbiddenException("You cannot perform this request without an Location provided!");
        }
    }
}