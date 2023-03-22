using System.ComponentModel.DataAnnotations;

namespace stay.api.Models
{
    public class ChannelMessageBodyRequest : MessageBodyRequest
    {
        /// <summary>
        /// Chat Room
        /// </summary>
        [Required]
        public string ChatRoomUid { get; set; } = string.Empty;
    }
}