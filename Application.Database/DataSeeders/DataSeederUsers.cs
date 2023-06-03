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
                    Username = "Studio",
                    Password = "Studio",
                    Age = 20,
                    IsPremiumMember = true,
                    Role = "Studio",
                    Fio = "Spiridonov",
                    DateOfBirth = dateOfBirth,
                    Phone = "79797979"
                }
            };
            modelBuilder.Entity<User>().HasData(Users);

            return modelBuilder;
        }
    }
}