using Autodesk.Webhooks;
using Autodesk.Webhooks.Http;
using Autodesk.Webhooks.Model;
using Autodesk.SDKManager;

namespace Samples
{
    class Webhooks
    {
        string token = "<token>";
        string hookId = "<hook-id>";
        WebhooksClient webhooksClient = null!;

        public void Initialise()
        {
            // Optionally initialise SDKManager to pass custom configurations, logger, etc. 
            // SDKManager sdkManager = SdkManagerBuilder.Create().Build();

            StaticAuthenticationProvider staticAuthenticationProvider = new StaticAuthenticationProvider(token);
            // Instantiate WebhooksClient using the auth provider
            webhooksClient = new WebhooksClient(authenticationProvider: staticAuthenticationProvider);

        }


        // Create post request body to receive the notification on a specified event.
        public async Task CreateSystemEventHookAsync()
        {
            HookPayload createSpecifiedEventHook = new HookPayload();
            createSpecifiedEventHook.CallbackUrl = "https://example.com/callback_four_new";
            createSpecifiedEventHook.Scope = new 
            {
                folder, "<my-folder-id>"
            };
            createSpecifiedEventHook.HookExpiry = "2024-09-11T17:04:10.444Z";
            createSpecifiedEventHook.HookAttribute =  new {
                // /* Custom metadata */
                myfoo= 76,
                projectId= "someURN",
                myobject= new {
                    abc= true,
                }
            };

            // Add new webhook to receive the notification on a specified event.
            HttpResponseMessage createSpecifiedEventHookResponse = await webhooksClient.CreateSystemEventHookAsync(system: Systems.Data, _event: Events.DmFolderCopied, hookPayload: createSpecifiedEventHook);
            Console.WriteLine(createSpecifiedEventHookResponse.StatusCode);
            Console.WriteLine(createSpecifiedEventHookResponse.Content);
        }


        // Retrieves a paginated list of all the webhooks. If the pageState query string is not specified, the first page is returned.
        public async Task GetHooksAsync()
        {
            Hooks getHooks = await webhooksClient.GetHooksAsync(region: Region.US);
            Console.WriteLine(getHooks);
            // get hooks next link meant for pagination
            string getHooksLink = getHooks.Links.Next;
            // Get list of hooks data
            List<HookDetails> getHooksData = getHooks.Data;
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
                Status status = currentHook.Status;
                bool? auto_reactivate_hook = currentHook.AutoReactivateHook;
                string hook_expiry = currentHook.HookExpiry;
            }

        }


        // Retrieves a paginated list of webhooks created in the context of a Client or Application. This API accepts 2-legged token of the application only. If the pageState query string is not specified, the first page is returned.
        public async Task GetAppHooksAsync()
        {
            Hooks getAppHooks = await webhooksClient.GetAppHooksAsync();;
            // get hooks next link meant for pagination
            string getAppHooksLink = getAppHooks.Links.Next;
            // Get a list of hooks data
            List<HookDetails> appHooksData = getAppHooks.Data;
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
                Status status = currentHook.Status;
                bool? auto_reactivate_hook = currentHook.AutoReactivateHook;
                string hook_expiry = currentHook.HookExpiry;
            }

        }


        // Retrieves a paginated list of all the webhooks for a specified system. If the pageState query string is not specified, the first page is returned.
        public async Task GetSystemHooksAsync()
        {
            Hooks getSystemHooks = await webhooksClient.GetSystemHooksAsync(system: "data", status: StatusFilter.Active );
            Console.WriteLine(getSystemHooks);
            // get hooks next link meant for pagination
            string getSystemHooksLink = getSystemHooks.Links.Next;
            // Get a list of hooks data
            List<HookDetails> getSystemHooksData = getSystemHooks.Data;
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
                Status status = currentHook.Status;
                bool? auto_reactivate_hook = currentHook.AutoReactivateHook;
                string hook_expiry = currentHook.HookExpiry;
            }
        }


        // Retrieves a paginated list of all the webhooks for a specified event. If the pageState query string is not specified, the first page is returned.
        public async Task GetSystemEventHooksAsync()
        {
            Hooks getSystemEventHooks = await webhooksClient.GetSystemEventHooksAsync(system: Systems.Data, _event: Events.DmFolderCopied, status: StatusFilter.Active);
            Console.WriteLine(getSystemEventHooks);
            // get hooks next link meant for pagination
            string getSystemEventHooksLink = getSystemEventHooks.Links.Next;
            // Get a list of hooks data
            List<HookDetails> getSystemEventHooksData = getSystemEventHooks.Data;
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
                Status status = currentHook.Status;
                bool? auto_reactivate_hook = currentHook.AutoReactivateHook;
                string hook_expiry = currentHook.HookExpiry;
            }

        }


        // Get details of a webhook based on its webhook ID
        public async Task GetHookDetailsAsync()
        {
            HookDetails getSystemEventHook = await webhooksClient.GetHookDetailsAsync(system: Systems.Derivative, _event: Events.DmVersionAdded, hookId: hookId);
            // Get callbackUrl
            string callbackUrl = getSystemEventHook.CallbackUrl;
            Console.WriteLine(getSystemEventHook);


            // HttpResponseMessage deleteHookResponse = await webhooksClient.DeleteSystemEventHookAsync(system: Systems.Data, _event: Events.DmVersionAdded, hookId: hookId);
            // Console.WriteLine(deleteHookResponse.StatusCode);
            // Console.WriteLine(deleteHookResponse.Content);

        }


        // Create update hook request body
        public async Task PatchSystemEventHookAsync()
        {
            ModifyHookPayload updateHook = new ModifyHookPayload();
            updateHook.Status = StatusRequest.Inactive;

            // Successful deactivation of a webhook:
            HttpResponseMessage updateHookResponse = await webhooksClient.PatchSystemEventHookAsync(system: Systems.Data, _event: Events.DmVersionAdded, modifyHookPayload: updateHook, hookId: hookId);
            Console.WriteLine(updateHookResponse.StatusCode);
            Console.WriteLine(updateHookResponse.Content);
        }


        // Create post request body to receive the notification on all the events.
        public async Task CreateSystemHookAsync()
        {
            HookPayload createAllEventsHook = new HookPayload();
            createAllEventsHook.CallbackUrl = "<callbackUrl>";
            createAllEventsHook.Scope = createAllEventsHook.Scope = new 
            {
                workflow= "<my-workflow-id>",
            };


            // Add new webhooks to receive the notification on all the events.
            Hook createAllEventsHooks = await webhooksClient.CreateSystemHookAsync(system: Systems.Derivative, hookPayload: createAllEventsHook, accessToken: token);
            List<HookDetails> allEventsHooks = createAllEventsHooks.Hooks;
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
                Status status = currentHook.Status;
                bool? auto_reactivate_hook = currentHook.AutoReactivateHook;
                string urn = currentHook.Urn;
                string _self = currentHook.Self;

                HookDetailsScope scope = currentHook.Scope;
                string folderId = scope.Folder;
            }
        }


         public static async Task Main(string[] args)
        {
            var webhooks = new Webhooks();
            // Initialise SDKManager & WebhooksClient
            webhooks.Initialise();
            // Call respective methods
            // await webhooks.CreateSystemEventHookAsync();
            await webhooks.GetHooksAsync();
            // await webhooks.GetAppHooksAsync();
            // await webhooks.GetSystemHooksAsync();
            // await webhooks.GetSystemEventHooksAsync();
            // await webhooks.GetHookDetailsAsync();
            // await webhooks.PatchSystemEventHookAsync();
            // await webhooks.CreateSystemHookAsync();
        }
    }
}

