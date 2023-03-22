using Microsoft.Extensions.Configuration;
using stay.application.Interfaces;
using stay.application.Models;
using stay.application.Repository;
using stay.application.Requests.DirectLink;
using System.Linq;

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
            Guid guid = Guid.NewGuid();
            return (await DirectLinkRepository.AddLink(new DirectLink(guid.ToString(), new List<string> () { request.me, request.useruuid } )));
        }

        async Task<IEnumerable<DirectLink>> IDirectLinkUseCase.HandleAsync(DirectLinksGetRequest request)
        {
            return (await DirectLinkRepository.GetLinks(request.Me)).Select(x => x.Value).Where(y => y.Members.Contains(request.Me));
        }

        async Task<DirectLink> IDirectLinkUseCase.HandleAsync(DirectLinkGetRequest request)
        {
            return (await DirectLinkRepository.GetLink(request.Guid));
        }
    }
}