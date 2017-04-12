using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityApp.Models
{
    public class BusStop
    {
        public int Id { get; set;}
        [Display(Name="Название:")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Описание:")]
        [Required]
        public string Description { get; set; }

    }
}