using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityApp.Models.BuisnessModels
{
    public class Order
    {
        public int Id { get; set; }
        [Display(Name ="Имя поездки")]
        public int VoyageId { get; set; }
        [Display(Name = "Имя клиента")]
        public string CustomerId { get; set; }
        [Display(Name = "Статус")]
        public string Status { get; set; }

        public List<Voyage> Voyages { get; set; }
        
        
    }
}