using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelConnect.Models
{
    public class MessagesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }
        public DateTime PostTime { get; set; }
        public int TripId { get; set; }
        [Required]
        public string Post { get; set; }
        public string UserName { get; set; }
    }
}
