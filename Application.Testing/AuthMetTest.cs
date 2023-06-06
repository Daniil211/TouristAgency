using Application.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Testing
{
    [TestClass]
    public class AuthMetTests
    {
        [TestMethod]
        public void AuthMethod_ExistingUser_ReturnsUser()
        {
            // Arrange
            var login = "testuser";
            var password = "testpassword";
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
            var actualUser = AuthMet.AuthMethod(login, password);

            // Assert
            Assert.IsNotNull(actualUser);
            Assert.AreEqual(user.Id, actualUser.Id);
            Assert.AreEqual(user.Username, actualUser.Username);
            Assert.AreEqual(user.Role, actualUser.Role);

            // Cleanup
            db.Users.Remove(user);
            db.SaveChanges();
        }

        [TestMethod]
        public void AuthMethod_NonExistingUser_ReturnsNull()
        {
            // Arrange
            var login = "testuser";
            var password = "testpassword";

            // Act
            var actualUser = AuthMet.AuthMethod(login, password);

            // Assert
            Assert.IsNull(actualUser);
        }

        [TestMethod]
        public void AuthMethod_IncorrectPassword_ReturnsNull()
        {
            // Arrange
            var login = "testuser";
            var password = "testpassword";
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
            var actualUser = AuthMet.AuthMethod(login, "wrongpassword");

            // Assert
            Assert.IsNull(actualUser);

            // Cleanup
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}