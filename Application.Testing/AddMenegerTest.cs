using Application.Database;
using Application.Database.Models;
using Application.Desktop.Methods;

namespace Application.Testing
{
    [TestClass]
    public class AddMenegerTest
    {
        [TestMethod]
        public void AddMenedgerMethodTest()
        {
            TourAgencyContext db = new TourAgencyContext();

            TourOperator result = AddMenedgerMet.AddMenedgerMethod("Иванов Иван Иванович", 30, "Работает в гостинице", "image.jpg");

            Assert.IsNotNull(result);
            Assert.AreEqual("Иванов Иван Иванович", result.Fio);
            Assert.AreEqual(30, result.Age);
            Assert.AreEqual("Работает в гостинице", result.Resume);
            Assert.AreEqual("image.jpg", result.Image);
        }
    }
}