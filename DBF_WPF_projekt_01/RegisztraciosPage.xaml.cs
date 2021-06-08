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

        }

        private void chb_jelszomutat_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void btn_regisztacio_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void lb_vissza_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new BejelentkezoPage());
        }
    }
}
