using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Screend.Entities.Location;
using Screend.Entities.LostItem;
using Screend.Filters;
using Screend.Models.LostItem;
using Screend.Services;

namespace Screend.Controllers
{
    [Route("api/lost-items")]
    [ServiceFilter(typeof(LocationFilter))]
    public class LostItemController : BaseController
    {
        private readonly ILostItemService _lostItemService;

        public LostItemController(ILostItemService lostItemService)
        {
            _lostItemService = lostItemService;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LostItemDTO>), StatusCodes.Status200OK)]
        public ActionResult GetLostItems()
        {
            var location = (Location) HttpContext.Items["Location"];
            var lostItems = _lostItemService.GetAll(location.Id);
            
            return Ok(Mapper.Map<LostItemDTO[]>(lostItems));
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<LostItemDTO>), StatusCodes.Status200OK)]
        public ActionResult GetLostItem(int id)
        {
            var lostItem = _lostItemService.GetById(id);
            
            return Ok(Mapper.Map<LostItemDTO>(lostItem));
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(LostItemDTO), StatusCodes.Status200OK)]
        public ActionResult CreateLostItem([FromBody] LostItemCreateUpdateDTO lostItemCreateUpdate)
        {
            var location = (Location) HttpContext.Items["Location"];
            var lostItem = _lostItemService.Create(lostItemCreateUpdate, location.Id);
            
            return Ok(Mapper.Map<LostItemDTO>(lostItem));
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LostItemDTO), StatusCodes.Status200OK)]
        public ActionResult UpdateLostItem(int id, [FromBody] LostItemCreateUpdateDTO lostItemCreateUpdate)
        {
            var lostItem = _lostItemService.Update(id, lostItemCreateUpdate);
            
            return Ok(Mapper.Map<LostItemDTO>(lostItem));
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public ActionResult DeleteLostItem(int id)
        {
            _lostItemService.Delete(id);
            
            return Ok();
        }
    }
}