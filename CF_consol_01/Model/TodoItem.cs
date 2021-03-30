using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF_consol_01.Model
{/// <summary>
/// fontos hogy ez az osztály public legyen a láthatóság miatt
/// mivel az CF- névkonvenció alapú ezért felismeri az ID-t 
/// mivel leírtam a nevéhez hogy ő az ID ezért lett ő a Primery key
/// mivel a típusa int ezért let ő Identity
/// ha nem id akkor megadom a [Key] kulcsszót a Property elé PL: [Key] public string Title { get; set; }
/// viszont be kell tölteni a model névteret és akkor nem lesz piros aláhúzás (ctrl .)
/// </summary>
    public class TodoItem
    {
        public TodoItem()
        {//az alapértelmezett érték megadása
            IsDone = false;
            Opened = DateTime.Now;
            Closed = null;
        }

        public int id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public DateTime Opened { get; set; } //mikor nyitott meg
        public DateTime? Closed { get; set; } //mikor zárt

        //miva akkor ha módosítanom kell az adatbázisomat?
        //erre az esetre CF alat a Migrations segít


        //új tábla léterhozása
        public Severity Severity { get; set; }
        
        //Én akarom kezelni az FK-t ezért hozom létre saját magam
        //Ez nem lenne kötelező hiszen alapból is elékszítette nekem a DB-ben
        public int SeverityId { get; set; }

    }
}
