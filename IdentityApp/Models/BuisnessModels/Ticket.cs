using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityApp.Models.BuisnessModels
{
    public class Ticket
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string LastName { get; set; }
        public int PassportId { get; set; }
        public int NumberOfSeat { get; set; }
        public string Status { get; set; }
        public Order Order { get; set; }

    }
}