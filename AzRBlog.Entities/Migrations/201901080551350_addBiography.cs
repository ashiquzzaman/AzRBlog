namespace AzRBlog.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBiography : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfiles", "CountryId", "dbo.Countries");
            DropIndex("dbo.UserProfiles", new[] { "CountryId" });
            AddColumn("dbo.UserProfiles", "Mobile", c => c.String(maxLength: 500));
            AddColumn("dbo.UserProfiles", "Biography", c => c.String());
            AddColumn("dbo.UserProfiles", "ZipCode", c => c.String(maxLength: 50));
            AlterColumn("dbo.UserProfiles", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.UserProfiles", "Address", c => c.String(maxLength: 500));
            AlterColumn("dbo.UserProfiles", "State", c => c.String(maxLength: 50));
            AlterColumn("dbo.UserProfiles", "CountryId", c => c.Int());
            CreateIndex("dbo.UserProfiles", "CountryId");
            AddForeignKey("dbo.UserProfiles", "CountryId", "dbo.Countries", "Id");
            DropColumn("dbo.UserProfiles", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "Phone", c => c.String(nullable: false, maxLength: 20));
            DropForeignKey("dbo.UserProfiles", "CountryId", "dbo.Countries");
            DropIndex("dbo.UserProfiles", new[] { "CountryId" });
            AlterColumn("dbo.UserProfiles", "CountryId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserProfiles", "State", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserProfiles", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.UserProfiles", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.UserProfiles", "ZipCode");
            DropColumn("dbo.UserProfiles", "Biography");
            DropColumn("dbo.UserProfiles", "Mobile");
            CreateIndex("dbo.UserProfiles", "CountryId");
            AddForeignKey("dbo.UserProfiles", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
