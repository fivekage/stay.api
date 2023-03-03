using stay.application.Models;

namespace stay.application.Repository
{
    public interface IMessageRepository
    {
        Task<bool> PostMessage(Message message);
    }
}