using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBF_console_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new OktatokEntities();
            var tanartabla = db.Tanars;
            var tanatargytabla = db.Tantargies;

            Console.WriteLine($"A tanárok száma a Tanátok táblában: {tanartabla.Count()}");

            Console.WriteLine("A táblában szereplő nevek listáj:");
            foreach (var item in tanartabla)
            {
                Console.WriteLine($"{item.Nev}\t{item.SzülAdat}");
            }

            Console.WriteLine("A tantárgyak listáj:");
            foreach (var item in tanatargytabla)
            {
                Console.WriteLine($"{item.Tantargyak}");
            }



            Console.ReadLine();
           
        }
    }
}
