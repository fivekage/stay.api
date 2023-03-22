namespace stay.application.Requests.Message
{
    public class ChannelMessagePostRequest : MessagePostRequest
    {
        public ChannelMessagePostRequest(string chatroomuid, string message, DateTime writedAt, string writedBy) : base(message, writedAt, writedBy)
        {
            ChatRoomUid = chatroomuid;
        }

        /// <summary>
        /// Chat Room
        /// </summary>
        public string ChatRoomUid { get; set; }
    }
}