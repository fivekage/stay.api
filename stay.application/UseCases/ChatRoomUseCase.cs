using FireSharp;
using Microsoft.Extensions.Configuration;
using stay.application.Interfaces;
using stay.application.Models;
using stay.application.Repository;
using stay.application.Requests.ChatRoom;
using System.Device.Location;
using System.Linq;

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
            return (await ChatRoomRepository.GetChatRooms()).Select(x => x.Value);
        }

        async Task<ChatRoom> IChatRoomUseCase.HandleAsync(ChatRoomGetRequest request/*, ChatRoomResponse response*/)
        {
            return (await ChatRoomRepository.GetChatRoom(request.Uuid));
        }

        async Task<bool> IChatRoomUseCase.HandleAsync(ChatRoomDeleteRequest request/*, EmptyResponse response*/)
        {
            return (await ChatRoomRepository.DeleteChatRoom(request.Uuid));
        }

        async Task<string> IChatRoomUseCase.HandleAsync(ChatRoomPostRequest request/*, EmptyResponse response*/)
        {
            Guid uid = Guid.NewGuid();
            if(await ChatRoomRepository.AddChatRoom(
                new ChatRoom(
                    uid.ToString(),
                    request.Name,
                    request.Description, 
                    request.CreatedBy, 
                    DateTime.Now, 
                    request.Active, 
                    request.Longitude, 
                    request.Latitude,
                    request.Radius,
                    request.CircleColor,
                    new Dictionary<string, object>()))) {
                return uid.ToString();
            }
            return string.Empty;
        }

        async Task<IEnumerable<ChatRoom>> IChatRoomUseCase.HandleAsync(ChatRoomGetByLocationRequest request)
        {
            GeoCoordinate userCoord = new GeoCoordinate(request.Latitude, request.Longitude);

            List<ChatRoom> chatRooms = new List<ChatRoom>();

            foreach(var rooms in await ChatRoomRepository.GetChatRooms())
            {
                var roomsCoord = new GeoCoordinate(rooms.Value.Latitude, rooms.Value.Longitude);
                if (userCoord.GetDistanceTo(roomsCoord) < rooms.Value.Radius)
                    chatRooms.Add(rooms.Value);
            }
            return chatRooms;
        }
    }
}