using Journey.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Journey.ViewModels.Travels
{
    public class TravelVM
    {
        public string Search { get; set; }
        public List<Travel> Items { get; set;}

        public int JounrneyId { get; set; }

        
        public int UserId { get; set; }
        public User User { get; set; }

        [Display(Name = "Departure City")]
        public string CityStart { get; set; }

        [Display(Name = "Departure from address ")]
        public string AddressStart { get; set; }

        [Display(Name = "Departure hour (1/1/0001 12:00:00 AM)")]
        public DateTime HourStart { get; set; }

        [Display(Name = "City arrival")]
        public string CityEnd { get; set; }

        [Display(Name = "Address arrival")]
        public string AddressEnd { get; set; }

        [Display(Name = "Hour arrival (1/1/0001 12:00:00 AM)")]
        public DateTime HourEnd { get; set; }

        [Display(Name = "Free spaces")]
        public int FreeSpace { get; set; }

        public decimal Price { get; set; }



        public string SearchByDeparure { get; set; }
        public string SearchByArrival { get; set; }
        public DateTime? SearchByHourDeparure { get; set; }
        public DateTime? SearchByHourArrival { get; set; }

    }
}