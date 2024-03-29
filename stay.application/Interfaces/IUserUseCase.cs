﻿using stay.application.Models;
using stay.application.Requests.User;

namespace stay.application.Interfaces
{
    public interface IUserUseCase
    {
        Task<User> HandleAsync(UserRequest request);

        Task<User> HandleAsync(UserPostRequest request);

        Task<bool> HandleAsync(FriendPostRequest request);

        Task<bool> HandleAsync(IsLikedGetRequest request);
    }
}