using Application.Database.Models;

namespace Application.Web.Client.Data.Repository
{
    public interface IRepository
    {
        List<Tour> GetAllTours();
        List<TourOperator> GetAllTourOperator();
        List<Transport> GetAllTransport();
        List<City> GetAllCity();
        List<Order> GetAllOrder();
        List<TransportOfTour> GetAllTransportOfTour();
        List<HotelsOfTour> GetAllHotelsOfTour();
        bool CreateNewTransportOfTour(TransportOfTour transportOfTour);
        bool CreateNewHotel(Hotel hotel);
        List<Hotel> GetAllHotel();
        bool CreateNewTour(Tour tour);
        bool CreateNewOrder(Order order);
        bool CreateNewHotelsOfTour(HotelsOfTour hotelsOfTour);
        bool CreateNewTransport(Transport transport);
        bool CreateNewCity(City city);
        bool CreateNewTourOperator(TourOperator tourOperator);
        Tour GetTourById(int id);
        Transport GetTransportById(int id);
        List<Tour> RemoveTour(Tour tour);
        List<Tour> UpdateTour(Tour tour);
        List<Order> RemoveOrder(Order order);
        List<Order> UpdateOrder(Order order);
        bool EditTransport(Transport editedTransport);
    }
}
