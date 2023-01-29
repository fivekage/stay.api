﻿using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using stay.application.Interfaces;
using stay.application.Repository;
using stay.application.UseCases;
using Firebase.Database;

namespace stay.application
{
    public static class CoreModules
    {
        public static IServiceCollection ImplementPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Singletons
            services.AddSingleton(configuration);
            services.AddSingleton<IFirebaseClient>(
                new FireSharp.FirebaseClient(new FirebaseConfig
                {
                    AuthSecret = configuration["Firebase_AuthSecret"],
                    BasePath = configuration["Firebase_BasePath"],
                })
            );

            services.AddSingleton<Firebase.Database.FirebaseClient>(
                new Firebase.Database.FirebaseClient(configuration["Firebase_BasePath"].ToString())
            ) ;

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChatRoomRepository, ChatRoomRepository>();

            // UseCases
            services.AddScoped<IUserUseCase, UserUseCase>();
            services.AddScoped<IChatRoomUseCase, ChatRoomUseCase>();

            return services;
        }
    }
}