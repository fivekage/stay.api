namespace stay.application.Models
{
    public class ChannelMessage : Message
    {
        public ChannelMessage(string chatRoomUid, string message, DateTime writedAt, string writedBy, string contentType) : base(message, writedAt, writedBy, contentType)
        {
            ChatRoomUid = chatRoomUid;
        }

        /// <summary>
        /// Chat Room
        /// </summary>
        public string ChatRoomUid { get; set; }
    }
}