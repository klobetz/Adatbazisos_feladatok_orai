using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF_consol_02_gyak.Model
{
    class Kapcsolat : DbContext
    {
        public DbSet<Auto> Autos { get; set; }
    }
}
