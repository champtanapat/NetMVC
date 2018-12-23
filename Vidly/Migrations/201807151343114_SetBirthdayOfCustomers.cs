namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetBirthdayOfCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '1989-01-01 12:00' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
