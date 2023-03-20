using Firebase.Database;
using FireSharp.Interfaces;
using stay.application.Models;

namespace stay.application.Repository
{
    public class DirectLinkRepository : Repository<DirectLink>, IDirectLinkRepository
    {
        private static readonly string PATH = "direct-links/";
        public DirectLinkRepository(IFirebaseClient firebaseClient, FirebaseClient firebaseClientDatabase) : base(firebaseClient, firebaseClientDatabase)
        {
        }

        async Task<bool> IDirectLinkRepository.AddLink(DirectLink link)
        {
            return (await this.AddAsync($"{PATH}{link.Me}-{link.UserUuid}", link)) != null;
        }

        async Task<DirectLink> IDirectLinkRepository.GetLink(string me, string uuid)
        {
            return (await this.GetAsync($"{PATH}{me}-{uuid}")).ResultAs<DirectLink>();
        }

        async Task<List<KeyValuePair<string, DirectLink>>> IDirectLinkRepository.GetLinks()
        {
            return await this.GetAllAsync($"{PATH}");
        }
    }
}