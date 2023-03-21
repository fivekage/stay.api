using System.ComponentModel.DataAnnotations;

namespace stay.api.Models
{
    public class DirectLinkBodyRequest
    {
        /* temporary bc cannot decode token now due to google issue */

        [Required]
        public string me { get; set; }

        [Required]
        public string useruuid { get; set; }
    }
}