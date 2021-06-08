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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Bezar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bt_kolcsonzes_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new KolcsonzoPage();
        }

        private void bt_autok_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AutoPage();
        }

        private void bt_berlo_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new BerloPage();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Main.Content = new BejelentkezoPage();
        }
    }
}
