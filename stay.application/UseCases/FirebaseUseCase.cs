using FireSharp;
using Microsoft.Extensions.Configuration;
using stay.application.Interfaces;
using stay.application.Models;
using stay.application.Repository;
using stay.application.Requests;

namespace stay.application.UseCases
{
    public class FirebaseUseCase : AUseCase, IFirebaseUseCase
    {
        public FirebaseClient FirebaseClient { get; }

        public IUserRepository UserRepository { get; }

        public FirebaseUseCase(IConfiguration configuration, IUserRepository userRepository) : base(configuration)
        {
            UserRepository = userRepository;
        }

        public async Task<User> HandleAsync(FirebaseUseCaseRequest request)
        {
            return await UserRepository.GetUserByUUID(request.UserUUID);
        }
    }
}