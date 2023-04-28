using Firebase.Database;
using Firebase.Storage;
using FireSharp.Interfaces;
using stay.application.Models;

namespace stay.application.Repository
{
    public class DirectLinkRepository : Repository<DirectLink>, IDirectLinkRepository
    {
        public static readonly string PATH = "direct-link/";
        public DirectLinkRepository(IFirebaseClient firebaseClient, FirebaseClient firebaseClientDatabase, FirebaseStorage firebaseStorage) : base(firebaseClient, firebaseClientDatabase, firebaseStorage)
        {
        }

        async Task<bool> IDirectLinkRepository.AddLink(DirectLink link)
        {
            return (await this.AddAsync($"{PATH}{link.Guid}", link)) != null;
        }

        Task<bool> IDirectLinkRepository.RemoveLink(string me, string userToRemove)
        {
            throw new NotImplementedException("Its normal for moment, this method is not needed");
        }


        async Task<DirectLink> IDirectLinkRepository.GetLink(string guid)
        {
            return (await this.GetAsync($"{PATH}{guid}")).ResultAs<DirectLink>();
        }

        async Task<List<KeyValuePair<string, DirectLink>>> IDirectLinkRepository.GetLinks(string me)
        {
            return (await this.GetAllAsync($"{PATH}"));
        }
    }
}