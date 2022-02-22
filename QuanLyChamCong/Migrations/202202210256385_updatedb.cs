namespace QuanLyChamCong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroupUsers", "Group_idGroup", "dbo.Groups");
            DropForeignKey("dbo.GroupUsers", "User_idUser", "dbo.Users");
            DropIndex("dbo.GroupUsers", new[] { "Group_idGroup" });
            DropIndex("dbo.GroupUsers", new[] { "User_idUser" });
            CreateIndex("dbo.Users", "idGroup");
            AddForeignKey("dbo.Users", "idGroup", "dbo.Groups", "idGroup");
            DropTable("dbo.GroupUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GroupUsers",
                c => new
                    {
                        Group_idGroup = c.Int(nullable: false),
                        User_idUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_idGroup, t.User_idUser });
            
            DropForeignKey("dbo.Users", "idGroup", "dbo.Groups");
            DropIndex("dbo.Users", new[] { "idGroup" });
            CreateIndex("dbo.GroupUsers", "User_idUser");
            CreateIndex("dbo.GroupUsers", "Group_idGroup");
            AddForeignKey("dbo.GroupUsers", "User_idUser", "dbo.Users", "idUser", cascadeDelete: true);
            AddForeignKey("dbo.GroupUsers", "Group_idGroup", "dbo.Groups", "idGroup", cascadeDelete: true);
        }
    }
}
