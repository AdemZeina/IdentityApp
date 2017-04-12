namespace IdentityApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatransition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Voyages", "Ticket_Id", c => c.Int());
            AddColumn("dbo.Tickets", "VoyageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Voyages", "Ticket_Id");
            AddForeignKey("dbo.Voyages", "Ticket_Id", "dbo.Tickets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voyages", "Ticket_Id", "dbo.Tickets");
            DropIndex("dbo.Voyages", new[] { "Ticket_Id" });
            DropColumn("dbo.Tickets", "VoyageId");
            DropColumn("dbo.Voyages", "Ticket_Id");
        }
    }
}
