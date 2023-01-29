using Firebase.Database;
using FireSharp.Interfaces;
using stay.application.Models;

namespace stay.application.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IFirebaseClient firebaseClient, FirebaseClient firebaseClientDatabase) : base(firebaseClient, firebaseClientDatabase)
        {
        }

        public async Task<User> GetUserByUUID(string uuid)
        {
            return (await this.GetAsync($"user/{uuid}")).ResultAs<User>();
        }
    }
}