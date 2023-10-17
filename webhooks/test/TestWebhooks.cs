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

    string token = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
    string callbackUrl = Environment.GetEnvironmentVariable("CALLBACK_URL");
    string workFlowId = Environment.GetEnvironmentVariable("WORKFLOW_ID");
    string hookId = Environment.GetEnvironmentVariable("HOOK_ID");

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        var sdkManager = SdkManagerBuilder
                .Create()
                .Add(new ApsConfiguration())
                .Add(ResiliencyConfiguration.CreateDefault())
                .Build();

        _webhooksApi = new WebhooksClient(sdkManager);
    }

    //Get details of a webhook based on its webhook ID
    [TestMethod]
    public async Task TestGetHookDetailsAsync()
    {
        HookDetailsResult getSystemEventHook = await _webhooksApi.GetHookDetailsAsync(system: Systems.Data, _event: Events.DmVersionAdded, hookId: hookId, accessToken: token);

        var HookId = getSystemEventHook.HookId;
        Assert.IsTrue(HookId == hookId);
    }

    //Retrieves a paginated list of all the webhooks for a specified event. If the pageState query string is not specified, the first page is returned.
    [TestMethod]
    public async Task TestGetSystemEventHooksAsync()
    {
        HooksResult getSystemEventHooks = await _webhooksApi.GetSystemEventHooksAsync(system: Systems.Data, _event: Events.DmVersionAdded, accessToken: token);
        Assert.IsTrue(getSystemEventHooks.Data.Count > 0);
    }

    //Retrieves a paginated list of all the webhooks for a specified system. If the pageState query string is not specified, the first page is returned.
    [TestMethod]
    public async Task TestGetSystemHooksAsync()
    {
        HooksResult getSystemHooks = await _webhooksApi.GetSystemHooksAsync(system: Systems.Data, accessToken: token);
        Assert.IsTrue(getSystemHooks.Data.Count > 0);
    }

    //Retrieves a paginated list of all the webhooks. If the pageState query string is not specified, the first page is returned.
    [TestMethod]
    public async Task TestGetHooksAsync()
    {
        HooksResult getHooks = await _webhooksApi.GetHooksAsync(accessToken: token);
        Assert.IsTrue(getHooks.Data.Count > 0);
    }

    //Retrieves a paginated list of webhooks created in the context of a Client or Application. This API accepts 2-legged token of the application only. If the pageState query string is not specified, the first page is returned.
    [TestMethod]
    public async Task TestGetAppHooksAsync()
    {
        HooksResult getAppHooks = await _webhooksApi.GetAppHooksAsync(accessToken: token);
        Assert.IsTrue(getAppHooks.Data.Count > 0);
    }

    //Add new webhook to receive the notification on a specified event.
    [TestMethod]
    public async Task TestCreateSystemEventHookAsync()
    {
        HookPayload createSystemEventHook = new HookPayload();
        createSystemEventHook.CallbackUrl = callbackUrl;
        createSystemEventHook.Scope = createSystemEventHook.Scope.SetScope(Scopes.Workflow, workFlowId);

        HttpResponseMessage createSystemEventHookResponse = await _webhooksApi.CreateSystemEventHookAsync(system: Systems.Derivative, _event: Events.ExtractionFinished, hookPayload: createSystemEventHook, accessToken: token);
        var statusCode = createSystemEventHookResponse.StatusCode;
        string statusCodeString = statusCode.ToString();
        Assert.IsTrue(statusCodeString == "Created");
    }

    //Add new webhooks to receive the notification on all the events.
    [TestMethod]
    public async Task TestCreateSystemHookAsync()
    {
        HookPayload createSystemHook = new HookPayload();
        createSystemHook.CallbackUrl = callbackUrl;
        createSystemHook.Scope = createSystemHook.Scope.SetScope(Scopes.Workflow, workFlowId);

        HookCreationResult createSystemHookResponse = await _webhooksApi.CreateSystemHookAsync(system: Systems.Derivative, hookPayload: createSystemHook, accessToken: token);
        Assert.IsTrue(createSystemHookResponse.Hooks.Count > 0);
    }

    //Partially update a webhook based on its webhook ID. The only fields that may be updated are: status, filter, hookAttribute, and hookExpiry.
    [TestMethod]
    public async Task TestPatchSystemEventHookAsync()
    {
        ModifyHookPayload updateHook = new ModifyHookPayload();
        updateHook.Status = "inactive";

        // Successful deactivation of a webhook:
        HttpResponseMessage updateHookResponse = await _webhooksApi.PatchSystemEventHookAsync(system: Systems.Data, _event: Events.DmVersionAdded, hookId: hookId, modifyHookPayload: updateHook, accessToken: token);
        var statusCode = updateHookResponse.StatusCode;
        string statusCodeString = statusCode.ToString();
        Assert.IsTrue(statusCodeString == "NoContent");
    }

    //Deletes a webhook based on webhook ID
    [TestMethod]
    public async Task TestDeleteSystemEventHookAsync()
    {
        HttpResponseMessage deleteHook = await _webhooksApi.DeleteSystemEventHookAsync(system: Systems.Data, _event: Events.DmVersionAdded, hookId: hookId, accessToken: token);

        var statusCode = deleteHook.StatusCode;
        string statusCodeString = statusCode.ToString();
        Assert.IsTrue(statusCodeString == "NoContent");
    }


    //Add a new Webhook secret token
    [TestMethod]
    public async Task TestCreateTokenAsync()
    {   // create request body
        TokenPayload createToken = new TokenPayload();
        createToken.Token = "awffbvdb3trf4fvdfbUyt39suHnbe5Mnrks8";

        // Add a new Webhook secret token
        TokenCreationResult createTokenResponse = await _webhooksApi.CreateTokenAsync(tokenPayload: createToken, accessToken: token);
        Assert.IsTrue(createTokenResponse.Status == 200);
    }



    //Update an existing Webhook secret token. Please note that the update can take up to 10 mins before being applied depending on the latest event delivery attempt which may still utilize the previous secret token. We recommend your callback accept both secret token values for a period of time to allow all requests to go through.
    [TestMethod]
    public async Task TestPutTokenAsync()
    {
        TokenPayload createToken = new TokenPayload();
        createToken.Token = "awffbvdb3trf4fvdfbUyt39suHnbe5Mnrks8";

        HttpResponseMessage updateTokenResponse = await _webhooksApi.PutTokenAsync(tokenPayload: createToken, accessToken: token);
        var statusCode = updateTokenResponse.StatusCode;
        string statusCodeString = statusCode.ToString();
        Assert.IsTrue(statusCodeString == "NoContent");
    }



    //Delete a Webhook secret token. Please note that the secret token can still be available for up to 10 mins depending on the latest event delivery attempt.
    [TestMethod]
    public async Task TestDeleteTokenAsync()
    {
        HttpResponseMessage deleteTokenResponse = await _webhooksApi.DeleteTokenAsync(accessToken: token);
        var statusCode = deleteTokenResponse.StatusCode;
        string statusCodeString = statusCode.ToString();
        Assert.IsTrue(statusCodeString == "NoContent");
    }


}
