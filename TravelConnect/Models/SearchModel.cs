using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelConnect.Models
{
    public class SearchModel
    {
        [NotMapped]
        [Display(Name ="Departure City:")]
        public string DepartureCity { get; set; }
        [NotMapped]
        [Display(Name = "Destination City:")]
        public string DestinationCity { get; set; }
        [NotMapped]
        [Display(Name = "Max Trip Cost:")]
        public decimal MaxCost { get; set; }
        [NotMapped]
        [Display(Name = "Trip Length:")]
        public int TripLength { get; set; }
        [NotMapped]
        [Display(Name = "Departure Date:")]
        public DateTime DepartureDate { get; set; }
    }
}
