using stay.application.Models;

namespace stay.application.Repository
{
    public interface IDirectLinkRepository
    {
        Task<List<KeyValuePair<string, DirectLink>>> GetLinks(string me);
        Task<DirectLink> GetLink(string guid);
        Task<bool> AddLink(DirectLink link);
        Task<bool> RemoveLink(string me, string userToRemove);
    }
}