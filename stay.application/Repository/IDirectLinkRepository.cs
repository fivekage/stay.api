using stay.application.Models;

namespace stay.application.Repository
{
    public interface IDirectLinkRepository
    {
        Task<List<KeyValuePair<string, DirectLink>>> GetLinks();
        Task<DirectLink> GetLink(string me, string uuid);
        Task<bool> AddLink(DirectLink link);
    }
}