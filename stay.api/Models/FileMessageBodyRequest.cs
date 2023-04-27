using System.ComponentModel.DataAnnotations;

namespace stay.api.Models
{
    public class FileMessageBodyRequest
    {
        /// <summary>
        /// File to store
        /// </summary>
        [Required]
        public IFormFile File { get; set; }
    }
}