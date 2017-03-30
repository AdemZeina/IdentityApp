using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityApp.Models.BuisnessModels
{
    public class Order
    {
        public int Id { get; set; }
        public int VoyageId { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
        
        public Voyage Voyage { get; set; }
    }
}