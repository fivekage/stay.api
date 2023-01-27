using System.ComponentModel.DataAnnotations;

namespace stay.api.Models
{
    public class ChatRoomBodyRequest
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public double Radius { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public string Color { get; set; }
    }
}