using Autodesk.ModelDerivative;
using Autodesk.ModelDerivative.Model;
using Autodesk.SDKManager;

namespace Samples
{

    class ModelDerivative
    {
        string token = "<token>";
        string urn = "<urn>";
        ModelDerivativeClient modelDerivativeClient = null!;


        public void Initialise()
        {
            // Instantiate SDK manager as below.   
            // You can also optionally pass configurations, logger, etc. 
            SDKManager sdkManager = SdkManagerBuilder
                  .Create() // Creates SDK Manager Builder itself.
                  .Build();


            // Instantiate ModelDerivativeClient using the created SDK manager
            modelDerivativeClient = new ModelDerivativeClient(sdkManager);
        }


        // Post Job
        public async Task StartJobAsync()
        {
            // set output formats
            List<JobPayloadFormat> outputFormats = new List<JobPayloadFormat>()
            {
            // initialising an Svf2 output class will automatically set the type to Svf2.
                new JobSvfOutputFormat()
                    {
                    Views = new List<View>()
                    {
                        View._2d,
                        View._3d
                    }  // mandatory params? 
                
            },

            // initialising a Thumbnail output class will automatically set the type to Thumbnail.
            new JobThumbnailOutputFormat()
            {
                    Advanced = new JobThumbnailOutputFormatAdvanced(){

                        Width = Width._100, // enum channge to only 100
                        Height = Height._100
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
                    RootFilename = "Office.rvt",



                },
                Output = new JobPayloadOutput()
                {
                    Formats = outputFormats,
                    Destination = new JobPayloadOutputDestination() { Region = Region.US } // This will call the respective endpoint - Either US or EMEA. Defaults to US.
                },
            };

            // start the translation job
            try
            {
                Job jobResponse = await modelDerivativeClient.StartJobAsync(jobPayload: Job, accessToken: token);
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


        // Get Manifest
        public async Task GetManifestAsync()
        {
            // fetch manifest response
            try
            {
                Manifest manifestResponse = await modelDerivativeClient.GetManifestAsync(urn, accessToken: token);
                // query for urn, progress etc...
                string manifestUrn = manifestResponse.Urn;
                string progress = manifestResponse.Progress;
                // get list of derivatives. Query further to get children etc.
                List<ManifestDerivatives> derivatives = manifestResponse.Derivatives;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Get list of supported Formats
        public async Task GetFormatsAsync()
        {
            try
            {
                Formats formatsResponse = await modelDerivativeClient.GetFormatsAsync(accessToken: token);
                Dictionary<string, List<string>> supportedformats = formatsResponse.SupportedFormats;
            }
            catch
            (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        // Get list of model views
        public async Task GetModelViewsAsync()
        {
            string modelGuid = string.Empty;
            try
            {
                ModelViews modelViewsResponse = await modelDerivativeClient.GetModelViewsAsync(urn, accessToken: token);
                // get guid from response
                modelGuid = modelViewsResponse.Data.Metadata.First().Guid;
            }
            catch
            (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        // Fetch Object tree
        public async Task GetObjectTreeAsync()
        {
            string modelGuid = "<modelGuid>";
            try
            {
                ObjectTree objectTree = await modelDerivativeClient.GetObjectTreeAsync(urn, modelGuid, accessToken: token);
                if (objectTree.IsProcessing)
                {
                    // 202 response. Call the endpoint again or iteratively to get 200 OK.
                }
                List<ObjectTreeDataObjects> treeObjects = objectTree.Data.Objects;
            }
            catch
            (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        // Fetch specific properties
        public async Task GetSpecificPropertiesAsync()
        {
            string modelGuid = "<modelGuid>";
            // specify the request payload
            SpecificPropertiesPayload payload = new SpecificPropertiesPayload()
            {

                Query = new SpecificPropertiesPayloadQuery()
                {
                    FilterType = Filter.ObjectID,
                    Values = new List<object> { 915, 920 }
                }

            };

            try
            {
                SpecificProperties specificProperties = await modelDerivativeClient.FetchSpecificPropertiesAsync(urn, modelGuid, accessToken: token, specificPropertiesPayload: payload);
                if (specificProperties.IsProcessing)
                {
                    // 202 response. Call the endpoint again or iteratively to get 200 OK.
                }
                List<AllPropertiesDataCollection> propertiesDataCollections = specificProperties.Data.Collection;
            }
            catch
            (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void Main()
        {

            // Initialise SDKManager & ModelDerivativeClient
            Initialise();
             // Call respective methods
            await StartJobAsync();
            await GetManifestAsync();
            await GetFormatsAsync();
            await GetModelViewsAsync();
            await GetObjectTreeAsync();
            await GetSpecificPropertiesAsync();
        }

    }
}