using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF_consol_01.Model
{/// <summary>
/// Ez az oszály fogja tartani a kapcsolatot az adatbárisommal
/// ahhoz hogy ez működő képes legyen le kell származtatni a DbContext-ből 
/// Ehez viszont telepítenem kell az Entity Framework-öt (Nugget csomag)
/// </summary>
    public class TodoContext : DbContext
    {
        /// <summary>
        /// Össze kell kötni az adatookat reprezentáló osztályt az elérési osztállyal
        /// Erre lesz alkalmas a DbSet ami egy generikus (mint a lista) csak ez nem a memóriában tárol hanem a DB-be
        /// </summary>
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
