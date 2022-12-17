namespace stay.application.Requests.ChatRoom
{
    public class ChatRoomDeleteRequest
    {
        public string Uuid { get; set; }

        public ChatRoomDeleteRequest(string uuid)
        {
            Uuid = uuid;
        }
    }
}