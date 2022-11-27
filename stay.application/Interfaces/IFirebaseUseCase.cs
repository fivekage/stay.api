using stay.application.Models;
using stay.application.Requests;

namespace stay.application.Interfaces
{
    public interface IFirebaseUseCase
    {
        Task<User> HandleAsync(FirebaseUseCaseRequest request);
    }
}