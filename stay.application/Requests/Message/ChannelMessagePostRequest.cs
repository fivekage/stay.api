namespace stay.application.Requests.Message
{
    public class ChannelMessagePostRequest : MessagePostRequest
    {
        public ChannelMessagePostRequest(string chatroomuid, string message, DateTime writedAt, string writedBy, string contentType) : base(message, writedAt, writedBy, contentType)
        {
            ChatRoomUid = chatroomuid;
        }

        /// <summary>
        /// Chat Room
        /// </summary>
        public string ChatRoomUid { get; set; }
    }
}