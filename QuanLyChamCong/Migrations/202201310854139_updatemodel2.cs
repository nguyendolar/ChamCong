namespace QuanLyChamCong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodel2 : DbMigration
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
                        idUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCheckIn)
                .ForeignKey("dbo.Users", t => t.idUser)
                .Index(t => t.idUser);
            
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
                        gender = c.String(),
                        status = c.Int(nullable: false),
                        idRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idUser)
                .ForeignKey("dbo.Roles", t => t.idRole)
                .Index(t => t.idRole);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        idReview = c.Int(nullable: false, identity: true),
                        content = c.String(nullable: false),
                        status = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idReview)
                .ForeignKey("dbo.Users", t => t.idUser)
                .Index(t => t.idUser);
            
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
                        idUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idSalary)
                .ForeignKey("dbo.Users", t => t.idUser)
                .Index(t => t.idUser);
            
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
                        idType = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idSupplementalLeave)
                .ForeignKey("dbo.Types", t => t.idType)
                .ForeignKey("dbo.Users", t => t.idUser)
                .Index(t => t.idType)
                .Index(t => t.idUser);
            
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
            DropForeignKey("dbo.SupplementalLeaves", "idUser", "dbo.Users");
            DropForeignKey("dbo.SupplementalLeaves", "idType", "dbo.Types");
            DropForeignKey("dbo.Salaries", "idUser", "dbo.Users");
            DropForeignKey("dbo.Users", "idRole", "dbo.Roles");
            DropForeignKey("dbo.Reviews", "idUser", "dbo.Users");
            DropForeignKey("dbo.CheckIns", "idUser", "dbo.Users");
            DropIndex("dbo.SupplementalLeaves", new[] { "idUser" });
            DropIndex("dbo.SupplementalLeaves", new[] { "idType" });
            DropIndex("dbo.Salaries", new[] { "idUser" });
            DropIndex("dbo.Reviews", new[] { "idUser" });
            DropIndex("dbo.Users", new[] { "idRole" });
            DropIndex("dbo.CheckIns", new[] { "idUser" });
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
