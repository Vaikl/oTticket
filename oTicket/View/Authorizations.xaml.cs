﻿using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace oTicket.View
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorizations : Page
    {
      public  static int IdUser;
        public Authorizations()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (scheduleTicket db = new scheduleTicket())
                {
                    foreach (Authorization item in db.Authorization)
                    {
                        if (item.Number == Convert.ToInt32(NumberBox.Text) && item.Password == PasswordBox.Text)
                        {
                            IdUser = item.Id;
                             MainWindow.Naviget = new UserPage();  
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
