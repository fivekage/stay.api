using FireSharp;
using Microsoft.Extensions.Configuration;
using stay.application.Interfaces;
using stay.application.Models;
using stay.application.Repository;
using stay.application.Requests.ChatRoom;
using stay.application.Responses;
using stay.application.Responses.ChatRoom;

namespace stay.application.UseCases
{
    public class ChatRoomUseCase : AUseCase, IChatRoomUseCase
    {
        public FirebaseClient FirebaseClient { get; }

        public IChatRoomRepository ChatRoomRepository { get; }

        public ChatRoomUseCase(IConfiguration configuration, IChatRoomRepository chatRoomRepository) : base(configuration)
        {
            ChatRoomRepository = chatRoomRepository;
        }

        async Task<IEnumerable<ChatRoom>> IChatRoomUseCase.HandleAsync(/*EmptyResponse response*/)
        {
            return (await ChatRoomRepository.GetChatRooms());
        }

        async Task<ChatRoom> IChatRoomUseCase.HandleAsync(ChatRoomGetRequest request/*, ChatRoomResponse response*/)
        {
            return (await ChatRoomRepository.GetChatRoom(request.Uuid));
        }

        async Task<bool> IChatRoomUseCase.HandleAsync(ChatRoomDeleteRequest request/*, EmptyResponse response*/)
        {
            return (await ChatRoomRepository.DeleteChatRoom(request.Uuid));
        }

        async Task<bool> IChatRoomUseCase.HandleAsync(ChatRoomPostRequest request/*, EmptyResponse response*/)
        {
            return (await ChatRoomRepository.AddChatRoom(
                new ChatRoom(request.Uuid ,request.CreatedBy, DateTime.Now, request.Active, request.Longitude, request.Latitude)));
        }
    }
}