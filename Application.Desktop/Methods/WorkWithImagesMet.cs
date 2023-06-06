using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Application.Desktop.Methods
{
    public class WorkWithImagesMet
    {
        public static string ConvertImgToBase64(string image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("Invalid");
            }
            BitmapImage bitmapImage = new BitmapImage(new Uri(image));
            using (var memoryStream = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
    }
}