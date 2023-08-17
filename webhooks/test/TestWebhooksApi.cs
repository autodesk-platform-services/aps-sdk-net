using Autodesk.Forge.Core;
using Autodesk.WebhooksApi;
using Autodesk.WebhooksApi.Http;
using Autodesk.WebhooksApi.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.SDKManager;

namespace Autodesk.WebhooksApi.Test;


[TestClass]
public class TestWebhooksApi
{
    private static WebhooksApi _webhooksApi = null!;

    private const string token = "<token>";

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        SDKManager sdkManager = SdkManagerBuilder
                .Create() // Creates SDK Manager Builder itself.
                .Add(new ApsConfiguration())
                .Add(ResiliencyConfiguration.CreateDefault())
                .Build();

        _webhooksApi = new WebhooksApi(sdkManager);
    }

    [TestMethod]
    public async Task TestGetHooksAsync()
    {
        HooksResult getHooksResponse = await _webhooksApi.GetHooksAsync(accessToken: token);
        Assert.IsTrue(getHooksResponse.Data.Count > 0);
    }

    [TestMethod]
    public async Task TestCreateHookAsync()
    {
        HookPayload createSpecifiedEventHook = new HookPayload();
        createSpecifiedEventHook.CallbackUrl = "<CallbackUrl>";
        createSpecifiedEventHook.Scope = createSpecifiedEventHook.Scope.SetScope(Scopes.Workflow, "<my-workflow-id-new-test-nine>");

        HttpResponseMessage createSpecifiedEventHookResponse = await _webhooksApi.CreateSystemEventHookAsync(system: Systems.Derivative, _event: Events.ExtractionFinished, hookPayload: createSpecifiedEventHook, accessToken: token);
        var statusCode = createSpecifiedEventHookResponse.StatusCode;
        string statusCodeString = statusCode.ToString();
        Assert.IsTrue(statusCodeString == "Created");
    }


}
