namespace CF_consol_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtablecerateSeverityandadd2propertys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Severities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.TodoItems", "Severity_id", c => c.Int());
            CreateIndex("dbo.TodoItems", "Severity_id");
            AddForeignKey("dbo.TodoItems", "Severity_id", "dbo.Severities", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoItems", "Severity_id", "dbo.Severities");
            DropIndex("dbo.TodoItems", new[] { "Severity_id" });
            DropColumn("dbo.TodoItems", "Severity_id");
            DropTable("dbo.Severities");
        }
    }
}
