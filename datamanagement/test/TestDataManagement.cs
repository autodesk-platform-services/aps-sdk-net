using Autodesk.Forge.Core;
using Autodesk.DataManagement;
using Autodesk.DataManagement.Http;
using Autodesk.DataManagement.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.SDKManager;

namespace Autodesk.DataManagement.Test;


[TestClass]
public class TestDataManagement
{
    private static DataManagementClient _dataManagementApi = null!;

    private const string token = "<token>";

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        var sdkManager = SdkManagerBuilder
                .Create() // Creates SDK Manager Builder itself.
                .Add(new ApsConfiguration())
                .Add(ResiliencyConfiguration.CreateDefault())
                .Build();

        _dataManagementApi = new DataManagementClient(sdkManager);
    }

    [TestMethod]
    public async Task TestGetHubsAsync()
    {
        Hubs getHubsResponse = await _dataManagementApi.GetHubsAsync(accessToken: token);
        Assert.IsTrue(getHubsResponse.Data.Count > 0);
    }


}
