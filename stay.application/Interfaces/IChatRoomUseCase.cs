using stay.application.Models;
using stay.application.Requests.ChatRoom;
using stay.application.Responses;
using stay.application.Responses.ChatRoom;

namespace stay.application.Interfaces
{
    public interface IChatRoomUseCase
    {
        Task<IEnumerable<ChatRoom>> HandleAsync(/*EmptyResponse response*/);
        Task<ChatRoom> HandleAsync(ChatRoomGetRequest request/*, ChatRoomResponse response*/);
        Task<bool> HandleAsync(ChatRoomDeleteRequest request/*, EmptyResponse response*/);
        Task<bool> HandleAsync(ChatRoomPostRequest request/*, EmptyResponse response*/);
    }
}