namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetBirthdayOfMembershipTypes : DbMigration
    {
        public override void Up()
        {
            /*
            Sql("UPDATE MembershipTypes SET Birthdate = '1989-01-01 12:00' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Birthdate = '2010-01-01 12:00' WHERE Id = 2");
            */
            
        }
        
        public override void Down()
        {
        }
    }
}
