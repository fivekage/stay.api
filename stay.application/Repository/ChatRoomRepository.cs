using Firebase.Database;
using FireSharp.Interfaces;
using stay.application.Models;

namespace stay.application.Repository
{
    public class ChatRoomRepository : Repository<ChatRoom>, IChatRoomRepository
    {
        public static readonly string PATH = "room/";
        public ChatRoomRepository(IFirebaseClient firebaseClient, FirebaseClient firebaseClientDatabase) : base(firebaseClient, firebaseClientDatabase)
        {
        }

        public async Task<bool> AddChatRoom(ChatRoom chatroom)
        {
            return (await this.AddAsync($"{PATH}{chatroom.Uuid}", chatroom)) != null;
        }

        public async Task<bool> DeleteChatRoom(string uuid)
        {
            return (await this.DeleteAsync($"{PATH}{uuid}")).StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<ChatRoom> GetChatRoom(string uuid)
        {
            return (await this.GetAsync($"{PATH}{uuid}")).ResultAs<ChatRoom>();
        }

        public async Task<List<KeyValuePair<string, ChatRoom>>> GetChatRooms()
        {
            return (await this.GetAllAsync(PATH));
        }
    }
}