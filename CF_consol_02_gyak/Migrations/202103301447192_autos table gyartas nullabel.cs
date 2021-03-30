namespace CF_consol_02_gyak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autostablegyartasnullabel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Autoes", "Gyartas", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Autoes", "Gyartas", c => c.DateTime(nullable: false));
        }
    }
}
