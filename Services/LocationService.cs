using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Screend.Entities.Location;
using Screend.Repositories;

namespace Screend.Services
{
    public interface ILocationService
    {
        ICollection<Location> GetAll();
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
    }
}