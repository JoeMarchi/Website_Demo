namespace Comments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 40),
                        Name = c.String(nullable: false, maxLength: 5),
                        Nickname = c.String(nullable: false, maxLength: 10),
                        RegisterOn = c.DateTime(nullable: false),
                        AuthCode = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
