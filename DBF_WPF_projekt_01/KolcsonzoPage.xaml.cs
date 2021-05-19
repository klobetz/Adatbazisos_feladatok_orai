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

namespace DBF_WPF_projekt_01
{
    /// <summary>
    /// Interaction logic for KolcsonzoPage.xaml
    /// </summary>
    public partial class KolcsonzoPage : Page
    {
        public KolcsonzoPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new AutoNyilvantartasDBEntities())
            {
                var autok = db.Auto;
                var kolsonzok = db.Kolcsonzo;
                var berlo = db.Berlo;

                cb_automarka.ItemsSource = autok.ToList();
                cb_rendszam.ItemsSource = autok.ToList();
                cb_berlo.ItemsSource = berlo.ToList();                
                

                dg_kolcsonzo.ItemsSource = kolsonzok.ToList();
            }

        }
        private void btn_hozzaad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_autoadd_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new AutoPage());

        }

        private void btn_berloadd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BerloPage());
        }

        private void dg_kolcsonzo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
