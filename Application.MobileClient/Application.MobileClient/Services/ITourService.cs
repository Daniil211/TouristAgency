using System.Collections.Generic;
using System.Threading.Tasks;
using Application.MobileClient.Models;

namespace Application.MobileClient.Services
{
    public interface ITourService
    {
        Task<IEnumerable<Tour>> GetTours();
        Task<Tour> GetTour(int id);
        Task AddTour(Tour tour);
        Task SaveTour(Tour tour);
        Task DeleteTour(Tour tour);
    }
}
