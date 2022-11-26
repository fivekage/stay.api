using stay.application.Models;

namespace stay.application.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByUUID(string uuid);
    }
}