namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime());
            DropColumn("dbo.MembershipTypes", "Birthdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "Birthdate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}
