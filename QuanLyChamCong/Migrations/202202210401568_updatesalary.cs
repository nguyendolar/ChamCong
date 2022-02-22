namespace QuanLyChamCong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesalary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salaries", "month", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salaries", "month");
        }
    }
}
