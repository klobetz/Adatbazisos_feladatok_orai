namespace CF_consol_02_gyak.Model
{
    public class Kolcsonzo
    {
        public int id { get; set; }
        public string Nev { get; set; }

        public Tulajdonos Tulajdonos { get; set; }
        public int Tulajdonosid { get; set; }
    }
}