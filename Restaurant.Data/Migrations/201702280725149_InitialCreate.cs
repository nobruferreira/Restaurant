namespace Restaurant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plate", "PlateName", c => c.String(nullable: false, maxLength: 80));
            AddColumn("dbo.Restaurant", "RestaurantName", c => c.String(nullable: false, maxLength: 40));
            DropColumn("dbo.Plate", "Name");
            DropColumn("dbo.Restaurant", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurant", "Name", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Plate", "Name", c => c.String(nullable: false, maxLength: 80));
            DropColumn("dbo.Restaurant", "RestaurantName");
            DropColumn("dbo.Plate", "PlateName");
        }
    }
}
