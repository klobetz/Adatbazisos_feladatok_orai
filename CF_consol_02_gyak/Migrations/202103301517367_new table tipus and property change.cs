namespace CF_consol_02_gyak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtabletipusandpropertychange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tipus",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Autoes", "Tipus_id", c => c.Int(nullable: false));
            AddColumn("dbo.Autoes", "Tipus_id1", c => c.Int());
            CreateIndex("dbo.Autoes", "Tipus_id1");
            AddForeignKey("dbo.Autoes", "Tipus_id1", "dbo.Tipus", "id");
            DropColumn("dbo.Autoes", "Tipus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Autoes", "Tipus", c => c.String());
            DropForeignKey("dbo.Autoes", "Tipus_id1", "dbo.Tipus");
            DropIndex("dbo.Autoes", new[] { "Tipus_id1" });
            DropColumn("dbo.Autoes", "Tipus_id1");
            DropColumn("dbo.Autoes", "Tipus_id");
            DropTable("dbo.Tipus");
        }
    }
}
