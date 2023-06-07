using Application.Database;
using Application.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Application.Desktop.Methods
{
    public class AddMenedgerMet
    {
        public static TourOperator AddMenedgerMethod(string name, int age, string res, string image)
        {
            TourAgencyContext db = new();

            var tourop = db.TourOperators.FirstOrDefault(x => x.Fio == name);
            if (tourop == null)
            {
                if (age >= 18 && age<=82)
                {
                    TourOperator t = new();
                    t.Fio = name;
                    t.Age = age;
                    t.Resume = res;
                    t.Image = image;
                    db.TourOperators.Add(t);
                    db.SaveChanges();
                    MessageBox.Show("Туроператор добавлен");
                    return t;
                }
                else
                {
                    MessageBox.Show("Некорректный возраст."); return null;
                }
              
            }
            else
            {
                MessageBox.Show("Такой туроператор уже существует.");
            }
            return null;
        }
    }
}
