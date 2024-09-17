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
            //  
            // Optionally initialise SDKManager to pass custom configurations, logger, etc. 
            // SDKManager sdkManager = SdkManagerBuilder.Create().Build();

            StaticAuthenticationProvider staticAuthenticationProvider = new StaticAuthenticationProvider(token);
            // Instantiate ModelDerivativeClient using the auth provider
            modelDerivativeClient = new ModelDerivativeClient(authenticationProvider: staticAuthenticationProvider);

        }


        #region Jobs
        // Post Job
        public async Task StartJobAsync()
        {
            // set output formats
            List<IJobPayloadFormat> payloadFormats = new List<IJobPayloadFormat>()
            {
            // initialising an Svf2 output class will automatically set the type to Svf2.
                new JobPayloadFormatSVF2()
                    {
                    Views = new List<View>()
                    {
                        View._2d,
                        View._3d
                    },
                    Advanced = new JobPayloadFormatSVF2AdvancedRVT()
                    {
                        GenerateMasterViews =  true
                    }

            },        
            // initialising a Thumbnail output class will automatically set the type to Thumbnail.
            new JobPayloadFormatThumbnail()
            {
                    Advanced = new JobPayloadFormatAdvancedThumbnail (){

                        Width = Width.NUMBER_100, // enum channge to only 100
                        Height = Height.NUMBER_100
                    }
            }
        };

            // specify Job details
            JobPayload Job = new JobPayload()
            {
                Input = new JobPayloadInput()
                {
                    Urn = urn,
                    CompressedUrn = false,
                    RootFilename = "<fileName>",

                },
                Output = new JobPayloadOutput()
                {
                    Formats = payloadFormats,
                    // Destination is obsolete. Use the region header instead.
                    // Destination = new JobPayloadOutputDestination() { Region = Region.US } // This will call the respective endpoint - Either US or EMEA. Defaults to US.
                },
            };

            // start the translation job
            try
            {
                Job jobResponse = await modelDerivativeClient.StartJobAsync(jobPayload: Job, region: Region.US);
                // query for urn, result etc...
                string jobUrn = jobResponse.Urn;
                string jobResult = jobResponse.Result;
            }
            catch
            (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        #endregion


        #region Manifest
        // Get Manifest
        public async Task GetManifestAsync()
        {
            // fetch manifest response
            try
            {
                Manifest manifestResponse = await modelDerivativeClient.GetManifestAsync(urn, region: Region.US);
                // query for urn, progress etc...
                string manifestUrn = manifestResponse.Urn;
                string progress = manifestResponse.Progress;
                // get list of derivatives. Query further to get children etc.
                List<ManifestDerivative> derivatives = manifestResponse.Derivatives;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Delete Manifest.
        public async Task DeleteManifestAsync()
        {
            try
            {
                DeleteManifest deleteManifest = await modelDerivativeClient.DeleteManifestAsync(urn, Region.US);
                var result = deleteManifest.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion


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


        #region MetaData
        // Get list of model views
        public async Task GetModelViewsAsync()
        {
            try
            {
                ModelViews modelViewsResponse = await modelDerivativeClient.GetModelViewsAsync(urn, region: Region.US);
                // get guid from response
                string modelGuid = modelViewsResponse.Data.Metadata.First().Guid;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        // Fetch Object tree
        public async Task GetObjectTreeAsync()
        {
            string modelGuid = Environment.GetEnvironmentVariable("modelGuid")!;
            try
            {
                ObjectTree objectTree = await modelDerivativeClient.GetObjectTreeAsync(urn, modelGuid, Region.US);
                if (objectTree.IsProcessing)
                {
                    // 202 response. Call the endpoint again or iteratively to get 200 OK.
                }
                List<ObjectTreeDataObjects> treeObjects = objectTree.Data.Objects;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        // Fetch specific properties
        public async Task GetSpecificPropertiesAsync()
        {
            string modelGuid = Environment.GetEnvironmentVariable("modelGuid")!;
            // specify the request payload
            SpecificPropertiesPayload payload = new SpecificPropertiesPayload()
            {

                Query = new MatchId()
                {
                    In = new List<object> { MatchIdType.ObjectId, 4088 }
                }

            };

            try
            {
                SpecificProperties specificProperties = await modelDerivativeClient.FetchSpecificPropertiesAsync(urn, modelGuid, specificPropertiesPayload: payload, Region.US);
                if (specificProperties.IsProcessing)
                {
                    // 202 response. Call the endpoint again or iteratively to get 200 OK.
                }
                List<PropertiesDataCollection> propertiesDataCollections = specificProperties.Data.Collection;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        // Fetch all properties
        public async Task GetAllPropertiesAsync()
        {
            string modelGuid = Environment.GetEnvironmentVariable("modelGuid")!;
            try
            {
                Properties allProperties = await modelDerivativeClient.GetAllPropertiesAsync(urn, modelGuid);
                if (allProperties.IsProcessing)
                {
                    // 202 response. Call the endpoint again or iteratively to get 200 OK.
                }
                List<PropertiesDataCollection> propertiesDataCollections = allProperties.Data.Collection;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Thumbnail
        //Fetch Thumbnail
        public async Task GetThumbnailAsync()
        {
            try
            {
                Stream thumbnail = await modelDerivativeClient.GetThumbnailAsync(urn, Width.NUMBER_400, Height.NUMBER_400, Region.US);
                // save thumbnail to local file
                using (var fileStream = new FileStream("/full/path/including/filename", FileMode.Create, FileAccess.Write))
                {
                    thumbnail.CopyTo(fileStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Derivatives
        // Returns a downloadable url including the coookies
        public async Task DownloadDerivativeURLAsync()
        {
            try
            {
                string derivativeUrn = Environment.GetEnvironmentVariable("derivativeUrn")!;
                DerivativeDownload derivativeDownload = await modelDerivativeClient.GetDerivativeUrlAsync(derivativeUrn, urn, Region.US);
                // the below returns a downloadable url including the coookies
                var url = derivativeDownload.Url;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Get Derivative Headers.
        public async Task GetDerivativeHeadersAsync()
        {
            try
            {
                string derivativeUrn = Environment.GetEnvironmentVariable("derivativeUrn")!;
                HttpResponseMessage derivativeHeaders = await modelDerivativeClient.HeadCheckDerivativeAsync(urn, derivativeUrn, Region.US);
                if (derivativeHeaders.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    // 202 response. Call the endpoint again or iteratively to get 200 OK.
                }
                var ContentLength = derivativeHeaders.Content.Headers.ContentLength;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        public async void Main()
        {

            // Initialise SDKManager & ModelDerivativeClient
            ModelDerivative modelDerivative = new ModelDerivative();
            modelDerivative.Initialise();

            //Call respective methods
            await modelDerivative.StartJobAsync();
            await modelDerivative.GetFormatsAsync();
            await modelDerivative.GetManifestAsync();
            await modelDerivative.DeleteManifestAsync();
            await modelDerivative.GetThumbnailAsync();
            await modelDerivative.GetDerivativeHeadersAsync();
            await modelDerivative.DownloadDerivativeURLAsync();
            await modelDerivative.GetModelViewsAsync();
            await modelDerivative.GetObjectTreeAsync();
            await modelDerivative.GetAllPropertiesAsync();
            await modelDerivative.GetSpecificPropertiesAsync();

        }

    }
}