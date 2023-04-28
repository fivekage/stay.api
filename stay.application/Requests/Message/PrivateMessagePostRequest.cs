using System.ComponentModel.DataAnnotations;

namespace stay.application.Requests.Message
{
    public class PrivateMessagePostRequest : MessagePostRequest
    {
        public PrivateMessagePostRequest(string roomGuid, string message, DateTime writedAt, string writedBy, string contentType) : base(message, writedAt, writedBy, contentType)
        {
            Guid = roomGuid;
        }

        /// <summary>
        /// Me (uuid)
        /// </summary>
        [Required]
        public string Guid { get; set; }
    }
}