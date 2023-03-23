using System.ComponentModel.DataAnnotations;

namespace stay.api.Models
{
    public class PrivateMessageBodyRequest : MessageBodyRequest
    {
        /// <summary>
        /// Me (uuid)
        /// </summary>
        [Required]
        public string Guid { get; set; } = string.Empty;
    }
}