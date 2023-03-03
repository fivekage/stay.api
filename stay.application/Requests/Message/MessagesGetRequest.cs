namespace stay.application.Requests.Message
{
    public class MessagesGetRequest
    {
        /// <summary>
        /// Chat Room
        /// </summary>
        public string ChatRoomUid { get; set; }

        public MessagesGetRequest(string chatRoomUid)
        {
            ChatRoomUid = chatRoomUid;
        }
    }
}