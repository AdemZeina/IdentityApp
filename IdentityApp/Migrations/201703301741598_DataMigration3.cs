namespace IdentityApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusStops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoyageId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Voyages", t => t.VoyageId, cascadeDelete: true)
                .Index(t => t.VoyageId);
            
            CreateTable(
                "dbo.Voyages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartureBusStopId = c.Int(nullable: false),
                        ArrivelBusStopId = c.Int(nullable: false),
                        ArrivelTime = c.DateTime(nullable: false),
                        DepartureTime = c.DateTime(nullable: false),
                        TimeInVoyage = c.DateTime(nullable: false),
                        NumberOfVoyage = c.Int(nullable: false),
                        NameOfVoyage = c.String(),
                        CountSeats = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        ArivelBusStop_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusStops", t => t.ArivelBusStop_Id)
                .ForeignKey("dbo.BusStops", t => t.DepartureBusStopId, cascadeDelete: true)
                .Index(t => t.DepartureBusStopId)
                .Index(t => t.ArivelBusStop_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        CustomerName = c.String(),
                        LastName = c.String(),
                        PassportId = c.Int(nullable: false),
                        NumberOfSeat = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "VoyageId", "dbo.Voyages");
            DropForeignKey("dbo.Voyages", "DepartureBusStopId", "dbo.BusStops");
            DropForeignKey("dbo.Voyages", "ArivelBusStop_Id", "dbo.BusStops");
            DropIndex("dbo.Tickets", new[] { "OrderId" });
            DropIndex("dbo.Voyages", new[] { "ArivelBusStop_Id" });
            DropIndex("dbo.Voyages", new[] { "DepartureBusStopId" });
            DropIndex("dbo.Orders", new[] { "VoyageId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Voyages");
            DropTable("dbo.Orders");
            DropTable("dbo.BusStops");
        }
    }
}
