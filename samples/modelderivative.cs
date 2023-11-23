using Autodesk.ModelDerivative;
using Autodesk.ModelDerivative.Http;
using Autodesk.ModelDerivative.Model;
using Autodesk.SDKManager;
using Newtonsoft.Json.Linq;

string token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjY0RE9XMnJoOE9tbjNpdk1NU0xlNGQ2VHEwUSIsInBpLmF0bSI6ImFzc2MifQ.eyJzY29wZSI6WyJkYXRhOnJlYWQiLCJkYXRhOndyaXRlIiwiZGF0YTpjcmVhdGUiLCJidWNrZXQ6cmVhZCIsImJ1Y2tldDp1cGRhdGUiLCJidWNrZXQ6ZGVsZXRlIiwiYnVja2V0OmNyZWF0ZSIsInZpZXdhYmxlczpyZWFkIiwiY29kZTphbGwiXSwiY2xpZW50X2lkIjoiQnZ5TVFwZ3UyNjFVUnd5dm9GOTVwU0Z6QmUyOUt2U1IiLCJpc3MiOiJodHRwczovL2RldmVsb3Blci5hcGkuYXV0b2Rlc2suY29tIiwiYXVkIjoiaHR0cHM6Ly9hdXRvZGVzay5jb20iLCJqdGkiOiJPM013YzY5NzZndlNUWnphY1ZQQnJYNTJLTTE5b3B1eHdtV2xRdjBsdVlGQ25ha3ZjcHZ4TFNGa0VBRWYxTXhDIiwiZXhwIjoxNzAwNzQxOTIxfQ.iUhETlp3ebApo8fEH8CWbqp1kpLR5lPAIrUrifO9fegpEFaqROQZwzSvP3IKhYdqFLUwX3qwanHVWR198O3RHUSj0nGDYlXrFX0DJP5JOjRTTgM34kaFBu9kRASo8D8eLg2BExeeGUlpVv7jDdy583QkBWuPVrJpFeACBD5vPvYJU96-Szk__FhPYXzACLabjAVHV7_nPOYz1yUHswtMIS6QfT5ntwSrY0anUlUxYpaTm_JxlI7HLZg84ZAnZUCn_T3Ei9Yw0fQge4auVwic90Mnb-gpYmhZzydI9qQ3K8Ziw1t0ZcNxbjbCPk0nqbG5tXdLQyBYGkwQqeSgbvkOfA";
string urn = "dXJuOmFkc2sub2JqZWN0czpvcy5vYmplY3Q6dHN0YnVja2V0MTIzL09mZmljZS5ydnQ";


// Instantiate SDK manager as below.   
// You can also optionally pass configurations, logger, etc. 
SDKManager sdkManager = SdkManagerBuilder
      .Create() // Creates SDK Manager Builder itself.
      .Build();


// Instantiate ModelDerivativeApi using the created SDK manager
ModelDerivativeClient modelDerivativeClient = new ModelDerivativeClient(sdkManager);

// Post Job
// set output formats
List<JobPayloadFormat> outputFormats = new List<JobPayloadFormat>()
{
      // initialising an Svf2 output class will automatically set the type to Svf2.
      new JobSvfOutputFormat()
      {

      Views = new List<View>(){
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
        Destination = new JobPayloadOutputDestination(){ Region = Region.US} // This will call the respective endpoint - Either US or EMEA. Defaults to US.
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


// Get Manifest

// fetch manifest response
try
{
Manifest manifestResponse = await modelDerivativeClient.GetManifestAsync(urn, accessToken:token);
// query for urn, progress etc...
string manifestUrn = manifestResponse.Urn;
string progress = manifestResponse.Progress;
// get list of derivatives. Query further to get children etc.
List<ManifestDerivatives> derivatives = manifestResponse.Derivatives;
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}


// Get list of supported Formats
try
{
Formats formatsResponse = await modelDerivativeClient.GetFormatsAsync(accessToken:token);
Dictionary<string,List<string>> supportedformats = formatsResponse.SupportedFormats;
}
catch
(Exception ex)
{
    Console.WriteLine(ex.Message);
}


// Get list of model views
string modelGuid = string.Empty;
try
{
ModelViews modelViewsResponse = await modelDerivativeClient.GetModelViewsAsync(urn, accessToken: token);
// get guid from response
modelGuid =  modelViewsResponse.Data.Metadata.First().Guid;
}
catch
(Exception ex)
{
    Console.WriteLine(ex.Message);
}

// Fetch Object tree
try
{
ObjectTree objectTree = await modelDerivativeClient.GetObjectTreeAsync(urn,modelGuid,accessToken:token);
      if (objectTree.IsProcessing){
            // 202 response. Call the endpoint again or iteratively to get 200 OK.
      } 
 List<ObjectTreeDataObjects>treeObjects = objectTree.Data.Objects;    
}
catch
(Exception ex)
{
    Console.WriteLine(ex.Message);
}

// Fetch specific properties

// specify the request payload
SpecificPropertiesPayload payload = new SpecificPropertiesPayload(){
      
      Query = new SpecificPropertiesPayloadQuery(){
            FilterType =  Filter.ObjectID,
            Values =  new List<object>{915,920}
      }
      
};

try
{
SpecificProperties specificProperties = await modelDerivativeClient.FetchSpecificPropertiesAsync(urn,modelGuid,accessToken:token,specificPropertiesPayload:payload);
if (specificProperties.IsProcessing){
      // 202 response. Call the endpoint again or iteratively to get 200 OK.
}
List<AllPropertiesDataCollection> propertiesDataCollections = specificProperties.Data.Collection;
}
catch
(Exception ex)
{
    Console.WriteLine(ex.Message);
}
