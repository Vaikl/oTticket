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
using oTicket.View;

namespace oTicket
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static object Naviget { get; set; }
        
        public MainWindow()
        {
            Naviget = new Authorizations();
            InitializeComponent();
            MainPage.Navigate(Naviget);
            CompositionTarget.Rendering += Pages;
        }
        private void Pages(object sender, EventArgs e)
        {
            MainPage.Navigate(Naviget);
        }
    }
}
