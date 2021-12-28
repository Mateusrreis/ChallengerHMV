using ChallengerHMV.Domain.Authentication;
using ChallengerHMV.Services.AuthenticationService.Interface;

namespace ChallengerHMV.Services.AuthenticationService
{
    public class AuthService : IAuthService
    {
        public async Task<string> LoginUser(AuthUser authUser)
        {
            if (authUser.Username == "admin" && authUser.Password == "testeToken")
            {
                authUser.Role = "admin";
                return TokenService.GenerateToken(authUser);
            }
            return string.Empty;
        }
    }
}
