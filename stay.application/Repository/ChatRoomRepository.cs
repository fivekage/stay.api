using Firebase.Database;
using FireSharp.Interfaces;
using stay.application.Models;

namespace stay.application.Repository
{
    public class ChatRoomRepository : Repository<ChatRoom>, IChatRoomRepository
    {
        public ChatRoomRepository(IFirebaseClient firebaseClient, FirebaseClient firebaseClientDatabase) : base(firebaseClient, firebaseClientDatabase)
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

        public async Task<List<KeyValuePair<string, ChatRoom>>> GetChatRooms()
        {

            return (await this.GetAllAsync("room"));
            /*var resultFirebase = (await this.GetAsync($"room/*"));
            dynamic resultChatRooms = null;
            try
            {
                return resultChatRooms = resultFirebase.ResultAs<IEnumerable<ChatRoom>>();
            } catch(Exception)
            {
                resultChatRooms = resultFirebase.ResultAs<ChatRoom>();
            }
            return new List<ChatRoom> { resultChatRooms };*/

        }
    }
}