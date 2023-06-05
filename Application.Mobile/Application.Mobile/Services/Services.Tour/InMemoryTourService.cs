﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Application.Mobile.Services.Services.Tour
{
    public class InMemoryTourService : ITourService
    {
        private readonly List<Models.Tour> _tours = new List<Models.Tour>();
        public InMemoryTourService()
        {
            _tours.Add(new Models.Tour { TourName = "Clean code", Duration = "Robert C Martin", Description = "A book about good code", Image = "test", InSale = true, VideoTour = "test", Price = 1000 });
            _tours.Add(new Models.Tour { TourName = "Clean code", Duration = "Robert C Martin", Description = "A book about good code", Image = "test", InSale = true, VideoTour = "test", Price = 1000 });
            _tours.Add(new Models.Tour { TourName = "Clean code", Duration = "Robert C Martin", Description = "A book about good code", Image = "test", InSale = true, VideoTour = "test", Price = 1000 });
        }

        public Task AddTour(Models.Tour tour)
        {
            tour.TourId = ++_tours.Last().TourId;
            _tours.Add(tour);
            return Task.CompletedTask;
        }

        public Task DeleteTour(Models.Tour tour)
        {
            _tours.Remove(tour);
            return Task.CompletedTask;
        }

        public Task<Models.Tour> GetTour(int id)
        {
            var tour = _tours.FirstOrDefault(b => b.TourId == id);
            return Task.FromResult(tour);
        }

        public Task<IEnumerable<Models.Tour>> GetTours()
        {
            return Task.FromResult(_tours.AsEnumerable());
        }

        public Task SaveTour(Models.Tour tour)
        {
            _tours[_tours.FindIndex(b => b.TourId == tour.TourId)] = tour;
            return Task.CompletedTask;
        }
    }
}