namespace CleanCode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserRoles", t => t.UserRole_Id)
                .Index(t => t.UserRole_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserRole_Id", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserRole_Id" });
            DropTable("dbo.Users");
        }
    }
}
