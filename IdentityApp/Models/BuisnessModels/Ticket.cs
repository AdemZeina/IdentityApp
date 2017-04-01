using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace IdentityApp.Models.BuisnessModels
{
    public class Ticket
    {
        
        public int Id { get; set; }
        [Display(Name = "ID заказа")]
        public int OrderId { get; set; }
        [Display(Name = "Имя клиента")]
        public string CustomerName { get; set; }
        [Display(Name = "Фамилия клиента")]
        public string LastName { get; set; }
        [Display(Name = "Номер паспорта")]
        public int PassportId { get; set; }
        [Display(Name = "Колличество мест")]
        public int NumberOfSeat { get; set; }
        [Display(Name = "Статус билета")]
        public string Status { get; set; }
        
        public List<Order> Orders { get; set; }
    }
}