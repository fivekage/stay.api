namespace stay.application.Requests.ChatRoom
{
    public class ChatRoomGetRequest
    {
        public string Uuid { get; set; }

        public ChatRoomGetRequest(string uuid)
        {
            Uuid = uuid;
        }
    }
}