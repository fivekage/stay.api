using Firebase.Database;
using Firebase.Storage;
using FireSharp.Interfaces;
using stay.application.Models;

namespace stay.application.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private static readonly string PATH = "messages/";

        public MessageRepository(IFirebaseClient firebaseClient, FirebaseClient firebaseClientDatabase, FirebaseStorage firebaseStorage) : base(firebaseClient, firebaseClientDatabase, firebaseStorage)
        {
        }

        public async Task<bool> PostMessageAsync(Message message)
        {
            if (message.GetType() == typeof(ChannelMessage))
            {
                ChannelMessage msg = (ChannelMessage)message;
                return (await this.PushAsync($"{ChatRoomRepository.PATH}{msg.ChatRoomUid}/{PATH}", msg)) != null;
            }
            else if (message.GetType() == typeof(PrivateMessage))
            {
                PrivateMessage msg = (PrivateMessage)message;
                return (await this.PushAsync($"{DirectLinkRepository.PATH}{msg.Guid}/messages/", msg)) != null;
            }
            return false;
        }

        public async Task<List<KeyValuePair<string, Message>>> GetMessagesAsync(string chatRoomUid)
        {
            return await this.GetAllAsync($"{ChatRoomRepository.PATH}{chatRoomUid}/{PATH}");
        }
        public async Task<string> PostFileAsync(FileCustom file)
        {
            return await this.StoreFile(file.Name, file.Content);
        }

        public async Task<string> GetFileAsync(string filename)
        {
            return await this.GetFile(filename);
        }
    }
}