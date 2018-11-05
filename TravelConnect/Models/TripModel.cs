using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TravelConnect.Enums;

namespace TravelConnect.Models
{
    public class TripModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        [Display(Name ="Leaving On:")]
        public DateTime TripStartDate { get; set; }
        [Display(Name ="Departing From:")]
        public string DepartureCity { get; set; }
        [Display(Name ="Travelling To:")]
        public string DestinationCity { get; set; }
        [Display(Name = "Returning On:")]
        public DateTime TripEndDate { get; set; }
        [Display(Name ="Trip Length (Nights):")]
        public int TripLength { get; set; }
        [NotMapped]
        public List<string> SubsrcibedUsers { get; set; }
        [Display(Name ="Max Travellers:")]
        public int MaxTravellers { get; set; }
        [Display(Name ="Mode Of Travel:")]
        public TravelMode.Mode TravelMode { get; set; }
        [Display(Name ="Trip Cost:")]
        public decimal Cost { get; set; }
        [Display(Name = "Trip Description:")]
        public string TripDescription { get; set; }
        [NotMapped]
        [Display(Name = "Upload a custom picture:")]
        public IFormFile FileToUpload { get; set; }
        [Display(Name = "Current custom picture:")]
        public string CustomPicturePath { get; set; }
    }
}