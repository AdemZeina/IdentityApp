namespace IdentityApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatransfer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "SeatNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "SeatNumber");
        }
    }
}
