namespace stay.application.Models
{
    public class ChannelMessage : Message
    {
        public ChannelMessage(string chatRoomUid, string message, DateTime writedAt, string writedBy) : base(message, writedAt, writedBy)
        {
            ChatRoomUid = chatRoomUid;
        }

        /// <summary>
        /// Chat Room
        /// </summary>
        public string ChatRoomUid { get; set; }
    }
}