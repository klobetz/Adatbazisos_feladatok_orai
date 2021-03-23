using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF_consol_01.Model
{/// <summary>
/// Ez az oszály fogja tartani a kapcsolatot az adatbárisommal
/// </summary>
    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
