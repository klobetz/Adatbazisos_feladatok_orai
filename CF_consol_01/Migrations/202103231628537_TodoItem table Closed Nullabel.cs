namespace CF_consol_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodoItemtableClosedNullabel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TodoItems", "Closed", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TodoItems", "Closed", c => c.DateTime(nullable: false));
        }
    }
}
