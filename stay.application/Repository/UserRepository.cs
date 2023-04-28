using Firebase.Database;
using Firebase.Storage;
using FireSharp.Interfaces;
using stay.application.Models;
using System;

namespace stay.application.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IFirebaseClient firebaseClient, FirebaseClient firebaseClientDatabase, FirebaseStorage firebaseStorage) : base(firebaseClient, firebaseClientDatabase, firebaseStorage)
        {
        }

        public async Task<bool> AddFriend(string me, string friendUid)
        {
            if (!(await this.GetAllAsync($"user/{me}/likes/")).Select(x => x.Value.Uid).Any(y => y == friendUid))
                return (await this.PushAsync($"user/{me}/likes/", new User(friendUid))) != null;
            else
                return false;
        }

        public async Task<bool> RemoveFriend(string me, string friendUid)
        {
            string? userToRemove = (await this.GetAllAsync($"user/{me}/likes/")).Where(x => x.Value.Uid == friendUid).Select(x => x.Key).FirstOrDefault();
            if (!string.IsNullOrEmpty(userToRemove))
                return (await this.DeleteAsync($"user/{me}/likes/{userToRemove}")) != null;
            else
                return false;
        }

        public async Task<bool> DoesThisUserLikeMe(string me, string friendUid)
        {
            return (await this.GetAllAsync($"user/{friendUid}/likes/")).Select(x => x.Value.Uid).Any(y => y == me);
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