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
    /// Логика взаимодействия для MyOffers.xaml
    /// </summary>
    public partial class MyOffers : Page
    {
        int IdOffer;
        public MyOffers()
        {
            InitializeComponent();
            Loaded += MyOffers_Loaded;
        }

        private void MyOffers_Loaded(object sender, RoutedEventArgs e)
        {
            using (scheduleTicket db = new scheduleTicket())
            {
                ListView.ItemsSource = db.Offer.Where(x => x.Authorization.Id == Authorizations.IdUser).Select(x =>new  {x.Id, x.Doctors.Hospitals, x.Doctors.Proffessions, x.Doctors, x.Days, x.Times }).ToList();
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (dynamic item in e.AddedItems)
            {
                IdOffer = item.Id;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (scheduleTicket db = new scheduleTicket())
                {
                    Offer del = db.Offer.Where(x => x.Id == IdOffer).FirstOrDefault();
                    db.Offer.Remove(del);
                    db.SaveChanges();
                }
                MainWindow.Naviget = new MyOffers();
            }
            catch(Exception)
            {
                MessageBox.Show("У вас нет заказов");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.Naviget = new UserPage();
        }
    }
}
