using stay.application.Models;

namespace stay.application.Responses.ChatRoom
{
    public class ChatRoomResponse : AUseCaseResponse
    {
        public Models.ChatRoom ChatRoom { get; }
        public IEnumerable<Error> Errors { get; } = Enumerable.Empty<Error>();

        public ChatRoomResponse(IEnumerable<Error> errors, bool success = false, string message = "") : base(success, message)
        {
            Errors = errors;
        }

        public ChatRoomResponse(Models.ChatRoom chatRoom, bool success = false, string message = "") : base(success, message)
        {
            ChatRoom = chatRoom;
        }
    }
}
