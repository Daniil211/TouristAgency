using Application.Database.Models;
using Application.Web.Client.Data.Repository;

namespace Application.Web.Client.Data.Repository
{
    public class MockRepository : IRepository
    {
        private List<Tour> _tours;
        private List<Transport> _transports;

        #region Implemented Method
        #region Tour
        public List<Tour> UpdateTour(Tour tour)
        {
            throw new NotImplementedException();
        }
        public List<Tour> RemoveTour(Tour tour)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region City
        public List<City> GetAllCity()
        {
            throw new NotImplementedException();
        }
        public bool CreateNewCity(City city)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Hotel
        public bool CreateNewHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }
        public List<Hotel> GetAllHotel()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Transport
        public bool CreateNewTransport(Transport transport)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region TourOperator

        

        public List<TourOperator> GetAllTourOperator()
        {
            throw new NotImplementedException();
        }
        public bool CreateNewTourOperator(TourOperator tourOperator)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Order
        public bool CreateNewOrder(Order order)
        {
            throw new NotImplementedException();
        }
        public List<Order> GetAllOrder()
        {
            throw new NotImplementedException();
        }
        public List<Order> RemoveOrder(Order order)
        {
            throw new NotImplementedException();
        }
        public List<Order> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region HotelsOfTour
        public bool CreateNewHotelsOfTour(HotelsOfTour hotelsOfTour)
        {
            throw new NotImplementedException();
        }
        public List<HotelsOfTour> GetAllHotelsOfTour()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region TransportOfTour
        public bool CreateNewTransportOfTour(TransportOfTour transportOfTour)
        {
            throw new NotImplementedException();
        }
        public List<TransportOfTour> GetAllTransportOfTour()
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        public bool EditTransport(Transport editedTransport)
        {
            var oldGenre = _transports.FirstOrDefault(x => x.TransportId.Equals(editedTransport.TransportId));

            if (oldGenre is not null)
            {
                oldGenre = editedTransport;
                return true;
            }
            else
                return false;
        }
        public List<Tour> GetAllTours() => _tours;
        public List<Transport> GetAllTransport() => _transports;
        public Transport GetTransportById(int id) => _transports.FirstOrDefault(x => x.TransportId.Equals(id));
        public Tour GetTourById(int id) => _tours.FirstOrDefault(x => x.TourId.Equals(id));
        public bool CreateNewTour(Tour tour)
        {
            if (tour is null)
                return false;

            tour.TourId = _tours.Max(x => x.TourId) + 1;
            _tours.Add(tour);
            return true;
        }
        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}