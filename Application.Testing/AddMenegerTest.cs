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

            TourOperator result = AddMenedgerMet.AddMenedgerMethod("������ ���� ��������", 30, "�������� � ���������", "image.jpg");

            Assert.IsNotNull(result);
            Assert.AreEqual("������ ���� ��������", result.Fio);
            Assert.AreEqual(30, result.Age);
            Assert.AreEqual("�������� � ���������", result.Resume);
            Assert.AreEqual("image.jpg", result.Image);
        }
    }
}