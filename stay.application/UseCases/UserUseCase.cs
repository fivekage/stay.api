using FireSharp;
using Microsoft.Extensions.Configuration;
using stay.application.Interfaces;
using stay.application.Models;
using stay.application.Repository;
using stay.application.Requests.User;

namespace stay.application.UseCases
{
    public class UserUseCase : AUseCase, IUserUseCase
    {
        public FirebaseClient FirebaseClient { get; }

        public IUserRepository UserRepository { get; }
        public IDirectLinkRepository DirectLinkRepository { get; }

        public UserUseCase(IConfiguration configuration, IUserRepository userRepository, IDirectLinkRepository directLinkRepository) : base(configuration)
        {
            UserRepository = userRepository;
            DirectLinkRepository = directLinkRepository;
        }

        public async Task<User> HandleAsync(UserRequest request)
        {
            return await UserRepository.GetUserByUUID(request.UserUUID);
        }

        public async Task<User> HandleAsync(UserPostRequest request)
        {
            return await UserRepository.RegisterUser(new User(request.Uid, request.Username, request.Email, request.AvatarURL));
        }

        public async Task<bool> HandleAsync(FriendPostRequest request)
        {
            bool areWeFriends = false;
            if (await UserRepository.AddFriend(request.Me, request.FriendUid) && await UserRepository.DoesThisUserLikeMe(request.Me, request.FriendUid))
            {
                areWeFriends = await DirectLinkRepository.AddLink(new DirectLink(Guid.NewGuid().ToString(), new List<string>() { request.Me, request.FriendUid }));
            }
            return areWeFriends;
        }
    }
}