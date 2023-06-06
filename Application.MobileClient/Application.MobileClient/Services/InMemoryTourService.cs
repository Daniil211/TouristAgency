using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.MobileClient.Models;


namespace Application.MobileClient.Services
{
    public class InMemoryTourService : ITourService
    {
        private readonly List<Tour> _tours = new List<Tour>();
        public Task AddTour(Tour tour)
        {
            tour.TourId = ++_tours.Last().TourId;
            _tours.Add(tour);
            return Task.CompletedTask;
        }

        public Task DeleteTour(Tour tour)
        {
            _tours.Remove(tour);
            return Task.CompletedTask;
        }

        public Task<Tour> GetTour(int id)
        {
            var tour = _tours.FirstOrDefault(b => b.TourId == id);
            return Task.FromResult(tour);
        }

        public Task<IEnumerable<Tour>> GetTours()
        {
            return Task.FromResult(_tours.AsEnumerable());
        }

        public Task SaveTour(Tour tour)
        {
            _tours[_tours.FindIndex(b => b.TourId == tour.TourId)] = tour;
            return Task.CompletedTask;
        }
    }
}
