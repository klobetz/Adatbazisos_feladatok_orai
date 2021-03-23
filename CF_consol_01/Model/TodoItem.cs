using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF_consol_01.Model
{/// <summary>
/// fontos hogy ez az osztály public legyen a láthatóság miatt
/// mivel az CF- névkonvenció alapú ezért felismeri az ID-t 
/// mivel leírtam a nevéhez hogy ő az ID ezért lett ő a Primery key
/// mivel a típusa int ezért let ő Identity
/// ha nem id akkor megadom a [key] kulcsszót a névre
/// </summary>
    public class TodoItem
    {
        public int id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public DateTime Opened { get; set; } //mikor nyitott meg
        public DateTime Closed { get; set; } //mikor zárt
    }
}
