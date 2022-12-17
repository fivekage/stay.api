using FireSharp;
using Microsoft.Extensions.Configuration;
using stay.application.Interfaces;
using stay.application.Models;
using stay.application.Repository;
using stay.application.Requests;

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
    }
}