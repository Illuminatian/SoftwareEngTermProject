using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelConnect.Models
{
    public class SearchModel
    {
        [NotMapped]
        public string DepartureCity { get; set; }
        [NotMapped]
        public string DestinationCity { get; set; }
        [NotMapped]
        public decimal MaxCost { get; set; }
        [NotMapped]
        public int TripLength { get; set; }
        [NotMapped]
        public DateTime DepartureDate { get; set; }
    }
}
