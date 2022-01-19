using ChallengerHMV.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengerHMV.Infra.Ioc.Ioc
{
    public static class DependencyDatabase
    {
        public static IServiceCollection AddContextDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<HmvContext>(option => option.UseNpgsql(configuration.GetConnectionString("ConnectionDb")));
    }
}
