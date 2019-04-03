using System;
using System.Collections.Generic;
using System.Linq;
using Screend.Data;
using Screend.Entities.Schedule;

namespace Screend.Repositories
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        ICollection<Schedule> GetSchedulesByDateRangeAndLocationId
            (DateTime startDate, DateTime endDate,int locationId);
        ICollection<Schedule> GetSchedulesByDateRangeAndLocationIdAndMovieId
            (DateTime startDate, DateTime endDate,int locationId, int movieId);
    }
    
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        private DatabaseContext _context;
        
        public ScheduleRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<Schedule> GetSchedulesByDateRangeAndLocationId
            (DateTime startDate, DateTime endDate, int locationId)
        {
            return Get(it => it.Time > startDate && it.Time < endDate && it.LocationId == locationId).ToArray();
        }

        public ICollection<Schedule> GetSchedulesByDateRangeAndLocationIdAndMovieId
            (DateTime startDate, DateTime endDate, int locationId, int movieId)
        {
            return Get(it => 
                    it.Time > startDate && it.Time < endDate && it.LocationId == locationId && it.MovieId == movieId
                ).OrderBy(it => it.Time).ToArray();
        }
    }
}