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
    /// Interaction logic for AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new AutoNyilvantartasDBEntities())  //példányosítom a kapcsolatot, hogy elérjem a tábláimat
            {
                var auto = db.Auto;                             //beleteszem egy változóba a táblámat amiből az adatokat megjelenítem a DataGrid-be


                //az adott tábla bejárása debug ablakba kiírás
                //foreach (var item in auto)
                //{
                //    Console.WriteLine($"{item.Rendszam} \t{item.Marka} \t{item.Id}");
                //}

                //csak az adott osztlop megjelenítése kiszelektálom LINQ-val
                //var adottoszlop = from a in db.Auto
                //                  select new
                //                  {
                //                      Rendszám = a.Rendszam,
                //                      Márka = a.Marka
                //                  };

                //ugyan az egy kicsit rövidebben lamdával
                //var adottoszlop = auto.Select(a=>new {Rendszám = a.Rendszam, Típus = a.Tipus}); 
                //dg_auto.ItemsSource = adottoszlop.ToList();


                //az adott feltételnek megfelelő adatot adja vissza
                //var feltetel = from b in db.Auto
                //               where b.Marka.Equals("opel")
                //               select b;

                //var feltetel = auto.Where(a=>a.Marka.Equals("Opel"));

                //az G-el kezdődő rendszámok kiíratása
                //var feltetel = from c in auto
                //               where c.Rendszam.StartsWith("g")
                //               select c;

                //var feltetel = auto.Where(a => a.Rendszam.StartsWith("g"));

                //dg_auto.ItemsSource = feltetel.ToList();

                dg_auto.ItemsSource = auto.ToList();            //megjelenítem az összes adatot ami a táblában van
            }
        }

        private void btn_hozzaad_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AutoNyilvantartasDBEntities())
            {
                //var autoadat = db.Auto; //ez is használható

                var adatfelvitel = new Auto()
                {
                    //megnézem hogy jó-e a mentés és belekerül-e az adat a táblámba
                    //Rendszam = "ZTH-854",
                    //Marka = "Lada",
                    //Tipus = "Szamara"


                    //a textbox adatát írja a DB-be
                    Rendszam = tb_rendszam.Text,
                    Marka = tb_marka.Text,
                    Tipus = tb_tipus.Text
                };
                db.Auto.Add(adatfelvitel);
                db.SaveChanges();
                dg_auto.ItemsSource = db.Auto.ToList();
            }

            //van egy probléma nem marad meg az adat a DB-ben.
            //Ennek az oka a DB (mdf állományom) property-e Copy always ra van állítva
            //az állítsuk Copy if newer -re

        }

        private void btn_torol_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_frissit_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
