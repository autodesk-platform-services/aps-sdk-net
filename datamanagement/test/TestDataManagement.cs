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

    private const string token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjY0RE9XMnJoOE9tbjNpdk1NU0xlNGQ2VHEwUSIsInBpLmF0bSI6Ijd6M2gifQ.eyJzY29wZSI6WyJjb2RlOmFsbCIsImRhdGE6d3JpdGUiLCJkYXRhOnJlYWQiLCJidWNrZXQ6Y3JlYXRlIiwiYnVja2V0OmRlbGV0ZSIsImJ1Y2tldDpyZWFkIl0sImNsaWVudF9pZCI6ImVXckR0dU54VnVHbHltd2w0VXdiZWJSVGx1bm13TzhnIiwiYXVkIjoiaHR0cHM6Ly9hdXRvZGVzay5jb20vYXVkL2Fqd3RleHA2MCIsImp0aSI6IjZHQ1JCSjRFYkdVNTQ3WmhSSjVtTVEzMEVSSlhFR2VYZUhpa0REWXhYb1d6S2kxZWRwdnZmM253ZDhBdjV4QW8iLCJleHAiOjE2OTQ1Mjc1MDh9.g-4WsVzYNVIZ9Z7FGFndg7eObAlOqwNKQuH-IFQiVejj0rJC8L40B5C1I7IdRunDVvGMRovq10sFvYH_fpQba4-pYLQy41X9hqhus9CBBvsYx63hHLpFV2J5AwJbCX-pc0JPwkCJNEhcBj0t1QJFd911B07b7UzFOJpGNYbNcvZUIxwzA3RVgbVwOQCbj-ahg_4K7z89XfXoW8l2nHqtwKpOfg2LVEqXg8EtE5KjfMugeAacgwZUAI8bE83aNcpuWUXpno0Gr_l2pd-0Wn_3D9McNL5-AxzP8jyhrUj3sSSd1vKT0WMJW7QAp05XOvRVPQ1MgREBVhVMPxAZXzviIw";

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        SDKManager sdkManager = SdkManagerBuilder
                .Create() // Creates SDK Manager Builder itself.
                .Add(new ApsConfiguration())
                .Add(ResiliencyConfiguration.CreateDefault())
                .Build();

        _dataManagementApi = new DataManagementClient(sdkManager);
    }

    [TestMethod]
    public async Task TestGetHubsAsync()
    {
        Hubs getHubsResponse = await _webhooksApi.GetHubsAsync(accessToken: token);
        Assert.IsTrue(getHubsResponse.Data.Count > 0);
    }


}
