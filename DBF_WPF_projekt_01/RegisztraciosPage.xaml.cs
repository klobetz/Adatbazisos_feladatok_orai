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
    /// Interaction logic for RegisztraciosPage.xaml
    /// </summary>
    public partial class RegisztraciosPage : Page
    {
        public RegisztraciosPage()
        {
            InitializeComponent();
        }

        private void chb_jelszomutat_Checked(object sender, RoutedEventArgs e)
        {
            tb_jelszo.Text = pwb_jelszo.Password;
            pwb_jelszo.Visibility = Visibility.Collapsed;
            tb_jelszo.Visibility = Visibility.Visible;

            tb_jelszomegerosítes.Text = pwb_jelszomegerosítes.Password;
            pwb_jelszomegerosítes.Visibility = Visibility.Collapsed;
            tb_jelszomegerosítes.Visibility = Visibility.Visible;
        }

        private void chb_jelszomutat_Unchecked(object sender, RoutedEventArgs e)
        {
            pwb_jelszo.Password = tb_jelszo.Text;
            tb_jelszo.Visibility = Visibility.Collapsed;
            pwb_jelszo.Visibility = Visibility.Visible;

            pwb_jelszomegerosítes.Password = tb_jelszomegerosítes.Text;
            tb_jelszomegerosítes.Visibility = Visibility.Collapsed;
            pwb_jelszomegerosítes.Visibility = Visibility.Visible;
        }

        private void btn_regisztacio_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_felhasznalonev.Text)||string.IsNullOrWhiteSpace(pwb_jelszo.Password)||string.IsNullOrWhiteSpace(pwb_jelszomegerosítes.Password))
            {
                MessageBox.Show("A mező kitöltése kötelező!", "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Information);
                tb_felhasznalonev.Focus();
            }
            else
            {
                if (pwb_jelszo.Password == pwb_jelszomegerosítes.Password)
                {
                    using (var db = new AutoNyilvantartasDBEntities())
                    {
                        //itt én nem engedem meg a kis és nagybetűt!                        
                        //var ellenortes = db.Felhasznalok.FirstOrDefault(adat => adat.Felhasznalonev.Equals(tb_felhasznalonev.Text, StringComparison.OrdinalIgnoreCase));
                        
                        
                        var ellenortes = db.Felhasznalok.FirstOrDefault(adat => adat.Felhasznalonev.Equals(tb_felhasznalonev.Text)); //DB-miatt nem veszi figyelembe a kis és nagybetűt

                        if (ellenortes != null)
                        {
                            MessageBox.Show("Létezik már ilyen felhasználó!");
                        }
                        else
                        {
                            var adatok = new Felhasznalok();

                            adatok.Felhasznalonev = tb_felhasznalonev.Text;

                            var jelszohash = EasyEncryption.SHA.ComputeSHA256Hash(pwb_jelszo.Password);
                            adatok.Jelszo = jelszohash;

                            db.Felhasznalok.Add(adatok);
                            db.SaveChanges();
                            MessageBox.Show($"Az adatokat elmentettem!\nFelhasználónév: {tb_felhasznalonev.Text}\nJelszó: {pwb_jelszo.Password}");
                        }
                        torol(false);
                        tb_felhasznalonev.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("A két jelszó nem egyezik!");
                    torol(true);
                    tb_felhasznalonev.Focus();
                }
            }
        }

        

        private void lb_vissza_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new BejelentkezoPage());
        }

        private void torol(bool csakjelsz)
        {
            if (!csakjelsz) tb_felhasznalonev.Clear();
            pwb_jelszo.Clear();
            pwb_jelszomegerosítes.Clear();
        }
    }
}
