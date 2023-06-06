using Application.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Testing
{
    [TestClass]
    public class RegMetTests
    {
        [TestMethod]
        public void RegMethod_CreatesNewUser_ReturnsUser()
        {
            // Arrange
            var login = "testuser";
            var password = "testpassword";
            var fio = "Test User";
            var date = new DateTime(2000, 1, 1);
            var phone = "1234567890";
            var expectedUser = new User
            {
                Username = login,
                Role = "User",
                Password = password,
                IsPremiumMember = false,
                DateCreated = DateTime.Now,
                Fio = fio,
                DateOfBirth = date,
                Phone = phone,
                Age = ((int)(DateTime.Now - date).TotalDays) / 365
            };
            var db = new TourAgencyContext();

            // Act
            var actualUser = RegMet.RegMethod(login, password, fio, date, phone);

            // Assert
            Assert.IsNotNull(actualUser);
            Assert.AreEqual(expectedUser.Username, actualUser.Username);
            Assert.AreEqual(expectedUser.Role, actualUser.Role);
            Assert.AreEqual(expectedUser.Password, actualUser.Password);
            Assert.AreEqual(expectedUser.IsPremiumMember, actualUser.IsPremiumMember);
            Assert.AreEqual(expectedUser.DateCreated, actualUser.DateCreated);
            Assert.AreEqual(expectedUser.Fio, actualUser.Fio);
            Assert.AreEqual(expectedUser.DateOfBirth, actualUser.DateOfBirth);
            Assert.AreEqual(expectedUser.Phone, actualUser.Phone);
            Assert.AreEqual(expectedUser.Age, actualUser.Age);

            // Cleanup
            db.Users.Remove(actualUser);
            db.SaveChanges();
        }

        [TestMethod]
        public void RegMethod_ExistingUser_ReturnsNull()
        {
            // Arrange
            var login = "testuser";
            var password = "testpassword";
            var fio = "Test User";
            var date = new DateTime(2000, 1, 1);
            var phone = "1234567890";
            var db = new TourAgencyContext();
            var user = new User
            {
                Username = login,
                Password = password,
                Role = "User",
                Id = Guid.NewGuid()
            };
            db.Users.Add(user);
            db.SaveChanges();

            // Act
            var actualUser = RegMet.RegMethod(login, password, fio, date, phone);

            // Assert
            Assert.IsNull(actualUser);

            // Cleanup
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}