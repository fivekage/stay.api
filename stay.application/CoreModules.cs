using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using stay.application.Interfaces;
using stay.application.Repository;
using stay.application.UseCases;

namespace stay.application
{
    public static class CoreModules
    {
        public static IServiceCollection ImplementPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Singletons
            services.AddSingleton(configuration);
            services.AddSingleton<IFirebaseClient>(
                new FirebaseClient(new FirebaseConfig
                {
                    AuthSecret = configuration["Firebase_AuthSecret"],
                    BasePath = configuration["Firebase_BasePath"],
                })
            );

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            // UseCases
            services.AddScoped<IFirebaseUseCase, FirebaseUseCase>();

            return services;
        }
    }
}