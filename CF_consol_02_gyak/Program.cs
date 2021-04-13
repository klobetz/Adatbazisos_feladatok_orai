using CF_consol_02_gyak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF_consol_02_gyak
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Kapcsolat();
            Console.WriteLine($"Mennyi rekord van az autok táblában: {db.Autos.Count()}");

            Console.ReadLine();
        }
    }
}
