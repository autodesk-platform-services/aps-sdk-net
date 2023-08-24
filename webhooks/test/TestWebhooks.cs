using Autodesk.Forge.Core;
using Autodesk.Webhooks;
using Autodesk.Webhooks.Http;
using Autodesk.Webhooks.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.SDKManager;

namespace Autodesk.Webhooks.Test;


[TestClass]
public class TestWebhooks
{
    private static WebhooksClient _webhooksApi = null!;

    private const string token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjY0RE9XMnJoOE9tbjNpdk1NU0xlNGQ2VHEwUSIsInBpLmF0bSI6Ijd6M2gifQ.eyJzY29wZSI6WyJjb2RlOmFsbCIsImRhdGE6d3JpdGUiLCJkYXRhOnJlYWQiLCJidWNrZXQ6Y3JlYXRlIiwiYnVja2V0OmRlbGV0ZSIsImJ1Y2tldDpyZWFkIl0sImNsaWVudF9pZCI6ImVXckR0dU54VnVHbHltd2w0VXdiZWJSVGx1bm13TzhnIiwiYXVkIjoiaHR0cHM6Ly9hdXRvZGVzay5jb20vYXVkL2Fqd3RleHA2MCIsImp0aSI6IldXQkhFeUpSVGRqbmRVaXBRb1Y1cU1KTVMxajliMmFoVmxPRWx3TW10dTJpaGxVd2J0RVlMUFhobk9UN2RCbTMiLCJleHAiOjE2OTI4ODUyOTN9.Hwlp81qCGMXpkq-LJ8jsU2aDRJcsMcGeoP9yz7FJib9iNW90y-IZReLjqP_b554lynhm2Tb4OdkYs3pG1kL185PxgbLkUL00n-I7MjYPJTTWAT2B4toLe7y3oT9sfNc1wPY2bx20Cj9PKbEID5M0OnJlMTJEfeEwsoqwAtfrZ7V0kJPQNCnmnkvVNAslEor9Nu9VDSRlGNmJpSDHCzDAgh6FqGk3Tr-fSDaFM06_rnEg-rNH-GFFWoLOVKWqBgfoXDrD-tWf_RI8Yekcgw11uJMihgZhR5QB2Y3XHK7_XD5ugES69URa6PW_7PjdOwm2RED2r14LjFU78yuPgk4DVg";

    [ClassInitialize]
vydvydjtext)
    {
        var sdkManager = SdkManagerBuilder
                .Create() // Creates SDK Manager Builder itself.
                .Add(new ApsConfiguration())
                .Add(ResiliencyConfiguration.CreateDefault())
                .Build();

        _webhooksApi = new WebhooksClient(sdkManager);
    }

    [TestMethod]
    public async Task TestGetHooksAsync()
    {
        HooksResult getHooksResponse = await _webhooksApi.GetHooksAsync(accessToken: token);
        Assert.IsTrue(getHooksResponse.Data.Count > 0);
    }

    // [TestMethod]
    // public async Task TestCreateHookAsync()
    // {
    //     HookPayload createSpecifiedEventHook = new HookPayload();
    //     createSpecifiedEventHook.CallbackUrl = "<CallbackUrl>";
    //     createSpecifiedEventHook.Scope = createSpecifiedEventHook.Scope.SetScope(Scopes.Workflow, "<my-workflow-id-new-test-nine>");

    //     HttpResponseMessage createSpecifiedEventHookResponse = await _webhooksApi.CreateSystemEventHookAsync(system: Systems.Derivative, _event: Events.ExtractionFinished, hookPayload: createSpecifiedEventHook, accessToken: token);
    //     var statusCode = createSpecifiedEventHookResponse.StatusCode;
    //     string statusCodeString = statusCode.ToString();
    //     Assert.IsTrue(statusCodeString == "Created");
    // }


}
