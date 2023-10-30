using Autodesk.Webhooks;
using Autodesk.Webhooks.Http;
using Autodesk.Webhooks.Model;
using Autodesk.SDKManager;


var token = "<token>";
var hookId = "<hook-id>";


SDKManager sdkManager = SdkManagerBuilder
      .Create()
      .Add(new ApsConfiguration())
      .Add(ResiliencyConfiguration.CreateDefault())
      .Build();

// Instantiate HooksApi
WebhooksClient _webhooksApi = new WebhooksClient(sdkManager);



// Create post request body to receive the notification on a specified event.
HookPayload systemEventHookPayload = new HookPayload();
systemEventHookPayload.CallbackUrl = "<callbackUrl>";
systemEventHookPayload.Scope = systemEventHookPayload.Scope.SetScope(Scopes.Workflow, "<my-workflow-id>");



// Add new webhook to receive the notification on a specified event.
HttpResponseMessage createSpecifiedEventHookResponse = await _webhooksApi.CreateSystemEventHookAsync(system: Systems.Derivative, _event: Events.ExtractionFinished, hookPayload: systemEventHookPayload, accessToken: token);
Console.WriteLine(createSpecifiedEventHookResponse.StatusCode);
Console.WriteLine(createSpecifiedEventHookResponse.Content);



// Retrieves a paginated list of all the webhooks. If the pageState query string is not specified, the first page is returned.
Hooks getHooks = await _webhooksApi.GetHooksAsync(accessToken: token);
// get hooks next link meant for pagination
string getHooksLink = getHooks.Links.Next;
// Get list of hooks data
List<HooksData> getHooksData = getHooks.Data;
foreach (var currentHook in getHooksData)
{
    string hook_Id = currentHook.HookId;
    string tenant = currentHook.Tenant;
    string callback_Url = currentHook.CallbackUrl;
    string created_by = currentHook.CreatedBy;
    string hook_event = currentHook.Event;
    string created_date = currentHook.CreatedDate;
    string last_updated_date = currentHook.LastUpdatedDate;
    string system_hook = currentHook.System;
    string creator_type = currentHook.CreatorType;
    string status = currentHook.Status;
    bool? auto_reactivate_hook = currentHook.AutoReactivateHook;
    string hook_expiry = currentHook.HookExpiry;
}



// Retrieves a paginated list of webhooks created in the context of a Client or Application. This API accepts 2-legged token of the application only. If the pageState query string is not specified, the first page is returned.
Hooks getAppHooks = await _webhooksApi.GetAppHooksAsync(accessToken: token);
// get hooks next link meant for pagination
string getAppHooksLink = getAppHooks.Links.Next;
// Get a list of hooks data
List<HooksData> appHooksData = getAppHooks.Data;
foreach (var currentHook in appHooksData)
{
    string hook_Id = currentHook.HookId;
    string tenant = currentHook.Tenant;
    string callback_Url = currentHook.CallbackUrl;
    string created_by = currentHook.CreatedBy;
    string hook_event = currentHook.Event;
    string created_date = currentHook.CreatedDate;
    string last_updated_date = currentHook.LastUpdatedDate;
    string system_hook = currentHook.System;
    string creator_type = currentHook.CreatorType;
    string status = currentHook.Status;
    bool? auto_reactivate_hook = currentHook.AutoReactivateHook;
    string hook_expiry = currentHook.HookExpiry;
}



// Retrieves a paginated list of all the webhooks for a specified system. If the pageState query string is not specified, the first page is returned.
Hooks getSystemHooks = await _webhooksApi.GetSystemHooksAsync(system: Systems.Data, accessToken: token);
// get hooks next link meant for pagination
string getSystemHooksLink = getSystemHooks.Links.Next;
// Get a list of hooks data
List<HooksData> getSystemHooksData = getSystemHooks.Data;
foreach (var currentHook in getSystemHooksData)
{
    string hook_Id = currentHook.HookId;
    string tenant = currentHook.Tenant;
    string callback_Url = currentHook.CallbackUrl;
    string created_by = currentHook.CreatedBy;
    string hook_event = currentHook.Event;
    string created_date = currentHook.CreatedDate;
    string last_updated_date = currentHook.LastUpdatedDate;
    string system_hook = currentHook.System;
    string creator_type = currentHook.CreatorType;
    string status = currentHook.Status;
    bool? auto_reactivate_hook = currentHook.AutoReactivateHook;
    string hook_expiry = currentHook.HookExpiry;
}


