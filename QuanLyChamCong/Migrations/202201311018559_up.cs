namespace QuanLyChamCong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        idGroup = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.idGroup);
            
            CreateTable(
                "dbo.GroupUsers",
                c => new
                    {
                        Group_idGroup = c.Int(nullable: false),
                        User_idUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_idGroup, t.User_idUser })
                .ForeignKey("dbo.Groups", t => t.Group_idGroup, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_idUser, cascadeDelete: true)
                .Index(t => t.Group_idGroup)
                .Index(t => t.User_idUser);
            
            AddColumn("dbo.Users", "idGroup", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupUsers", "User_idUser", "dbo.Users");
            DropForeignKey("dbo.GroupUsers", "Group_idGroup", "dbo.Groups");
            DropIndex("dbo.GroupUsers", new[] { "User_idUser" });
            DropIndex("dbo.GroupUsers", new[] { "Group_idGroup" });
            DropColumn("dbo.Users", "idGroup");
            DropTable("dbo.GroupUsers");
            DropTable("dbo.Groups");
        }
    }
}
