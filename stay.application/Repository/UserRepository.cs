using FireSharp;
using FireSharp.Interfaces;
using stay.application.Models;

namespace stay.application.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IFirebaseClient firebaseClient) : base(firebaseClient)
        {
        }

        public async Task<User> GetUserByUUID(string uuid)
        {
            return (await this.GetAsync($"user/{uuid}")).ResultAs<User>();
        }
    }
}