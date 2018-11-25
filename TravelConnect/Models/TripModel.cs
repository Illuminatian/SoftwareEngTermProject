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
        [DataType(DataType.Date)]
        [Required]
        public DateTime? TripStartDate { get; set; }
        [Display(Name ="Departing From:")]
        [Required]
        public string DepartureCity { get; set; }
        [Display(Name ="Travelling To:")]
        [Required]
        public string DestinationCity { get; set; }
        [Display(Name = "Returning On:")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime? TripEndDate { get; set; }
        [Display(Name ="Trip Length (Nights):")]
        [Required]
        public int TripLength { get; set; }
        [NotMapped]
        public List<SubscribedUsers> SubscribedUsers { get; set; }
        [Display(Name ="Max Travellers:")]
        [Required]
        public int MaxTravellers { get; set; }
        [Display(Name ="Mode Of Travel:")]
        [Required]
        public TravelMode.Mode TravelMode { get; set; }
        [Display(Name ="Trip Cost:")]
        [Required]
        public decimal Cost { get; set; }
        [Display(Name = "Trip Description:")]
        [Required]
        public string TripDescription { get; set; }
        [NotMapped]
        [Display(Name = "Upload a custom picture:")]
        public IFormFile FileToUpload { get; set; }
        [Display(Name = "Current custom picture:")]
        public string CustomPicturePath { get; set; }
        [NotMapped]
        [Display(Name ="Subscribe to Trip:")]
        public bool Subscribed { get; set; }
        [NotMapped]
        public bool Confirmed { get; set; }
        [NotMapped]
        public List<MessagesModel> Messages { get; set; }
        [NotMapped]
        [Display(Name = "Post a trip message:")]
        public string Message { get; set; }

        public TripModel()
        {
            this.SubscribedUsers = new List<SubscribedUsers>();
        }
    }
}