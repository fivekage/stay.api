using Firebase.Database;
using FireSharp.Interfaces;
using stay.application.Models;
using System;

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

        public async Task<List<KeyValuePair<string, Message>>> GetMessages(string chatRoomUid)
        {
            return await this.GetAllAsync($"{ChatRoomRepository.PATH}{chatRoomUid}/{PATH}");
        }
    }
}