using CF_consol_01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF_consol_01
{
    class Program
    {
        static void Main(string[] args)
        {//ahhhoz hogy működjön pédányosítanom kell a DbContext-et (kapcsolódási osztály)
            


            Console.Write("A TodoItem táblában ennyi rekordom van: ");
            var db = new TodoContext();
            Console.WriteLine(db.TodoItems.Count());

            //severity tábla adatai
            Console.WriteLine($"Mennyi adat van a severity táblában: {db.Severities.Count()}");

            //írasuk ki ezeket az adatokat
            //foreach (var item in db.Severities)
            //{
            //    Console.WriteLine($"{item.id} {item.Title}");
            //}

            //
           
           


            //adat felvitele a severity táblába kézzel
            //var title = new Severity();     //tábla pédányosítása
            //title.Title = "ez egy új sor";  //mit adjak hozzá
            //db.Severities.Add(title);       //hozzáadom
            //db.SaveChanges();               //DB mentése

            //adatok bekérése a felhasználótól:
            Console.WriteLine("kérek egy adatot (Title)");
            var valasz = Console.ReadLine();


            while (int.TryParse(valasz, out int szam))
            {
                Console.WriteLine("rossz adat újra");
                valasz = Console.ReadLine();
            }

            var title = new Severity();     //tábla pédányosítása
            title.Title = valasz;           //mit adjak hozzá
            db.Severities.Add(title);       //hozzáadom
            db.SaveChanges();               //DB mentése
            Console.WriteLine("Köszönöm!");


            //kiíratás
            foreach (var item in db.Severities)
            {
                Console.WriteLine($"{item.id} {item.Title}");
            }

            

            Console.ReadLine();
        }
    }
}
