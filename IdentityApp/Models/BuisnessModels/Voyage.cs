using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityApp.Models
{
    public class Voyage
    {
        public int Id { get; set; }
        [Display(Name = "Пункт отпарвления")]
        public int DepartureBusStopId { get; set; }
        [Display(Name = "Пункт прибытия")]
        public int ArrivelBusStopId { get; set; }
        [Display(Name = "Время прибытия")]
        public DateTime ArrivelTime { get; set; }
        [Display(Name = "Время отправления")]
        public DateTime DepartureTime { get; set; }
        [Display(Name = "Время в пути")]
        public double TimeInVoyage { get; set; }
        [Display(Name = "Номер поездки")]
        public int NumberOfVoyage { get; set; }
        [Display(Name = "Название поездки")]
        public string NameOfVoyage { get; set; }
        [Display(Name = "Колличество мест")]
        public int CountSeats { get; set; }
        [Display(Name = "Цена")]
        public int Price { get; set; }
        public BusStop ArivelBusStop { get; set; }
        public BusStop DepartureBusStop { get; set; }
    }
}