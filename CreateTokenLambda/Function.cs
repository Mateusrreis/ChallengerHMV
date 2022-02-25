
using Amazon.Lambda.Core;
using CreateTokenLambda.Helpers;
using CreateTokenLambda.Models;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SolucionChallenger
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and returns both the upper and lower case version of the string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string ScheduleAppointment(ScheduleCalendarRequestDto input, ILambdaContext context)
        {
           
        }

        public string GetSchedulesAppointment()
        {
            return "Helo Word";
        }
    }
}
