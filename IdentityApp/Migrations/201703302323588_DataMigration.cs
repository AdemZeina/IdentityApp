namespace IdentityApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Voyages", "TimeInVoyage", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voyages", "TimeInVoyage", c => c.Time(nullable: false, precision: 7));
        }
    }
}
