using FireSharp.Interfaces;
using stay.application.Models;

namespace stay.application.Repository
{
    public class ChatRoomRepository : Repository<ChatRoom>, IChatRoomRepository
    {
        public ChatRoomRepository(IFirebaseClient firebaseClient) : base(firebaseClient)
        {
        }

        public async Task<bool> AddChatRoom(ChatRoom chatroom)
        {
            return (await this.AddAsync($"room/{chatroom.Uuid}", chatroom)) != null;
        }

        public async Task<bool> DeleteChatRoom(string uuid)
        {
            return (await this.DeleteAsync($"room/{uuid}")).StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<ChatRoom> GetChatRoom(string uuid)
        {
            return (await this.GetAsync($"room/{uuid}")).ResultAs<ChatRoom>();
        }

        public async Task<IEnumerable<ChatRoom>> GetChatRooms()
        {
            return (await this.GetAsync($"room/")).ResultAs<IEnumerable<ChatRoom>>();
        }
    }
}