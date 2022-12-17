using Ardalis.GuardClauses;

namespace stay.application.Requests.User
{
    public class UserRequest
    {
        public string UserUUID { get; set; }

        public UserRequest(string userUUID)
        {
            Guard.Against.Null(userUUID, nameof(userUUID));
            UserUUID = userUUID;
        }
    }
}