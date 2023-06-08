﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Application.Database;
using Application.Desktop.Methods;
using Azure;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Desktop
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        TourAgencyContext db;
        public RegWindow()
        {
            InitializeComponent();
            db = new TourAgencyContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {  //здесь обработчик регистрации
            try
            {
                if (login_tb.Text != "" && pass_tb.Text != "" && pass2_tb.Text != "" && fio_tb.Text != "" && date_tb.Text != "" && phone_tb.Text != "")
                {
                    for (int i = 0; i < login_tb.Text.Length; i++)
                    {
                        char ch = Convert.ToChar(login_tb.Text.Substring(i, 1));
                        if (ch == ' ')
                        { MessageBox.Show("Введен пробел в поле логин. Невозможно зарегистрироваться"); return; }
                    }
                    for (int i = 0; i < pass_tb.Text.Length; i++)
                    {
                        char ch = Convert.ToChar(pass_tb.Text.Substring(i, 1));
                        if (ch == ' ')
                        { MessageBox.Show("Введен пробел в поле пароль. Невозможно зарегистрироваться"); return; }
                    }
                    for (int i = 0; i < fio_tb.Text.Length; i++)
                    {
                        char ch = Convert.ToChar(fio_tb.Text.Substring(i, 1));
                        if (ch == ' ')
                        { MessageBox.Show("Введен пробел в поле ФИО. Невозможно зарегистрироваться"); return; }
                    }
                    for (int i = 0; i < date_tb.Text.Length; i++)
                    {
                        char ch = Convert.ToChar(date_tb.Text.Substring(i, 1));
                        if (ch == ' ')
                        { MessageBox.Show("Введен пробел в поле дата рождения. Невозможно зарегистрироваться"); return; }
                    }
                    for (int i = 0; i < phone_tb.Text.Length; i++)
                    {
                        char ch = Convert.ToChar(phone_tb.Text.Substring(i, 1));
                        if (ch == ' ')
                        { MessageBox.Show("Введен пробел в поле телефон. Невозможно зарегистрироваться"); return; }
                    }
                    for (int i = 0; i < Convert.ToString(phone_tb.Text).Length; i++)
                    {
                        char ch = Convert.ToChar(Convert.ToString(phone_tb.Text).Substring(i, 1));
                        if (ch >= '0' && ch <= '9')
                        {
                            continue;
                        }
                        else
                        { MessageBox.Show("Введите номер в числовом формате"); return; }
                    }
                    if (pass_tb.Text == pass2_tb.Text)
                    {
                        if (pass_tb.Text.Length < 3)
                        {
                            MessageBox.Show("Пароль должен содержать не менее 3 символов");
                            return;
                        }
                        if (DateTime.ParseExact(date_tb.Text, "dd.MM.yyyy", null) < new DateTime(1941, 1, 1))
                        {
                            MessageBox.Show("Дата не может быть меньше 1941 года");
                            return;
                        }
                        else if (DateTime.ParseExact(date_tb.Text, "dd.MM.yyyy", null) > new DateTime(2005, 1, 1))
                        {
                            MessageBox.Show("Дата не может быть больше 2005");
                            return;
                        }                        
                        RegMet.RegMethod(login_tb.Text, pass_tb.Text, fio_tb.Text, DateTime.ParseExact(date_tb.Text, "dd.MM.yyyy", null), phone_tb.Text);
                    }
                    else
                    {
                        MessageBox.Show("Повторите пароль правильно");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
            catch
            {
                MessageBox.Show("Введите дату в таком формате: день.месяц.год . Например: 01.01.2001");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //здесь переход на вход
            AuthWindow aw = new();
            this.Close();
            aw.Show();
        }
    }
}
