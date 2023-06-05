using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Mobile.Services.Services.Tour
{
    public interface ITourService
    {
        Task<IEnumerable<Models.Tour>> GetTours();
        Task<Models.Tour> GetTour(int id);
        Task AddTour(Models.Tour tour);
        Task SaveTour(Models.Tour tour);
        Task DeleteTour(Models.Tour tour);
    }
}
