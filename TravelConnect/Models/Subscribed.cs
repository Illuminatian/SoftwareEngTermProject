using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelConnect.Models
{
    public class Subscribed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TripId { get; set; }
        [ForeignKey("TripId")]
        public TripModel Trip { get; set; }

        public string UserId { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
