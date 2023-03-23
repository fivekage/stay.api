namespace stay.application.Requests.User
{
    public class FriendPostRequest
    {
        public string Me { get; set; } = string.Empty;
        public string FriendUid { get; set; } = string.Empty;

        public FriendPostRequest(string me, string friendUid)
        {
            Me = me ?? throw new ArgumentNullException(nameof(me));
            FriendUid = friendUid ?? throw new ArgumentNullException(nameof(friendUid));
        }
    }
}