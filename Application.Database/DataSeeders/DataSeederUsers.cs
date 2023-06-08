using Application.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace Application.Persistence.DataSeeders
{
    public class DataSeederUsers
    {
        public static ModelBuilder SeedData(ModelBuilder modelBuilder)
        {
            DateTime dateOfBirth = new DateTime(1990, 10, 31);
            List<User> Users = new()
            {
                new()
                {
                    Id = 1,
                    Username = "User1",
                    Password = "User1",
                    Age = 19,
                    IsPremiumMember = false,
                    Role = "User",
                    Fio = "Spiridonov",
                    DateOfBirth = dateOfBirth,
                    Phone = "79797979"

                },
                new()
                {
                    Id = 2,
                    Username = "User2",
                    Password = "User2",
                    Age = 10,
                    IsPremiumMember = true,
                    Role = "User",
                    Fio = "Spiridonov",
                    DateOfBirth = dateOfBirth,
                    Phone = "79797979"
                },
                new()
                {
                    Id = 3,
                    Username = "User3",
                    Password = "User3",
                    Age = 20,
                    IsPremiumMember = true,
                    Role = "Admin",
                    Fio = "Spiridonov",
                    DateOfBirth = dateOfBirth,
                    Phone = "79797979"
                },
                new()
                {
                    Id = 4,
                    Username = "Admin",
                    Password = "Admin",
                    Age = 20,
                    IsPremiumMember = true,
                    Role = "Admin",
                    Fio = "Spiridonov",
                    DateOfBirth = dateOfBirth,
                    Phone = "79797979"
                }
            };
            List<City> Cities = new()
            {
                new()
                {
                    CityId = 1,
                    CityName = "Moscow"
                },
                new()
                {
                    CityId = 2,
                    CityName = "Kazan"
                },
                new()
                {
                    CityId = 3,
                    CityName = "Los-Angeles"
                },
                new()
                {
                    CityId = 4,
                    CityName = "Miami"
                }
            };
            List<Hotel> Hotels = new()
            {
                new()
                {
                    HotelId = 1,
                    HotelName = "Almaz",
                    CountOfStars = 2,
                    CityId = 1
                },
                new()
                {
                    HotelId = 2,
                    HotelName = "Plaza",
                    CountOfStars = 5,
                    CityId = 2
                },
                new()
                {
                    HotelId = 3,
                    HotelName = "Rent",
                    CountOfStars = 5,
                    CityId = 4
                },
                new()
                {
                    HotelId = 4,
                    HotelName = "Summer",
                    CountOfStars = 4,
                    CityId = 3
                }
            };
            List<Transport> Transports = new()
            {
                new()
                {
                   TransportId = 1,
                   TypeOfTransport = "AirPlane"
                },
                new()
                {
                    TransportId = 2,
                    TypeOfTransport = "Bus"
                },
                new()
                {
                    TransportId = 3,
                    TypeOfTransport = "Auto"
                },
                new()
                {
                    TransportId = 4,
                    TypeOfTransport = "Travel"
                },
                new()
                {
                    TransportId = 5,
                    TypeOfTransport = "Metro"
                },
                new()
                {
                    TransportId = 6,
                    TypeOfTransport = "Spaceship"
                },
                new()
                {
                    TransportId = 7,
                    TypeOfTransport = "Ship"
                }

            };
            modelBuilder.Entity<Transport>().HasData(Transports);
            modelBuilder.Entity<Hotel>().HasData(Hotels);
            modelBuilder.Entity<User>().HasData(Users);
            modelBuilder.Entity<City>().HasData(Cities);
            return modelBuilder;
        }
    }
}