using Challenger.Models.Models.Interfaces;
using Microsoft.Extensions.Configuration;

using System.IO;

namespace Challenger.Services.Configuration
{
    public class BuildChallengerConfiguration : IBuildChallengerConfiguration
    {
        public IConfiguration Configuration => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("aws-lambda-tools-defaults.json", optional: false, reloadOnChange: true)
            .Build();
    }
}
