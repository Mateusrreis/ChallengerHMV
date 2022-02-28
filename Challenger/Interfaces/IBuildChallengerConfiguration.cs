using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenger.Interfaces
{
    internal interface IBuildChallengerConfiguration
    {
        IConfiguration Configuration { get; }
    }
}
