using Ardalis.GuardClauses;
using System.ComponentModel.DataAnnotations;

namespace stay.api.Models
{
    public class ChatRoomBodyRequest
    {

        [Required]
        public string Uuid { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }

    }
}
