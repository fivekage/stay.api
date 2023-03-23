using Firebase.Database;
using FireSharp.Interfaces;
using stay.application.Models;
using System;

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

        public async Task<User> RegisterUser(User user)
        {
            return (await this.AddAsync($"user/{user.Uid}", user));
        }
    }
}