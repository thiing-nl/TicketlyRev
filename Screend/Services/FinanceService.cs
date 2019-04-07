using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Screend.Controllers;
using Screend.Entities.Location;
using Screend.Models.Finance;
using Screend.Models.Schedule;
using Screend.Repositories;

namespace Screend.Services
{
    public interface IFinanceService
    {
        FinanceMovieDetailDTO GetFinanceWeekDetail(DateTime date, int locationId);
        double GetTurnover(int movieId, int locationId);
    }
    
    public class FinanceService : BaseService, IFinanceService
    {
        private IScheduleService _scheduleService;
        private ILocationMovieRepository _locationMovieRepository;

        public FinanceService(IScheduleService scheduleService, ILocationMovieRepository locationMovieRepository)
        {
            _scheduleService = scheduleService;
            _locationMovieRepository = locationMovieRepository;
        }
        
        public FinanceMovieDetailDTO GetFinanceWeekDetail(DateTime date, int locationId)
        {
            var schedules = _scheduleService.GetByWeek(date, locationId)
                .Select(ScheduleController.MapSchedule)
                .ToArray();
            var total = 0.0;

            foreach (var schedule in schedules)
            {
                var locationMovie = _locationMovieRepository.GetByMovieIdAndLocationId(schedule.Movie.Id, locationId);

                var scheduleTotal = 0.0;
                foreach (var order in locationMovie.Orders)
                {
                    var parsed = double.TryParse(order.Amount, out double result);

                    if (parsed)
                    {
                        scheduleTotal += result;
                    }
                }
                
                schedule.Turnover = scheduleTotal;
                total += scheduleTotal;
            }
            
            return new FinanceMovieDetailDTO
            {
                Turnover = total,
                Schedules = schedules
            };
        }

        public double GetTurnover(int movieId, int locationId)
        {
            var locationMovie = _locationMovieRepository.GetByMovieIdAndLocationId(movieId, locationId);

            var total = 0.0;
            foreach (var order in locationMovie.Orders)
            {
                var parsed = double.TryParse(order.Amount, out double result);

                if (parsed)
                {
                    total += result;
                }
            }

            return total;
        }
    }
}