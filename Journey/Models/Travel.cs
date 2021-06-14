using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Journey.Models
{
    public class Travel
    {
        [Key]
        public int JounrneyId { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Display(Name = "City")]
        public string CityStart { get; set; }

        [Display(Name = "Departure from address ")]
        public string AddressStart { get; set; }

        [Display(Name = "From ")]
        public DateTime HourStart { get; set; }

        [Display(Name = "City arrival")]
        public string CityEnd { get; set; }

        [Display(Name = "Address arrival")]
        public string AddressEnd { get; set; }

        [Display(Name = "Hour arrival")]
        public DateTime HourEnd { get; set; }

        [Display(Name = "Free space")]
        public int FreeSpace { get; set; }

        public decimal Price { get; set; }

    }
}