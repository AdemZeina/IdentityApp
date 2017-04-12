namespace IdentityApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CustomerId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
        }
    }
}
