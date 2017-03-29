namespace IdentityApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime());
        }
    }
}
