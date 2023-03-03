using stay.application.Models;
using stay.application.Requests.Message;

namespace stay.application.Interfaces
{
    public interface IMessageUseCase
    {
        Task<string> HandleAsync(MessagePostRequest request/*EmptyResponse response*/);

        Task<IEnumerable<Message>> HandleAsync(MessagesGetRequest request);
    }
}