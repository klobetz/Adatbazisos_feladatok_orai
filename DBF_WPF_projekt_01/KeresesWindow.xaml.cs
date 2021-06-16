using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
            //Az excel létrehozása
            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("kolcsonzes"); //a munkalap elnevezése

                //kell az oszlopok és a sorok továbbléptetéséhez
                int column = 1;
                int row = 1;

                try
                {
                    //a fejléc elkészítése
                    foreach (var fejlec in dg_keres.Columns)
                    {
                        ws.Cell(row, column).Value = fejlec.Header; //fejléc elkészítés

                        ws.Cell(row, column).Style.Font.Bold = true; //a szöveg félkövér

                        column++;
                    }

                    column = 1;
                    row = 2; //mert különben felülírja a fejlécet!

                    //adatok feltöltése a sorokba
                    foreach (Kolcsonzo item in dg_keres.Items)
                    {                       
                        ws.Cell(row, column++).Value = item.Nev;
                        ws.Cell(row, column++).Value = item.Cim;
                        ws.Cell(row, column++).Value = item.Auto?.Marka; //az üres mezökre hiba javítás //Null Reference Exception
                        ws.Cell(row, column++).Value = item.Auto?.Tipus;
                        ws.Cell(row, column).Value = item.Berlo?.Nev;
                                                
                        row++;
                        column = 1; //vissza kell állítani mert különben elcsúszik a sor kiíratása
                    }

                    ws.Columns().AdjustToContents(); //oszlopszéleség automatkus beállítása

                    var fajlmentes = new SaveFileDialog() {Filter = "Excel fájlok|*.xlsx"}; //filtre ==> xlsx kiterjesztést ne keljen megadni
                    
                    if (fajlmentes.ShowDialog() == true)
                    {
                        workbook.SaveAs(fajlmentes.FileName); //én nevezem el az állományomat
                        MessageBox.Show("Elkészült a mentés"); //figyelmeztet
                    }
                    else
                    {
                        //ha bezárom a dialógus ablakot
                        MessageBox.Show("Az adatokat nem mentette el!");
                    }
                    

                    
                }
                catch (Exception ex) //ex==> kivétel hibakezelés megmutatására 
                {
                    //MessageBox.Show(ex.ToString()); //hiba kiíratása
                    MessageBox.Show("Hiba az adatok metése közben!","Figyelmeztetés",MessageBoxButton.OK,MessageBoxImage.Error);
                }

            }
        }        
    }
}
