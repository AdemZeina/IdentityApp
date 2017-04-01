namespace IdentityApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Voyages", "ArivelBusStop_Id", "dbo.BusStops");
            DropForeignKey("dbo.Voyages", "DepartureBusStopId", "dbo.BusStops");
            DropForeignKey("dbo.Orders", "VoyageId", "dbo.Voyages");
            DropForeignKey("dbo.Tickets", "OrderId", "dbo.Orders");
            DropIndex("dbo.Orders", new[] { "VoyageId" });
            DropIndex("dbo.Voyages", new[] { "DepartureBusStopId" });
            DropIndex("dbo.Voyages", new[] { "ArivelBusStop_Id" });
            DropIndex("dbo.Tickets", new[] { "OrderId" });
            AddColumn("dbo.BusStops", "Voyage_Id", c => c.Int());
            AddColumn("dbo.Orders", "Ticket_Id", c => c.Int());
            AddColumn("dbo.Voyages", "Order_Id", c => c.Int());
            CreateIndex("dbo.BusStops", "Voyage_Id");
            CreateIndex("dbo.Orders", "Ticket_Id");
            CreateIndex("dbo.Voyages", "Order_Id");
            AddForeignKey("dbo.BusStops", "Voyage_Id", "dbo.Voyages", "Id");
            AddForeignKey("dbo.Voyages", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Orders", "Ticket_Id", "dbo.Tickets", "Id");
            DropColumn("dbo.Voyages", "ArivelBusStop_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Voyages", "ArivelBusStop_Id", c => c.Int());
            DropForeignKey("dbo.Orders", "Ticket_Id", "dbo.Tickets");
            DropForeignKey("dbo.Voyages", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.BusStops", "Voyage_Id", "dbo.Voyages");
            DropIndex("dbo.Voyages", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "Ticket_Id" });
            DropIndex("dbo.BusStops", new[] { "Voyage_Id" });
            DropColumn("dbo.Voyages", "Order_Id");
            DropColumn("dbo.Orders", "Ticket_Id");
            DropColumn("dbo.BusStops", "Voyage_Id");
            CreateIndex("dbo.Tickets", "OrderId");
            CreateIndex("dbo.Voyages", "ArivelBusStop_Id");
            CreateIndex("dbo.Voyages", "DepartureBusStopId");
            CreateIndex("dbo.Orders", "VoyageId");
            AddForeignKey("dbo.Tickets", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "VoyageId", "dbo.Voyages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Voyages", "DepartureBusStopId", "dbo.BusStops", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Voyages", "ArivelBusStop_Id", "dbo.BusStops", "Id");
        }
    }
}
