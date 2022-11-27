using FireSharp.Interfaces;
using Microsoft.Extensions.Configuration;

namespace stay.application.UseCases
{
    public abstract class AUseCase
    {
        public IConfiguration Configuration { get; }

        public AUseCase(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}