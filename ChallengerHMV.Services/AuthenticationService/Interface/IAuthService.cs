using ChallengerHMV.Domain.Authentication;

namespace ChallengerHMV.Services.AuthenticationService.Interface
{
    public interface IAuthService
    {
        Task<string> LoginUser(AuthUser authUser);
    }
}
