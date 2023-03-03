using Firebase.Database;
using FireSharp.Interfaces;
using stay.application.Models;

namespace stay.application.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private static readonly string PATH = "messages/";

        public MessageRepository(IFirebaseClient firebaseClient, FirebaseClient firebaseClientDatabase) : base(firebaseClient, firebaseClientDatabase)
        {
        }

        public async Task<bool> PostMessage(Message message)
        {
            return (await this.AddAsync($"{ChatRoomRepository.PATH}{message.ChatRoomUid}/{PATH}{message.Uid}", message)) != null;
        }

        public async Task<List<KeyValuePair<string, Message>>> GetMessages(string chatRoomUid)
        {
            return await this.GetAllAsync($"{ChatRoomRepository.PATH}{chatRoomUid}/{PATH}");
        }
    }
}