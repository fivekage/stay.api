using Microsoft.Extensions.Configuration;
using stay.application.Interfaces;
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

        public async Task<string> HandleAsync(MessagePostRequest request)
        {
            Guid uid = Guid.NewGuid();
            if (await MessageRepository.PostMessage(new Models.Message(uid.ToString(), request.ChatRoomUid, request.Message, request.WritedAt, request.WritedBy)))
                return uid.ToString();
            return string.Empty;
        }
    }
}