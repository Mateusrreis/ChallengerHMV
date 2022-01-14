using ChallengerHMV.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengerHMV.Infra.Ioc.Ioc
{
    public static class DependencyDatabase
    {
        public static IServiceCollection AddContextDatabase(this IServiceCollection services)
            => services.AddDbContext<HmvContext>();
    }
}
