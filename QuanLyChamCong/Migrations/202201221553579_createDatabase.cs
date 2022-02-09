namespace QuanLyChamCong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckIns",
                c => new
                    {
                        idCheckIn = c.Int(nullable: false, identity: true),
                        checkIn = c.Time(nullable: false, precision: 7),
                        checkOut = c.Time(nullable: false, precision: 7),
                        timeLate = c.Time(nullable: false, precision: 7),
                        date = c.DateTime(nullable: false),
                        reason = c.String(nullable: false, maxLength: 255),
                        status = c.Int(nullable: false),
                        report = c.String(nullable: false, maxLength: 255),
                        User_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idCheckIn)
                .ForeignKey("dbo.Users", t => t.User_idUser)
                .Index(t => t.User_idUser);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        idUser = c.Int(nullable: false, identity: true),
                        fullName = c.String(nullable: false, maxLength: 255),
                        userName = c.String(nullable: false, maxLength: 255),
                        password = c.String(nullable: false, maxLength: 255),
                        phoneNumber = c.String(maxLength: 255),
                        address = c.String(maxLength: 255),
                        status = c.Int(nullable: false),
                        Role_idRole = c.Int(),
                        Salary_idSalary = c.Int(),
                    })
                .PrimaryKey(t => t.idUser)
                .ForeignKey("dbo.Roles", t => t.Role_idRole)
                .ForeignKey("dbo.Salaries", t => t.Salary_idSalary)
                .Index(t => t.Role_idRole)
                .Index(t => t.Salary_idSalary);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        idReview = c.Int(nullable: false, identity: true),
                        content = c.String(nullable: false),
                        status = c.Int(nullable: false),
                        User_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idReview)
                .ForeignKey("dbo.Users", t => t.User_idUser)
                .Index(t => t.User_idUser);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        idRole = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.idRole);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        idSalary = c.Int(nullable: false, identity: true),
                        salary = c.Single(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idSalary);
            
            CreateTable(
                "dbo.SupplementalLeaves",
                c => new
                    {
                        idSupplementalLeave = c.Int(nullable: false, identity: true),
                        checkIn = c.Time(nullable: false, precision: 7),
                        checkOut = c.Time(nullable: false, precision: 7),
                        timeLate = c.Time(nullable: false, precision: 7),
                        date = c.DateTime(nullable: false),
                        reason = c.String(nullable: false, maxLength: 255),
                        status = c.Int(nullable: false),
                        Type_idType = c.Int(),
                        User_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.idSupplementalLeave)
                .ForeignKey("dbo.Types", t => t.Type_idType)
                .ForeignKey("dbo.Users", t => t.User_idUser)
                .Index(t => t.Type_idType)
                .Index(t => t.User_idUser);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        idType = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.idType);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplementalLeaves", "User_idUser", "dbo.Users");
            DropForeignKey("dbo.SupplementalLeaves", "Type_idType", "dbo.Types");
            DropForeignKey("dbo.Users", "Salary_idSalary", "dbo.Salaries");
            DropForeignKey("dbo.Users", "Role_idRole", "dbo.Roles");
            DropForeignKey("dbo.Reviews", "User_idUser", "dbo.Users");
            DropForeignKey("dbo.CheckIns", "User_idUser", "dbo.Users");
            DropIndex("dbo.SupplementalLeaves", new[] { "User_idUser" });
            DropIndex("dbo.SupplementalLeaves", new[] { "Type_idType" });
            DropIndex("dbo.Reviews", new[] { "User_idUser" });
            DropIndex("dbo.Users", new[] { "Salary_idSalary" });
            DropIndex("dbo.Users", new[] { "Role_idRole" });
            DropIndex("dbo.CheckIns", new[] { "User_idUser" });
            DropTable("dbo.Types");
            DropTable("dbo.SupplementalLeaves");
            DropTable("dbo.Salaries");
            DropTable("dbo.Roles");
            DropTable("dbo.Reviews");
            DropTable("dbo.Users");
            DropTable("dbo.CheckIns");
        }
    }
}
