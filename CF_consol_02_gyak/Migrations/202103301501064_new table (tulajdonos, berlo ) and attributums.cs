namespace CF_consol_02_gyak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtabletulajdonosberloandattributums : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Berloes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Tulajdonos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Autoes", "Berlo_id", c => c.Int(nullable: false));
            AddColumn("dbo.Autoes", "Berlo_id1", c => c.Int());
            AddColumn("dbo.Kolcsonzoes", "Tulajdonos_id", c => c.Int(nullable: false));
            AddColumn("dbo.Kolcsonzoes", "Tulajdonos_id1", c => c.Int());
            CreateIndex("dbo.Autoes", "Berlo_id1");
            CreateIndex("dbo.Kolcsonzoes", "Tulajdonos_id1");
            AddForeignKey("dbo.Autoes", "Berlo_id1", "dbo.Berloes", "id");
            AddForeignKey("dbo.Kolcsonzoes", "Tulajdonos_id1", "dbo.Tulajdonos", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kolcsonzoes", "Tulajdonos_id1", "dbo.Tulajdonos");
            DropForeignKey("dbo.Autoes", "Berlo_id1", "dbo.Berloes");
            DropIndex("dbo.Kolcsonzoes", new[] { "Tulajdonos_id1" });
            DropIndex("dbo.Autoes", new[] { "Berlo_id1" });
            DropColumn("dbo.Kolcsonzoes", "Tulajdonos_id1");
            DropColumn("dbo.Kolcsonzoes", "Tulajdonos_id");
            DropColumn("dbo.Autoes", "Berlo_id1");
            DropColumn("dbo.Autoes", "Berlo_id");
            DropTable("dbo.Tulajdonos");
            DropTable("dbo.Berloes");
        }
    }
}
