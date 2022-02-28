using Amazon.Lambda.Core;
using Challenger;
using Challenger.DependencyInjection;
using Challenger.Interfaces;
using Microsoft.Extensions.DependencyInjection;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SolucionChallenger
{
    public class Function
    {
        IBuildChallengerConfiguration buildConfiguration;


        public Function()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            buildConfiguration = serviceProvider.GetService<IBuildChallengerConfiguration>();
        }

        /// <summary>
        /// A simple function that takes a string and returns both the upper and lower case version of the string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        //public string ScheduleAppointment(ScheduleCalendarRequestDto input, ILambdaContext context)
        //{

        //}

        public string GetSchedulesAppointment()
        {
            var configuration = buildConfiguration.Configuration["function-name"];
            return configuration;
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBuildChallengerConfiguration, BuildChallengerConfiguration>();
            serviceCollection.AddDependencyRepository();
        }
    }
}
