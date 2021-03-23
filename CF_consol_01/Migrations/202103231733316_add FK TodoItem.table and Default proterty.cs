namespace CF_consol_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFKTodoItemtableandDefaultproterty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TodoItems", "Severity_id", "dbo.Severities");
            DropIndex("dbo.TodoItems", new[] { "Severity_id" });
            RenameColumn(table: "dbo.TodoItems", name: "Severity_id", newName: "SeverityId");
            AlterColumn("dbo.TodoItems", "SeverityId", c => c.Int(nullable: false));
            CreateIndex("dbo.TodoItems", "SeverityId");
            AddForeignKey("dbo.TodoItems", "SeverityId", "dbo.Severities", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoItems", "SeverityId", "dbo.Severities");
            DropIndex("dbo.TodoItems", new[] { "SeverityId" });
            AlterColumn("dbo.TodoItems", "SeverityId", c => c.Int());
            RenameColumn(table: "dbo.TodoItems", name: "SeverityId", newName: "Severity_id");
            CreateIndex("dbo.TodoItems", "Severity_id");
            AddForeignKey("dbo.TodoItems", "Severity_id", "dbo.Severities", "id");
        }
    }
}
