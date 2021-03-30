using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF_consol_02_gyak.Model
{
    public class Auto
    {
        public Auto()
        {
            Gyartas = DateTime.Now;
        }

        public int id { get; set; }
        public string Rendszam { get; set; }
        
        public DateTime? Gyartas { get; set; }

        public Kolcsonzo Kolcsonzo { get; set; }
        public int Kolcsonzo_id { get; set; }

        public Berlo Berlo { get; set; }
        public int Berlo_id { get; set; }

        public Tipus Tipus { get; set; }
        public int Tipus_id { get; set; }
    }
}
