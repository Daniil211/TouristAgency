using Application.Database;
using Application.Database.Models;

namespace Application.Web.Client.Data.Repository
{
    public class SqlRepository : IRepository
    {
        private readonly TourAgencyContext _db;
        public SqlRepository(TourAgencyContext db)
        {
            _db = db;
        }
        public List<Tour> GetAllTours()
        {
            var tours = _db.Tours.ToList();
            return tours;
        }

        public List<City> GetAllCity()
        {
            var city = _db.Cities.ToList();
            return city;
        }

        public bool CreateNewTour(Tour tour)
        {
            if (tour is null)
                return false;
            _db.Add(tour);
            _db.SaveChanges();
            return true;
        }
        public bool CreateNewTourOperator(TourOperator tourOperator)
        {
            if (tourOperator is null)
                return false;
            _db.Add(tourOperator);
            _db.SaveChanges();
            return true;
        }

        public bool CreateNewTransport(Transport transport)
        {
            if(transport is null)
                return false;
            _db.Add(transport);
            _db.SaveChanges();
            return true;
        }
        public bool CreateNewCity(City city)
        {
            if (city is null)
                return false;
            _db.Add(city);
            _db.SaveChanges();
            return true;
        }

        public Tour GetTourById(int id)
        {
            var tour = _db.Tours.FirstOrDefault(x => x.TourId == id);
            return tour;
        }

        public List<Transport> GetAllTransport()
        {
            var genres = _db.Transports.ToList();
            return genres;
        }

        public Transport GetTransportById(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditTransport(Transport editedTransport)
        {
            if(editedTransport is null)
                return false;
            _db.Transports.Update(editedTransport);
            _db.SaveChanges();
            return true;
        }

        public List<TourOperator> GetAllTourOperators()
        {
            var developers = _db.TourOperators.ToList();
            return developers;
        }
        public List<Tour> RemoveTour(Tour tour)
        {
            _db.Remove(tour);
            _db.SaveChanges();
            var tours = _db.Tours.ToList();
            return tours;
        }
        public List<Tour> UpdateTour(Tour tour)
        {
            _db.Update(tour);
            _db.SaveChanges();
            var tours = _db.Tours.ToList();
            return tours;
        }
    }
}
