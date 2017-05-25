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
        int value; // счетчик нажатия на элемент ListView
        int IdHospitals; // получает ид выбранной поликлиники
        int IdProffessions; // получает ид выбранной професии
        int IdDoctors; // получает ид выбранного доктора
        public Offer()
        {
            InitializeComponent();
            this.Loaded += offers_Loaded;
            value = 1;
        }

        private void offers_Loaded(object sender, RoutedEventArgs e)
        {
            using (scheduleTicket db = new scheduleTicket())
            {
                ListView.ItemsSource = db.Hospitals.ToList();
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (scheduleTicket db = new scheduleTicket())
            {
             
                switch (value)
                {
                    case 1:
                        foreach(Hospitals item in e.AddedItems)
                        {
                            IdHospitals = item.Id;
                        }
                        TextValue.Text = IdHospitals.ToString();
                        ListView.ItemsSource = db.Proffessions.ToList();
                        value += 1;
                        break;
                    case 3:
                        foreach (Proffessions item in e.AddedItems)
                        {
                            IdProffessions = item.Id;
                        }
                        ListView.ItemsSource = db.Doctors.Where(x => x.IdHospitals == IdHospitals && x.IdProffessions == IdProffessions).ToList();
                        value += 1;
                        break;
                    case 5:
                        MainWindow.Naviget = new DateTime();
                        break;
                }
            }
        }
    }
}
