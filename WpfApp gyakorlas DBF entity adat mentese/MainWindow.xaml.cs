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

namespace WpfApp_gyakorlas_DBF_entity_adat_mentese
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new TanarokDBEntities())
            {
                dg_adat.ItemsSource = db.Tanar.ToList();
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new TanarokDBEntities())
            {
                var tanaradat = new Tanar()
                {
                    Nev = tb_nev.Text,
                    Varos = tb_lakhely.Text,
                    Vegzetseg = tb_vegzetseg.Text,
                    Neme = tb_nem.Text,                    
                };

                db.Tanar.Add(tanaradat);
                db.SaveChanges();
                dg_adat.ItemsSource = db.Tanar.ToList();
            }
        }
    }
}
