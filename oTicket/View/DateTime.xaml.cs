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
       static int IdDate; //получаем ид даты
       static int IdTime; //получаем ид время
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
            ListTime.Items.Clear();
            using (scheduleTicket db = new scheduleTicket())
            {
                foreach (Days item in e.AddedItems)
                {
                    IdDate = item.Id;
                }

                foreach (Times item in db.Times)
                {
                        if ( item.Offer.Select(x=>x.IdDays).Contains(IdDate) == false || item.Offer.Select(x => x.IdDoctors).Contains(Offers.IdDoctors) == false)
                            ListTime.Items.Add(item);
                }
               
            }
        }

        private void ListView_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            using (scheduleTicket db = new scheduleTicket())
            {
                foreach (Times item in e.AddedItems)
                {
                    IdTime = item.Id;
                }
                db.Offer.Add(new Offer {
                    IdUser = Authorizations.IdUser,
                    IdDoctors = Offers.IdDoctors,
                    IdDays = DateTime.IdDate,
                    IdTime = DateTime.IdTime});
                db.SaveChanges();
                MainWindow.Naviget = new UserPage();
                MessageBox.Show("Талон заказан");
            }
        }
    }
}
