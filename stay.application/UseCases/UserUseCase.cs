using FireSharp;
using Microsoft.Extensions.Configuration;
using stay.application.Interfaces;
using stay.application.Models;
using stay.application.Repository;
using stay.application.Requests;
using stay.application.Requests.User;

namespace stay.application.UseCases
{
    public class UserUseCase : AUseCase, IUserUseCase
    {
        public FirebaseClient FirebaseClient { get; }

        public IUserRepository UserRepository { get; }

        public UserUseCase(IConfiguration configuration, IUserRepository userRepository) : base(configuration)
        {
            UserRepository = userRepository;
        }

        public async Task<User> HandleAsync(UserRequest request)
        {
            return await UserRepository.GetUserByUUID(request.UserUUID);
        }

        public async Task<User> HandleAsync(UserPostRequest request)
        {
            return await UserRepository.RegisterUser(new User(request.Uid, request.Username, request.Email, request.AvatarURL));
        }
    }
}