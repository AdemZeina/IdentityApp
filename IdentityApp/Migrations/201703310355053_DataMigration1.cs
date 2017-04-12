Update-Databasenamespace IdentityApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Voyages", "ArivelBusStop_Id", "dbo.BusStops");
            DropForeignKey("dbo.Voyages", "DepartureBusStopId", "dbo.BusStops");
            DropIndex("dbo.Voyages", new[] { "DepartureBusStopId" });
            DropIndex("dbo.Voyages", new[] { "ArivelBusStop_Id" });
            AddColumn("dbo.BusStops", "Voyage_Id", c => c.Int());
            CreateIndex("dbo.BusStops", "Voyage_Id");
            AddForeignKey("dbo.BusStops", "Voyage_Id", "dbo.Voyages", "Id");
            DropColumn("dbo.Voyages", "ArivelBusStop_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Voyages", "ArivelBusStop_Id", c => c.Int());
            DropForeignKey("dbo.BusStops", "Voyage_Id", "dbo.Voyages");
            DropIndex("dbo.BusStops", new[] { "Voyage_Id" });
            DropColumn("dbo.BusStops", "Voyage_Id");
            CreateIndex("dbo.Voyages", "ArivelBusStop_Id");
            CreateIndex("dbo.Voyages", "DepartureBusStopId");
            AddForeignKey("dbo.Voyages", "DepartureBusStopId", "dbo.BusStops", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Voyages", "ArivelBusStop_Id", "dbo.BusStops", "Id");
        }
    }
}
