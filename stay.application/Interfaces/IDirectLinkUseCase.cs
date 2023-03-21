using stay.application.Models;
using stay.application.Requests.DirectLink;

namespace stay.application.Interfaces
{
    public interface IDirectLinkUseCase
    {
        Task<bool> HandleAsync(DirectLinkPostRequest request);
        Task<DirectLink> HandleAsync(DirectLinkGetRequest request);
        Task<IEnumerable<DirectLink>> HandleAsync(DirectLinksGetRequest request);
    }
}