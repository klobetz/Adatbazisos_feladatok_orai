namespace CF_consol_01.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CF_consol_01.Model.TodoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CF_consol_01.Model.TodoContext";
        }

        protected override void Seed(CF_consol_01.Model.TodoContext context)
        {
            //context.Severities.Add(new Model.Severity { Title = "Fontos" }); //ebben az esetben mindig létrejön a rekord
            //context.Severities.Add(new Model.Severity { Title = "Nem Fontos" });

            //context.Severities.AddOrUpdate(new Model.Severity { id=5, Title = "Nem Fontos" }); //létrehozza vagy frissíti

            context.Severities.AddOrUpdate(x=>x.Title, new Model.Severity { Title = "Fontos nagyom" }); //itt már figyeli a tilt attributumot és ha létezi akko nem írja bele
            // context.Severities.AddOrUpdate(x => x.Title, new Model.Severity { Title = "Nem Fontos" });
        }
    }
}
