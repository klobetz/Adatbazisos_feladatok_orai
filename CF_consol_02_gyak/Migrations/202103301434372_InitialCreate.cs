namespace CF_consol_02_gyak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Rendszam = c.String(),
                        Tipus = c.String(),
                        Gyartas = c.DateTime(nullable: false),
                        Kolcsonzo_id = c.Int(nullable: false),
                        Kolcsonzo_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Kolcsonzoes", t => t.Kolcsonzo_id1)
                .Index(t => t.Kolcsonzo_id1);
            
            CreateTable(
                "dbo.Kolcsonzoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Autoes", "Kolcsonzo_id1", "dbo.Kolcsonzoes");
            DropIndex("dbo.Autoes", new[] { "Kolcsonzo_id1" });
            DropTable("dbo.Kolcsonzoes");
            DropTable("dbo.Autoes");
        }
    }
}
