using System.ComponentModel.DataAnnotations;

namespace stay.application.Models
{
    public class User
    {
        public User(string uid, string username, string email, string avatarURL)
        {
            Uid = uid;
            Username = username;
            Email = email;
            AvatarURL = avatarURL;
        }

        public string Uid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string AvatarURL { get; set; }
    }
}