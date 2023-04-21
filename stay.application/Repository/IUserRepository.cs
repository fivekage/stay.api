using stay.application.Models;

namespace stay.application.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByUUID(string uuid);
        Task<User> RegisterUser(User user);
        Task<bool> AddFriend(string me, string friendUid);
        Task<bool> RemoveFriend(string me, string friendUid);
        Task<bool> DoesThisUserLikeMe(string me, string friendUid);
    }
}