using Challenger.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Challenger
{
    internal class BuildChallengerConfiguration : IBuildChallengerConfiguration
    {
        public IConfiguration Configuration => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("aws-lambda-tools-defaults.json", optional: false, reloadOnChange: true)
            .Build();
    }
}
