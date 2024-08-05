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
    private const string derivativeUrn = "<derivativeUrn>";

    private const string modelGuid = "<modelGuid>";
    private const string referenceFileUrnOne = "<URN of the referenced file>";
    private const string referenceFileUrnTwo = "<URN of the referenced file>";

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

        SupportedFormats supportedFormats = await _mdClient.GetFormatsAsync(accessToken: token);
        Assert.IsInstanceOfType(supportedFormats.Formats, typeof(Dictionary<string, List<string>>));
    }

    [TestMethod]
    public async Task TestJobAsync()
    {
        // set output formats
        List<IJobPayloadFormat> outputFormats = new List<IJobPayloadFormat>()
        {
        // initialising an Svf2 output class will automatically set the type to Svf2.
        // No need to call Type = TypeEnum.Svf2
        new JobPayloadFormatSVF2()
        {

            Views =  new List<View>()
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
        // No need to call Type = TypeEnum.Thumbnail
        new JobPayloadFormatThumbnail()
        {
                Advanced = new JobPayloadFormatAdvancedThumbnail(){

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
            },
            Output = new JobPayloadOutput()
            {
                Formats = outputFormats,
            },



        };

        // start the translation job
        Job jobResponse = await _mdClient.StartJobAsync(jobPayload: Job, accessToken: token, region: Region.US);
        Assert.IsTrue(jobResponse.Result == "created");
    }

    [TestMethod]
    public async Task TestSpecifyReferencesAsyncc()
    {

        SpecifyReferencesPayload payload = new SpecifyReferencesPayload()
        {

            References = new List<SpecifyReferencesPayloadReferences>()
            {
                new SpecifyReferencesPayloadReferences
                {
                    Urn = referenceFileUrnOne
                },
                new SpecifyReferencesPayloadReferences
                {
                    Urn = referenceFileUrnTwo
                }
            }

        };

        SpecifyReferences specifyReferences = await _mdClient.SpecifyReferencesAsync(accessToken: token, urn, referencesPayload: payload);
        Assert.AreNotSame(specifyReferences, null);
    }

    [TestMethod]
    public async Task TestGetMetadataAsync()
    {
        // token
        ModelViews modelViewsResponse = await _mdClient.GetModelViewsAsync(accessToken: token, urn);
        Assert.IsTrue(modelViewsResponse.Data.Metadata.Count > 0);
    }

    [TestMethod]
    public async Task TestGetManifestAsync()
    {
        // token
        Manifest manifestResponse = await _mdClient.GetManifestAsync(accessToken: token, urn);
        string progress = manifestResponse.Progress;
        Console.WriteLine(manifestResponse);
        Assert.IsTrue(progress == "complete");
    }

    [TestMethod]
    public async Task TestDownloadDerivativeURLAsync()
    {

        DerivativeDownload derivativeDownload = await _mdClient.GetDerivativeUrlAsync(accessToken: token, derivativeUrn, urn, Region.US);
        // the below returns a downloadable url including the coookies
        string url = derivativeDownload.Url;
        Assert.AreNotSame(url, null);
    }

    [TestMethod]
    public async Task TestGetDerivativeHeadersAsync()
    {

        HttpResponseMessage derivativeHeaders = await _mdClient.HeadCheckDerivativeAsync(accessToken: token, urn, derivativeUrn, Region.US);
        if (derivativeHeaders.StatusCode == System.Net.HttpStatusCode.Accepted)
        {
            // 202 response. Call the endpoint again or iteratively to get 200 OK.
            Assert.IsTrue(derivativeHeaders.StatusCode == System.Net.HttpStatusCode.Accepted);
        }
        var ContentLength = derivativeHeaders.Content.Headers.ContentLength;
        Assert.IsTrue(ContentLength > 0);

    }

    [TestMethod]
    public async Task TestGetThumbnailAsync()
    {
        // token
        Stream thumbnail = await _mdClient.GetThumbnailAsync(accessToken: token, urn, Width.NUMBER_100, Height.NUMBER_100, Region.US);
        Assert.AreNotSame(thumbnail, null);

    }

    [TestMethod]
    public async Task TestGetModelViewsAsync()
    {

        ModelViews modelViewsResponse = await _mdClient.GetModelViewsAsync(accessToken: token, urn, region: Region.US);
        // get guid from response
        string modelGuid = modelViewsResponse.Data.Metadata.First().Guid;
        Assert.AreNotSame(modelGuid, null);

    }

    [TestMethod]
    public async Task TestGetObjectTreeAsync()
    {

        ObjectTree objectTree = await _mdClient.GetObjectTreeAsync(accessToken: token, urn, modelGuid, Region.US);
        Assert.AreNotSame(objectTree, null);

    }

    [TestMethod]
    public async Task TestGetAllPropertiesAsync()
    {

        Properties allProperties = await _mdClient.GetAllPropertiesAsync(accessToken: token, urn, modelGuid);
        Assert.AreNotSame(allProperties, null);

    }

    [TestMethod]
    public async Task TestGetSpecificPropertiesAsync()
    {
        // specify the request payload
        SpecificPropertiesPayload payload = new SpecificPropertiesPayload()
        {

            Query = new MatchId()
            {
                In = new List<object> { MatchIdType.ObjectId, 167 }
            }

        };

        SpecificProperties specificProperties = await _mdClient.FetchSpecificPropertiesAsync(accessToken: token, urn, modelGuid, specificPropertiesPayload: payload, Region.US);
        Assert.AreNotSame(specificProperties, null);

    }

    [TestMethod]
    public async Task DeleteManifestAsync()
    {

        DeleteManifest deleteManifest = await _mdClient.DeleteManifestAsync(accessToken: token, urn, Region.US);
        string result = deleteManifest.Result;
        Assert.IsTrue(result == "success");

    }

}