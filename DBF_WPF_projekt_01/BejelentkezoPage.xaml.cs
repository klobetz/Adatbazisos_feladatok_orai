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
    /// Interaction logic for BejelentkezoPage.xaml
    /// </summary>
    public partial class BejelentkezoPage : Page
    {
        public BejelentkezoPage()
        {
            InitializeComponent();
        }

        private void btn_bejelentkezes_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_felhasznalonev.Text) || string.IsNullOrWhiteSpace(pwb_jelszo.Password))
            {
                MessageBox.Show("A mezők kitöltése kötelező!");
            }
            else
            {
                using (var db = new AutoNyilvantartasDBEntities())
                {
                    var ellenorzes = db.Felhasznalok.FirstOrDefault(adat=>adat.Felhasznalonev.Equals(tb_felhasznalonev.Text) && adat.Jelszo == pwb_jelszo.Password);

                    if (ellenorzes!=null)
                    {
                        NavigationService.Navigate(new KolcsonzoPage());
                    }
                    else
                    {
                        MessageBox.Show("Hibás felhasználónév vagy jelszó!");
                        tb_felhasznalonev.Clear();
                        pwb_jelszo.Clear();
                        tb_felhasznalonev.Focus();
                    }
                }
            }
            
        }
               
        private void lb_regisztralas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegisztraciosPage());
        }

        private void chb_jelszomutat_Checked(object sender, RoutedEventArgs e)
        {
            tb_jelszo.Text = pwb_jelszo.Password;
            pwb_jelszo.Visibility = Visibility.Collapsed;
            tb_jelszo.Visibility = Visibility.Visible;

        }  

        private void chb_jelszomutat_Unchecked(object sender, RoutedEventArgs e)
        {
            pwb_jelszo.Password = tb_jelszo.Text;
            tb_jelszo.Visibility = Visibility.Collapsed;
            pwb_jelszo.Visibility = Visibility.Visible;
        }
    }
}
