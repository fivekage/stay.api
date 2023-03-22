using stay.application.Models;
using stay.application.Requests.Message;

namespace stay.application.Interfaces
{
    public interface IMessageUseCase
    {
        Task<string> HandleAsync(ChannelMessagePostRequest request/*EmptyResponse response*/);
        Task<string> HandleAsync(PrivateMessagePostRequest request);

        Task<IEnumerable<Message>> HandleAsync(MessagesGetRequest request);
    }
}