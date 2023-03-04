using FireSharp;
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

            _ = services.AddSingleton<Firebase.Database.FirebaseClient>(
                new Firebase.Database.FirebaseClient(Firebase_BasePath.ToString())
            );

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChatRoomRepository, ChatRoomRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            // UseCases
            services.AddScoped<IUserUseCase, UserUseCase>();
            services.AddScoped<IChatRoomUseCase, ChatRoomUseCase>();
            services.AddScoped<IMessageUseCase, MessageUseCase>();

            return services;
        }
    }
}