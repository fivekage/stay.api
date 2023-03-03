namespace stay.application.Models
{
    public class Message
    {
        /// <summary>
        /// Uid
        /// </summary>
        public string Uid { get; set; }
        /// <summary>
        /// Chat Room
        /// </summary>
        public string ChatRoomUid { get; set; }

        /// <summary>
        /// Message content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Message date creation
        /// </summary>
        public DateTime WritedAt { get; set; }

        /// <summary>
        /// Uid of the user who writed it
        /// </summary>
        public string WritedBy { get; set; }

        public Message(string uid, string chatRoomUid, string message, DateTime writedAt, string writedBy)
        {
            Uid = uid;
            ChatRoomUid = chatRoomUid;
            Content = message;
            WritedAt = writedAt;
            WritedBy = writedBy;
        }
    }
}