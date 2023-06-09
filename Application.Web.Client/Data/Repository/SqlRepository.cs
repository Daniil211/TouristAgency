﻿using Application.Database;
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

        public List<User> GetAllUsers()
        {
            var users = _db.Users.ToList();
            return users;
        }

        public List<TourOperator> GetAllTourOperator()
        {
            var tourOperator = _db.TourOperators.ToList();
            return tourOperator;
        }

        public List<City> GetAllCity()
        {
            var city = _db.Cities.ToList();
            return city;
        }
        public List<Order> GetAllOrder()
        {
            var order = _db.Orders.ToList();
            return order;
        }
        public List<TransportOfTour> GetAllTransportOfTour()
        {
            var transportOfTours = _db.TransportOfTours.ToList();
            return transportOfTours;
        }
        public List<HotelsOfTour> GetAllHotelsOfTour()
        {
            var hotelsOfTours = _db.HotelsOfTours.ToList();
            return hotelsOfTours;
        }
        public bool CreateNewTransportOfTour(TransportOfTour transportOfTour)
        {
            if (transportOfTour is null)
                return false;
            _db.Add(transportOfTour);
            _db.SaveChanges();
            return true;
        }
        public bool CreateNewHotel(Hotel hotel)
        {
            if (hotel is null)
                return false;
            _db.Add(hotel);
            _db.SaveChanges();
            return true;
        }
        public bool CreateNewOrder(Order order)
        {
            if (order is null)
                return false;
            _db.Add(order);
            _db.SaveChanges();
            return true;
        }
        public bool CreateNewHotelsOfTour(HotelsOfTour hotelsOfTour)
        {
            if (hotelsOfTour is null)
                return false;
            _db.Add(hotelsOfTour);
            _db.SaveChanges();
            return true;
        }
        public List<Hotel> GetAllHotel()
        {
            var hotel = _db.Hotels.ToList();
            return hotel;
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
            var transport = _db.Transports.FirstOrDefault(x => x.TransportId == id);
            return transport;
        }
        public List<Order> UpdateOrder(Order order)
        {
            _db.Update(order);
            _db.SaveChanges();
            var orders = _db.Orders.ToList();
            return orders;
        }
        public List<Order> RemoveOrder(Order order)
        {
            _db.Remove(order);
            _db.SaveChanges();
            var orders = _db.Orders.ToList();
            return orders;
        }
        public bool EditTransport(Transport editedTransport)
        {
            if(editedTransport is null)
                return false;
            _db.Transports.Update(editedTransport);
            _db.SaveChanges();
            return true;
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
