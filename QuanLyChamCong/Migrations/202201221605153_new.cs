namespace QuanLyChamCong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CheckIns", new[] { "User_idUser" });
            DropIndex("dbo.Users", new[] { "Role_idRole" });
            DropIndex("dbo.Reviews", new[] { "User_idUser" });
            DropIndex("dbo.SupplementalLeaves", new[] { "Type_idType" });
            DropIndex("dbo.SupplementalLeaves", new[] { "User_idUser" });
            RenameColumn(table: "dbo.CheckIns", name: "User_idUser", newName: "idUser");
            RenameColumn(table: "dbo.Reviews", name: "User_idUser", newName: "idUser");
            RenameColumn(table: "dbo.Users", name: "Role_idRole", newName: "idRole");
            RenameColumn(table: "dbo.SupplementalLeaves", name: "User_idUser", newName: "idUser");
            RenameColumn(table: "dbo.SupplementalLeaves", name: "Type_idType", newName: "idType");
            AddColumn("dbo.Salaries", "idUser", c => c.Int(nullable: false));
            AlterColumn("dbo.CheckIns", "idUser", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "idRole", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "idUser", c => c.Int(nullable: false));
            AlterColumn("dbo.SupplementalLeaves", "idType", c => c.Int(nullable: false));
            AlterColumn("dbo.SupplementalLeaves", "idUser", c => c.Int(nullable: false));
            CreateIndex("dbo.CheckIns", "idUser");
            CreateIndex("dbo.Users", "idRole");
            CreateIndex("dbo.Reviews", "idUser");
            CreateIndex("dbo.SupplementalLeaves", "idType");
            CreateIndex("dbo.SupplementalLeaves", "idUser");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SupplementalLeaves", new[] { "idUser" });
            DropIndex("dbo.SupplementalLeaves", new[] { "idType" });
            DropIndex("dbo.Reviews", new[] { "idUser" });
            DropIndex("dbo.Users", new[] { "idRole" });
            DropIndex("dbo.CheckIns", new[] { "idUser" });
            AlterColumn("dbo.SupplementalLeaves", "idUser", c => c.Int());
            AlterColumn("dbo.SupplementalLeaves", "idType", c => c.Int());
            AlterColumn("dbo.Reviews", "idUser", c => c.Int());
            AlterColumn("dbo.Users", "idRole", c => c.Int());
            AlterColumn("dbo.CheckIns", "idUser", c => c.Int());
            DropColumn("dbo.Salaries", "idUser");
            RenameColumn(table: "dbo.SupplementalLeaves", name: "idType", newName: "Type_idType");
            RenameColumn(table: "dbo.SupplementalLeaves", name: "idUser", newName: "User_idUser");
            RenameColumn(table: "dbo.Users", name: "idRole", newName: "Role_idRole");
            RenameColumn(table: "dbo.Reviews", name: "idUser", newName: "User_idUser");
            RenameColumn(table: "dbo.CheckIns", name: "idUser", newName: "User_idUser");
            CreateIndex("dbo.SupplementalLeaves", "User_idUser");
            CreateIndex("dbo.SupplementalLeaves", "Type_idType");
            CreateIndex("dbo.Reviews", "User_idUser");
            CreateIndex("dbo.Users", "Role_idRole");
            CreateIndex("dbo.CheckIns", "User_idUser");
        }
    }
}
