using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityApp.Models
{
    public class Voyage
    {
        public int Id { get; set; }
        public int DepartureBusStopId { get; set; }
        public int ArrivelBusStopId { get; set; }
        public DateTime ArrivelTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime TimeInVoyage { get; set; }
        public int NumberOfVoyage { get; set; }
        public string NameOfVoyage { get; set; }
        public int CountSeats { get; set; }
        public int Price { get; set; }
        public BusStop ArivelBusStop { get; set; }
        public BusStop DepartureBusStop { get; set; }
    }
}