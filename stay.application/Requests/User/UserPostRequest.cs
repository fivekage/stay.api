namespace stay.application.Requests.User
{
    public class UserPostRequest
    {
        public UserPostRequest(string uid, string username, string email, string avatarURL)
        {
            Uid = uid ?? throw new ArgumentNullException(nameof(uid));
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            AvatarURL = avatarURL ?? string.Empty;
        }

        public string Uid { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string AvatarURL { get; set; } = string.Empty;
    }
}
