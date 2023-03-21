using Microsoft.Extensions.Configuration;
using stay.application.Interfaces;
using stay.application.Models;
using stay.application.Repository;
using stay.application.Requests.DirectLink;

namespace stay.application.UseCases
{
    public class DirectLinkUseCase : AUseCase, IDirectLinkUseCase
    {
        public IDirectLinkRepository DirectLinkRepository { get; }
        public DirectLinkUseCase(IConfiguration configuration, IDirectLinkRepository repository) : base(configuration)
        {
            DirectLinkRepository = repository;
        }

        async Task<bool> IDirectLinkUseCase.HandleAsync(DirectLinkPostRequest request)
        {
            return (await DirectLinkRepository.AddLink(new DirectLink(request.me, request.useruuid)));
        }

        async Task<IEnumerable<DirectLink>> IDirectLinkUseCase.HandleAsync(DirectLinksGetRequest request)
        {
            return (await DirectLinkRepository.GetLinks()).Select(x => x.Value).Where(y => y.Me == request.Me || y.UserUuid == request.Me);
        }

        async Task<DirectLink> IDirectLinkUseCase.HandleAsync(DirectLinkGetRequest request)
        {
            return (await DirectLinkRepository.GetLink(request.Me, request.UserUuid));
        }
    }
}