using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Testing
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Application.Desktop.Methods;
    using System;
    using System.IO;
    using System.Windows.Media.Imaging;

    namespace Application.Tests.Desktop.Methods
    {
        [TestClass]
        public class WorkWithImagesMetTests
        {
            [TestMethod]
            public void ConvertImgToBase64_ValidImage_ReturnsBase64String()
            {
                // Arrange
                var image = "test.png";
                var expectedBase64String = "iVBORw0KGgoAAAANSUhEUgAAAAUA";
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.png");

                // Act
                var actualBase64String = WorkWithImagesMet.ConvertImgToBase64(filePath);

                // Assert
                Assert.IsNotNull(actualBase64String);
                Assert.AreEqual(expectedBase64String, actualBase64String.Substring(0, expectedBase64String.Length));

                // Cleanup
                File.Delete(filePath);
            }

            [TestMethod]
            public void ConvertImgToBase64_InvalidImage_ThrowsArgumentNullException()
            {
                // Arrange
                var image = "invalid.png";
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "invalid.png");

                // Act and Assert
                Assert.ThrowsException<ArgumentNullException>(() => WorkWithImagesMet.ConvertImgToBase64(filePath));

                // Cleanup
                File.Delete(filePath);
            }
        }
    }
}