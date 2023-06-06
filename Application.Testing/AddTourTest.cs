using Application.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Database.Models;

namespace Application.Testing
{
    //[TestClass]
    //public class AddTourMetTests
    //{
    //    [TestMethod]
    //    public void AddTourMethod_CreatesNewTour_ReturnsTour()
    //    {
    //        // Arrange
    //        var name = "Test Tour";
    //        var duration = "1 day";
    //        var price = 100m;
    //        var insale = true;
    //        var image = "test.jpg";
    //        var descr = "Test description";
    //        var expectedTour = new Tour
    //        {
    //            TourName = name,
    //            Duration = duration,
    //            Price = price,
    //            InSale = insale,
    //            Image = image,
    //            Description = descr,
    //            Time = DateTime.Now
    //        };
    //        var db = new TourAgencyContext();

    //        // Act
    //        var actualTour = AddTourMet.AddTourMethod(name, duration, price, insale, image, descr);

    //        // Assert
    //        Assert.IsNotNull(actualTour);
    //        Assert.AreEqual(expectedTour.TourName, actualTour.TourName);
    //        Assert.AreEqual(expectedTour.Duration, actualTour.Duration);
    //        Assert.AreEqual(expectedTour.Price, actualTour.Price);
    //        Assert.AreEqual(expectedTour.InSale, actualTour.InSale);
    //        Assert.AreEqual(expectedTour.Image, actualTour.Image);
    //        Assert.AreEqual(expectedTour.Description, actualTour.Description);
    //        Assert.AreEqual(expectedTour.Time, actualTour.Time);

    //        // Cleanup
    //        db.Tours.Remove(actualTour);
    //        db.SaveChanges();
    //    }

    //    [TestMethod]
    //    public void AddTourMethod_ExistingTour_ReturnsNull()
    //    {
    //        // Arrange
    //        var name = "Test Tour";
    //        var duration = "1 day";
    //        var price = 100m;
    //        var insale = true;
    //        var image = "test.jpg";
    //        var descr = "Test description";
    //        var db = new TourAgencyContext();
    //        var tour = new Tour
    //        {
    //            TourName = name,
    //            Duration = duration,
    //            Price = price,
    //            InSale = insale,
    //            Image = image,
    //            Description = descr,
    //            Time = DateTime.Now
    //        };
    //        db.Tours.Add(tour);
    //        db.SaveChanges();

    //        // Act
    //        var actualTour = AddTourMet.AddTourMethod(name, duration, price, insale, image, descr);

    //        // Assert
    //        Assert.IsNull(actualTour);

    //        // Cleanup
    //        db.Tours.Remove(tour);
    //        db.SaveChanges();
    //    }
    //}
}

