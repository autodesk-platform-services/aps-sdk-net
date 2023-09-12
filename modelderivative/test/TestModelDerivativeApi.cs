namespace Autodesk.ModelDerivative.Test;

using Autodesk.ModelDerivative;
using Autodesk.ModelDerivative.Http;
using Autodesk.ModelDerivative.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.SDKManager;



[TestClass]
public class TestModelDerivativeAPi
{
    private static ModelDerivativeClient _mdClient = null!;

    private const string token = "<token>";
    private const string urn = "<urn>";

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        SDKManager sdkManager = SdkManagerBuilder
                .Create() // Creates SDK Manager Builder itself.
                .Build();

        _mdClient = new ModelDerivativeClient(sdkManager);

    }



    [TestMethod]
    public async Task TestFormatsAsync()
    {

        Formats formats = await _mdClient.GetFormatsAsync(accessToken: token);
        Assert.IsTrue(formats.SupportedFormats.Count() == 10);
    }

    [TestMethod]
    public async Task TestJobAsync()
    {
        // set output formats
        List<JobPayloadFormat> outputFormats = new List<JobPayloadFormat>()
    {
      // initialising an Svf2 output class will automatically set the type to Svf2.
      // No need to call Type = TypeEnum.Svf2
      new JobSvf2OutputFormat()
      {

         Views =  new List<View>()
                {
                View._2d,
                View._3d
                },

      },

      // initialising a Thumbnail output class will automatically set the type to Thumbnail.
      // No need to call Type = TypeEnum.Thumbnail
      new JobThumbnailOutputFormat()
      {
            Advanced = new JobThumbnailOutputFormatAdvanced(){

                  Width = Width.NUMBER_100,
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
                RootFilename = "<filename>",



            },
            Output = new JobPayloadOutput()
            {
                Formats = outputFormats,
                Destination = Region.US
            },



        };

        // start the translation job
        Job jobResponse = await _mdClient.StartJobAsync(jobPayload: Job, accessToken: token);
        Assert.IsTrue(jobResponse.Result == "created");
    }

    [TestMethod]
    public async Task TestGetManifestAsync()
    {
        Manifest manifestResponse = await _mdClient.GetManifestAsync(urn, accessToken: token);
        string progress = manifestResponse.Progress;
        Assert.IsTrue(progress == "complete");
    }

    [TestMethod]
    public async Task TestGetMetadataAsync()
    {
        ModelViews modelViewsResponse = await _mdClient.GetModelViewsAsync(urn, accessToken: token);
        Assert.IsTrue(modelViewsResponse.Data.Metadata.Count > 0);
    }

    [TestMethod]
    public async Task GetThumbnailAsync()
    {

        Stream thumbnail = await _mdClient.GetThumbnailAsync(urn, Width.NUMBER_100, Height.NUMBER_100, accessToken: token);
        Assert.AreNotSame(thumbnail, null);

    }

}