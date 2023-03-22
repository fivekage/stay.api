using System.ComponentModel.DataAnnotations;

namespace stay.api.Models
{
    /// <summary>
    /// Message Body Request
    /// </summary>
    public class MessageBodyRequest
    {
        /// <summary>
        /// Message content
        /// </summary>
        [Required]
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Message date creation
        /// </summary>
        [Required]
        public DateTime WritedAt { get; set; }

        /// <summary>
        /// Uid of the user who writed it
        /// </summary>
        [Required]
        public string WritedBy { get; set; } = string.Empty;
    }
}