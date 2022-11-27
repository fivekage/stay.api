using Ardalis.GuardClauses;

namespace stay.application.Requests
{
    public class FirebaseUseCaseRequest
    {
        public string UserUUID { get; set; }

        public FirebaseUseCaseRequest(string userUUID)
        {
            Guard.Against.Null(userUUID, nameof(userUUID));
            UserUUID = userUUID;
        }
    }
}