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
using System.Windows.Shapes;

namespace DBF_WPF_projekt_01
{
    /// <summary>
    /// Interaction logic for KeresesWindow.xaml
    /// </summary>
    public partial class KeresesWindow : Window
    {
        public KeresesWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new AutoNyilvantartasDBEntities())
            {
                dg_keres.ItemsSource = db.Kolcsonzo.Include("Auto").Include("Berlo").ToList();
            }        
                      
        }

        private void btn_kereses_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AutoNyilvantartasDBEntities())
            {
                var kereses = db.Kolcsonzo.Include("Auto").Include("Berlo").Where(adat=>
                adat.Nev.Contains(tb_kereso.Text) ||
                adat.Cim.Contains(tb_kereso.Text) ||
                adat.Auto.Marka.Contains(tb_kereso.Text) ||
                adat.Auto.Tipus.Contains(tb_kereso.Text) ||
                adat.Berlo.Nev.Contains(tb_kereso.Text));

                dg_keres.ItemsSource = kereses.ToList();
            }
        
        }

        private void btn_export_Click(object sender, RoutedEventArgs e)
        {

        }        
    }
}
