namespace MvcWithMsUnit.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Accountype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccountTypes");
        }
    }
}
