﻿using CF_consol_01.Model;
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





            Console.ReadLine();
        }
    }
}
