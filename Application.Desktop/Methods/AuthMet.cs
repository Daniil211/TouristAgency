﻿using Application.Database.Models;
using Application.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Application.Desktop.Methods
{
    public class AuthMet
    {
        public static User AuthMethod(string login, string password)
        {
            TourAgencyContext db = new();

            var user = db.Users.FirstOrDefault(x => x.Username == login);
          
            if (user != null)
            {
                if (user.Password == password)
                {
                    if (user.Role == "Admin")
                    {
                        MessageBox.Show("Админ");
                        AdminWindow aw = new();
                        aw.Show();
                        return user;
                    }
                    else if(user.Role == "User")
                    {
                        MessageBox.Show("Клиент");
                        MainWindow mw = new();
                        mw.Show();
                        return user;
                    }
                }
                else
                {
                    MessageBox.Show("Пароль неверный");
                }
                return null;
            }
            else
            {
                MessageBox.Show("Пользователя с таким логином не существует");
            }
            return null;
        }
    }
}
