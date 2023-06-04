﻿using Application.Database.Models;

namespace Application.Web.Client.Data.Repository
{
    public interface IRepository
    {
        List<Tour> GetAllTours();
        List<Transport> GetAllTransport();
        List<City> GetAllCity();
        List<Order> GetAllOrder();
        bool CreateNewHotel(Hotel hotel);
        List<Hotel> GetAllHotel();
        bool CreateNewTour(Tour tour);
        bool CreateNewOrder(Order order);
        bool CreateNewTransport(Transport transport);
        bool CreateNewCity(City city);
        bool CreateNewTourOperator(TourOperator tourOperator);
        Tour GetTourById(int id);
        Transport GetTransportById(int id);
        List<Tour> RemoveTour(Tour tour);
        List<Tour> UpdateTour(Tour tour);
        bool EditTransport(Transport editedTransport);
        List<TourOperator> GetAllTourOperators();
    }
}
