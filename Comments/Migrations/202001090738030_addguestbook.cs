namespace Comments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addguestbook : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Guestbooks", "Name", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Guestbooks", "Email", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Guestbooks", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Guestbooks", "Name", c => c.String(nullable: false));
        }
    }
}
