using stay.application.Models;
using stay.application.Requests.ChatRoom;

namespace stay.application.Interfaces
{
    public interface IChatRoomUseCase
    {
        Task<IEnumerable<ChatRoom>> HandleAsync(/*EmptyResponse response*/);
        Task<ChatRoom> HandleAsync(ChatRoomGetRequest request/*, ChatRoomResponse response*/);
        Task<bool> HandleAsync(ChatRoomDeleteRequest request/*, EmptyResponse response*/);
        Task<string> HandleAsync(ChatRoomPostRequest request/*, EmptyResponse response*/);
        Task<IEnumerable<ChatRoom>> HandleAsync(ChatRoomGetByLocationRequest request/*, ChatRoomResponse response*/);

    }
}