namespace CF_consol_02_gyak.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CF_consol_02_gyak.Model.Kapcsolat>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CF_consol_02_gyak.Model.Kapcsolat";
        }

        protected override void Seed(CF_consol_02_gyak.Model.Kapcsolat context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
