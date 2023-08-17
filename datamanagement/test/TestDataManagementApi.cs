using Autodesk.Forge.Core;
using Autodesk.DataManagementApi;
using Autodesk.DataManagementApi.Http;
using Autodesk.DataManagementApi.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.SDKManager;

namespace Autodesk.DataManagementApi.Test;


[TestClass]
public class TestDataManagementApi
{
    private static DataManagementApi _dataManagementApi = null!;

    private const string token = "<token>";

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        SDKManager sdkManager = SdkManagerBuilder
                .Create() // Creates SDK Manager Builder itself.
                .Add(new ApsConfiguration())
                .Add(ResiliencyConfiguration.CreateDefault())
                .Build();

        _dataManagementApi = new DataManagementApi(sdkManager);
    }

    [TestMethod]
    public async Task TestGetHubsAsync()
    {
        Hubs getHubsResponse = await _webhooksApi.GetHubsAsync(accessToken: token);
        Assert.IsTrue(getHubsResponse.Data.Count > 0);
    }


}
