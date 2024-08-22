using System.Runtime.CompilerServices;
using Autodesk.ModelDerivative;
using Autodesk.ModelDerivative.Model;
using Autodesk.SDKManager;

namespace Samples
{

    class ModelDerivative
    {
        string? token = Environment.GetEnvironmentVariable("token");
        string? urn = Environment.GetEnvironmentVariable("urn");

        ModelDerivativeClient modelDerivativeClient = null!;

        public void Initialise()
        {
            StaticAuthenticationProvider staticAuthenticationProvider = new StaticAuthenticationProvider(token);
            // Instantiate ModelDerivativeClient using the auth provider
            modelDerivativeClient = new ModelDerivativeClient(authenticationProvider:staticAuthenticationProvider);
        }




        #region Informational
        // Get list of supported Formats
        public async Task GetFormatsAsync()
        {
            try
            {
                SupportedFormats formatsResponse = await modelDerivativeClient.GetFormatsAsync();
                Dictionary<string, List<string>> supportedformats = formatsResponse.Formats;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        #endregion



        public  static void Main()
        {

            // Initialise SDKManager & ModelDerivativeClient
            ModelDerivative modelDerivative = new ModelDerivative();
            modelDerivative.Initialise();

            // Call respective methods
           
             modelDerivative.GetFormatsAsync().Wait();
        
      
        }

    }
}