
using Amazon.Lambda.Core;
using CreateTokenLambda.Helpers;
using CreateTokenLambda.Models;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CreateTokenLambda
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and returns both the upper and lower case version of the string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(AuthUser input, ILambdaContext context)
        {
            return CriptograpyAes.Encriptar(input.User);
        }

        public string HeloWorld()
        {
            return "Helo Word";
        }
    }
}
