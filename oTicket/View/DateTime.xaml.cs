using System;
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
    /// Логика взаимодействия для DateTime.xaml
    /// </summary>
    public partial class DateTime : Page
    {
        int IdDate; //получаем ид даты
        public DateTime()
        {
            InitializeComponent();
            Loaded += DateTime_Loaded;
        }

        private void DateTime_Loaded(object sender, RoutedEventArgs e)
        {
            using (scheduleTicket db = new scheduleTicket())
            {
                ListDay.ItemsSource = db.Days.ToList();
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (scheduleTicket db = new scheduleTicket())
            {
                foreach (Days item in e.AddedItems)
                {
                    IdDate = item.Id;
                }

                ListTime.ItemsSource = db.Times.ToList();
            }
        }

        private void ListView_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
