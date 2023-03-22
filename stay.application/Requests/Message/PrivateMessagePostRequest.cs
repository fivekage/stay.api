using System.ComponentModel.DataAnnotations;

namespace stay.application.Requests.Message
{
    public class PrivateMessagePostRequest : MessagePostRequest
    {
        public PrivateMessagePostRequest(string roomGuid, string message, DateTime writedAt, string writedBy) : base(message, writedAt, writedBy)
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