// Retrieves a paginated list of all the webhooks for a specified event. If the pageState query string is not specified, the first page is returned.
Hooks getSystemEventHooks = await _webhooksApi.GetSystemEventHooksAsync(system: Systems.Data, _event: Events.DmVersionAdded, accessToken: token);
// get hooks next link meant for pagination
string getSystemEventHooksLink = getSystemEventHooks.Links.Next;
// Get a list of hooks data
List<HooksData> getSystemEventHooksData = getSystemEventHooks.Data;
foreach (var currentHook in getSystemEventHooksData)
{
    string hook_Id = currentHook.HookId;
    string tenant = currentHook.Tenant;
    string callback_Url = currentHook.CallbackUrl;
    string created_by = currentHook.CreatedBy;
    string hook_event = currentHook.Event;
    string created_date = currentHook.CreatedDate;
    string last_updated_date = currentHook.LastUpdatedDate;
    string system_hook = currentHook.System;
    string creator_type = currentHook.CreatorType;
    string status = currentHook.Status;
    bool? auto_reactivate_hook = currentHook.AutoReactivateHook;
    string hook_expiry = currentHook.HookExpiry;
}


// Get details of a webhook based on its webhook ID
HookDetails getSystemEventHook = await _webhooksApi.GetHookDetailsAsync(system: Systems.Data, _event: Events.DmVersionAdded, hookId: hookId, accessToken: token);
// Get callbackUrl
string callbackUrl = getSystemEventHook.CallbackUrl;
Console.WriteLine(getSystemEventHook);


HttpResponseMessage deleteHookResponse = await _webhooksApi.DeleteSystemEventHookAsync(system: Systems.Data, _event: Events.DmVersionAdded, hookId: hookId, accessToken: token);
Console.WriteLine(deleteHookResponse.StatusCode);
Console.WriteLine(deleteHookResponse.Content);


// Create update hook request body
ModifyHookPayload updateHook = new ModifyHookPayload();
updateHook.Status = "<status>";

// Successful deactivation of a webhook:
HttpResponseMessage updateHookResponse = await _webhooksApi.PatchSystemEventHookAsync(system: Systems.Data, _event: Events.DmVersionAdded, hookId: hookId, accessToken: token);
Console.WriteLine(updateHookResponse.StatusCode);
Console.WriteLine(updateHookResponse.Content);


// Create post request body to receive the notification on all the events.
HookPayload createAllEventsHook = new HookPayload();
createAllEventsHook.CallbackUrl = "<callbackUrl>";
createAllEventsHook.Scope = createAllEventsHook.Scope.SetScope(Scopes.Workflow, "<my-workflow-id>");


// Add new webhooks to receive the notification on all the events.
Hook createAllEventsHooks = await _webhooksApi.CreateSystemHookAsync(system: Systems.Derivative, hookPayload: createAllEventsHook, accessToken: token);
List<HookHooks> allEventsHooks = createAllEventsHooks.Hooks;
foreach (var currentHook in allEventsHooks)
{
    string hook_Id = currentHook.HookId;
    string tenant = currentHook.Tenant;
    string callback_Url = currentHook.CallbackUrl;
    string created_by = currentHook.CreatedBy;
    string hook_event = currentHook.Event;
    string created_date = currentHook.CreatedDate;
    string last_updated_date = currentHook.LastUpdatedDate;
    string system_hook = currentHook.System;
    string creator_type = currentHook.CreatorType;
    string status = currentHook.Status;
    bool? auto_reactivate_hook = currentHook.AutoReactivateHook;
    string urn = currentHook.Urn;
    string _self = currentHook.Self;

    HookDetailsScope scope = currentHook.Scope;
    string folderId = scope.Folder;
}

