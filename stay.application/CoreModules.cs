﻿using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using stay.application.Interfaces;
using stay.application.Repository;
using stay.application.UseCases;
using Firebase.Database;
using Firebase.Storage;

namespace stay.application
{
    public static class CoreModules
    {
        public static IServiceCollection ImplementPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string Firebase_BasePath = configuration["Firebase_BasePath"] ?? string.Empty;
            // Singletons
            services.AddSingleton(configuration);
            services.AddSingleton<IFirebaseClient>(
                new FireSharp.FirebaseClient(new FirebaseConfig
                {
                    AuthSecret = configuration["Firebase_AuthSecret"],
                    BasePath = Firebase_BasePath,
                })
            );
            services.AddSingleton<FirebaseStorage>(
                new FirebaseStorage(configuration["Firebase_Storage"])
            );

            _ = services.AddSingleton<Firebase.Database.FirebaseClient>(
                new Firebase.Database.FirebaseClient(Firebase_BasePath)
            );

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChatRoomRepository, ChatRoomRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IDirectLinkRepository, DirectLinkRepository>();

            // UseCases
            services.AddScoped<IUserUseCase, UserUseCase>();
            services.AddScoped<IChatRoomUseCase, ChatRoomUseCase>();
            services.AddScoped<IMessageUseCase, MessageUseCase>();
            services.AddScoped<IDirectLinkUseCase, DirectLinkUseCase>();

            return services;
        }
    }
}