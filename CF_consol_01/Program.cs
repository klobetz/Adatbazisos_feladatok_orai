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
        {
            var db = new TodoContext();
            Console.WriteLine(db.TodoItems.Count());
            Console.ReadLine();
        }
    }
}
