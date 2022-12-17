using Microsoft.Extensions.Configuration;

namespace stay.application.UseCases
{
    public abstract class AUseCase
    {
        public IConfiguration Configuration { get; }

        protected AUseCase(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}