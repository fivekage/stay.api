using stay.application.Models;
using stay.application.Requests;

namespace stay.application.Interfaces
{
    public interface IUserUseCase
    {
        Task<User> HandleAsync(UserRequest request);
    }
}