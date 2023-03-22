using Microsoft.Extensions.Configuration;
using stay.application.Interfaces;
using stay.application.Models;
using stay.application.Repository;
using stay.application.Requests.Message;

namespace stay.application.UseCases
{
    public class MessageUseCase : AUseCase, IMessageUseCase
    {
        public IMessageRepository MessageRepository { get; }

        public MessageUseCase(IConfiguration configuration, IMessageRepository messageRepository) : base(configuration)
        {
            MessageRepository = messageRepository;
        }

        public async Task<string> HandleAsync(ChannelMessagePostRequest request)
        {
            if (await MessageRepository.PostMessage(new ChannelMessage(request.ChatRoomUid, request.Message, request.WritedAt, request.WritedBy)))
                return request.ChatRoomUid;
            return string.Empty;
        }

        public async Task<IEnumerable<Message>> HandleAsync(MessagesGetRequest request)
        {
            return (await MessageRepository.GetMessages(request.ChatRoomUid)).Select(x => x.Value);
        }

        public async Task<string> HandleAsync(PrivateMessagePostRequest request)
        {
            Guid uid = Guid.NewGuid();
            if (await MessageRepository.PostMessage(new PrivateMessage(request.Guid, request.Message, request.WritedAt, request.WritedBy)))
                return uid.ToString();
            return string.Empty;
        }
    }
}