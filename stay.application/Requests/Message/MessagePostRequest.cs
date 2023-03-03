using System.ComponentModel.DataAnnotations;

namespace stay.application.Requests.Message
{
    public class MessagePostRequest
    {
        /// <summary>
        /// Chat Room
        /// </summary>
        public string ChatRoomUid { get; set; }

        /// <summary>
        /// Message content
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Message date creation
        /// </summary>
        public DateTime WritedAt { get; set; }

        /// <summary>
        /// Uid of the user who writed it
        /// </summary>
        public string WritedBy { get; set; } 

        public MessagePostRequest(string chatRoomUid, string message, DateTime writedAt, string writedBy)
        {
            ChatRoomUid = chatRoomUid;
            Message = message;
            WritedAt = writedAt;
            WritedBy = writedBy;
        }
    }
}