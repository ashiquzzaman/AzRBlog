namespace AzRBlog.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userprofile : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.People", newName: "UserProfiles");
            AddColumn("dbo.Users", "ProfileId", c => c.Long(nullable: false));
            CreateIndex("dbo.Users", "ProfileId");
            AddForeignKey("dbo.Users", "ProfileId", "dbo.UserProfiles", "Id", cascadeDelete: true);
            DropTable("dbo.AccountTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Users", "ProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Users", new[] { "ProfileId" });
            DropColumn("dbo.Users", "ProfileId");
            RenameTable(name: "dbo.UserProfiles", newName: "People");
        }
    }
}
