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
                //cb_rendszam.ItemsSource = autok.ToList();
                cb_berlo.ItemsSource = berlo.ToList();


                dg_kolcsonzo.ItemsSource = kolsonzok.ToList();
            }

        }
        private void btn_hozzaad_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AutoNyilvantartasDBEntities())
            {
                if (string.IsNullOrWhiteSpace(tb_kcim.Text) || string.IsNullOrWhiteSpace(tb_knev.Text))
                {
                    MessageBox.Show("A mezők kitöltése kötelező!");
                }
                else
                {
                    var kolcsonzotabla = new Kolcsonzo()
                    {
                        Nev = tb_knev.Text,
                        Cim = tb_kcim.Text,
                        Auto_Id = (int)cb_automarka.SelectedValue,
                        Berlo_Id = (int)cb_berlo.SelectedValue,
                    };

                    //vagy ezzel a megoldással
                    //var kolcsonzotabla2 = new Kolcsonzo();
                    //kolcsonzotabla2.Cim = tb_kcim.Text; ...

                    db.Kolcsonzo.Add(kolcsonzotabla);
                    db.SaveChanges();
                    dg_kolcsonzo.ItemsSource = db.Kolcsonzo.Include("Auto").Include("Berlo").ToList();
                }
                
            }
        }

        private void btn_autoadd_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new AutoPage());
            //this.NavigationService.Navigate(new Uri("AutoPage.xaml", UriKind.Relative));
           

        }

        private void btn_berloadd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BerloPage());
        }

        private void dg_kolcsonzo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_keres_Click(object sender, RoutedEventArgs e)
        {
            var kereso = new KeresesWindow();
            kereso.ShowDialog();
        }
    }
}
