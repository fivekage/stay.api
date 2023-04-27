using stay.application.Models;

namespace stay.application.Repository
{
    public interface IMessageRepository
    {
        Task<bool> PostMessageAsync(Message message);

        Task<string> PostFileAsync(FileCustom file);

        Task<string> GetFileAsync(string filename);

        Task<List<KeyValuePair<string, Message>>> GetMessagesAsync(string chatRoomUid);
    }
}