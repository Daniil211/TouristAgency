﻿using Application.Database;
using Application.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows;

namespace Application.Desktop.Methods
{
    public class AddTourMet
    {
        public static Tour AddTourMeth(string name, string duration, decimal price, bool insale, string image, string descr)
        {
            TourAgencyContext db = new();

            var tour = db.Tours.FirstOrDefault(x => x.TourName == name);
            if (tour == null)
            {
                Tour t = new();
                t.TourName = name;
                t.Duration = duration;
                t.Price = price;
                t.InSale = insale;
                t.Image = image;
                t.Description = descr;
                t.Time = DateTime.Now;
                db.Tours.Add(t);
                db.SaveChanges();
                MessageBox.Show("Тур создан");
                return t;
            }
            else
            {
                MessageBox.Show("Такой тур уже существует. Придумайте новое название");
            }
            return null;
        }
    }
}
