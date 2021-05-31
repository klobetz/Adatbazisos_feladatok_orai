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
    /// Interaction logic for BerloPage.xaml
    /// </summary>
    public partial class BerloPage : Page
    {
        public int BerloAzonID { get; private set; }

        public BerloPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new AutoNyilvantartasDBEntities())
            {
                var berlo = db.Berlo;
                dg_berlo.ItemsSource = berlo.ToList();
            }
        }


        private void dg_berlo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_berlo.SelectedItem != null)
            {

                var adat = dg_berlo.SelectedItem as Berlo;
                tb_berlonevfriss.Text = adat.Nev;
                tb_berlocimfriss.Text = adat.Cim;
                tb_berlonemfriss.Text = adat.Nem;

                BerloAzonID = adat.Id;
            }
        }

        private void btn_berlohozzaad_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AutoNyilvantartasDBEntities())
            {
                var berlo = new Berlo();

                berlo.Nev = tb_berlonev.Text;
                berlo.Cim = tb_berlocim.Text;
                berlo.Nem = tb_berlonem.Text;
                if (tb_berlonev.Text.Length == 0 || tb_berlocim.Text.Length == 0 || tb_berlonem.Text.Length == 0)
                {
                    MessageBox.Show("A mezők kitöltése kötelező", "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                db.Berlo.Add(berlo);
                db.SaveChanges();
                TextBoxTorol();
                dg_berlo.ItemsSource = db.Berlo.ToList();
            }
        }

        private void btn_berlotorol_Click(object sender, RoutedEventArgs e)
        {
            var uzenet = MessageBox.Show("Biztos, hogy törölsz?", "Törlési üzenet",
                                       MessageBoxButton.YesNo,
                                       MessageBoxImage.Warning,
                                       MessageBoxResult.Yes);
            if (uzenet == MessageBoxResult.Yes)
            {
                using (var db = new AutoNyilvantartasDBEntities())
                {

                    var berloadat = db.Berlo.Where(a => a.Id == BerloAzonID);
                    db.Berlo.RemoveRange(berloadat);
                    db.SaveChanges();

                    dg_berlo.ItemsSource = db.Berlo.ToList();
                }
            }
        }

        private void btn_berlofrissit_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AutoNyilvantartasDBEntities())
            {                
                if (!dg_berlo.SelectedIndex.Equals(-1))
                {
                    var berloadat = db.Berlo.FirstOrDefault(adat => adat.Id == BerloAzonID);

                    if (tb_berlonevfriss.Text.Length == 0 || tb_berlocimfriss.Text.Length == 0 || tb_berlonemfriss.Text.Length == 0)
                    {
                        var hibauzenet = MessageBox.Show("A mezők kitöltése kötelező!\n a mezőbe csak számot írhatsz", "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Error);

                        TextBoxTorol();
                        return;
                    }
                    if (berloadat != null)
                    {
                        berloadat.Nev = tb_berlonevfriss.Text;
                        berloadat.Cim = tb_berlocimfriss.Text;
                        berloadat.Nem = tb_berlonemfriss.Text;                        
                    }
                    db.SaveChanges();
                    TextBoxTorol();
                    dg_berlo.ItemsSource = db.Berlo.ToList();
                }
                else
                {
                    MessageBox.Show("Nincs amit frissitsek!");
                }

            }

        }

        private void TextBoxTorol()
        {
            tb_berlonev.Clear();
            tb_berlocim.Clear();
            tb_berlonem.Clear();

            tb_berlonevfriss.Clear();
            tb_berlocimfriss.Clear();
            tb_berlonemfriss.Clear();
        }


       
    }
}
