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
    public class RegMet
    {
        public static User RegMethod(string login, string password, string fio, DateTime date, string phone)
        {
            try
            {
                TourAgencyContext db = new();

                var user = db.Users.FirstOrDefault(x => x.Username == login);
                if (user == null)
                {
                    User u = new();
                    u.Username = login;
                    u.Role = "User";
                    u.Password = password;
                    u.IsPremiumMember = false;
                    u.DateCreated = DateTime.Now;
                    u.Fio = fio;
                    u.DateOfBirth = date;
                    u.Phone = phone;
                    u.Age = ((int)(DateTime.Now - date).TotalDays) / 365;
                    db.Users.Add(u);
                    db.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно");
                    return u;
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже существует. Придумайте новый логин"); return null;
                }
            }
            catch {MessageBox.Show("Ошибка сервера"); return null; }
          
        
        }
    }
}
