using ChallengerHMV.Domain.Entities;

namespace ChallengerHMV.Domain.Authentication
{
    public class AuthUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Role> Role { get; set; }
    }
}
