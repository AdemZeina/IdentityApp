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
        
        public int VoyageId { get; set; }
        public int CustomerId { get; set; }
        [Display(Name = "Статус")]
        public string Status { get; set; }
        
        public Voyage Voyage { get; set; }
    }
}