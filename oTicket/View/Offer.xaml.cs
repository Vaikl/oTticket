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
    /// Логика взаимодействия для Offer.xaml
    /// </summary>
    public partial class Offer : Page
    {
        public Offer()
        {
            InitializeComponent();
            this.Loaded += offers_Loaded;
        }

        private void offers_Loaded(object sender, RoutedEventArgs e)
        {
            using (scheduleEntities db = new scheduleEntities())
            {
                ListView.ItemsSource = db.Hospitals.ToList();
            }
        }
    }
}
