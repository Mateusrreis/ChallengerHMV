using Microsoft.Extensions.Configuration;

namespace Challenger.Models.Models.Interfaces
{
    public interface IBuildChallengerConfiguration
    {
        IConfiguration Configuration { get; }
    }
}
