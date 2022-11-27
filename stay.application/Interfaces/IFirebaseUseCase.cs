using stay.application.Models;
using stay.application.Requests;
using stay.application.Responses;

namespace stay.application.Interfaces
{
    public interface IFirebaseUseCase
    {
        Task<User> HandleAsync(FirebaseUseCaseRequest request);
    }
}