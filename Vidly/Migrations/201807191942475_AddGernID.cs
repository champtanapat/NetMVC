namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGernID : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "MyProperty");
            DropColumn("dbo.Movies", "GenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "MyProperty", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}
