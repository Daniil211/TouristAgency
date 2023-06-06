using Application.Database;
using Application.Database.Models;


namespace Application.Testing
{
    [TestClass]
    public class AddMenedgerMetTest
    {
        [TestMethod]
        public void AddMenedgerMethodTest()
        {
            // Создаем экземпляр класса TourAgencyContext
            TourAgencyContext db = new TourAgencyContext();

            // Вызываем метод AddMenedgerMethod
            TourOperator result = AddMenedgerMet.AddMenedgerMethod("Иванов Иван Иванович", 30, "Работает в гостинице", "image.jpg");

            // Проверяем, что результат соответствует ожидаемому
            Assert.IsNotNull(result);
            Assert.AreEqual("Иванов Иван Иванович", result.Fio);
            Assert.AreEqual(30, result.Age);
            Assert.AreEqual("Работает в гостинице", result.Resume);
            Assert.AreEqual("image.jpg", result.Image);
        }
    }
}