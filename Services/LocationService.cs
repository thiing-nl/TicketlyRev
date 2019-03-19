using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Primitives;
using Screend.Entities.Location;
using Screend.Exceptions;
using Screend.Repositories;

namespace Screend.Services
{
    public interface ILocationService
    {
        ICollection<Location> GetAll();
        Location Get(int id);
        bool CheckExists(int id);
    } 
    
    public class LocationService : BaseService, ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public ICollection<Location> GetAll()
        {
            return _locationRepository.GetAll()
                .ToList();
        }

        public Location Get(int id)
        {
            var item = _locationRepository.GetByID(id);

            if (item == null)
            {
                throw new NotFoundException("Location does not exist."); 
            }
            
            return item;
        }

        public bool CheckExists(int id)
        {
            var item = _locationRepository.GetByID(id);

            if (item == null)
            {
                throw new NotFoundException("Location does not exist."); 
            }
            
            return true;
        }
    }
}