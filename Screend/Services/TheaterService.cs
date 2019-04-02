using Screend.Repositories;

namespace Screend.Services
{
    public interface ITheaterService
    {
    }
    
    public class TheaterService : BaseService, ITheaterService
    {
        private readonly ITheaterRepository _theaterRepository;
        
        public TheaterService(ITheaterRepository theaterRepository)
        {
            _theaterRepository = theaterRepository;
        }
    }
}