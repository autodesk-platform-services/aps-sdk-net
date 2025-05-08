﻿using Autodesk.Construction.AccountAdmin.Model;
using Autodesk.SDKManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autodesk.Construction.AccountAdmin.Test;

[TestClass]
public class TestAccountAdminApi
{
    private static AdminClient _adminClient = null!;
    
    string? token = Environment.GetEnvironmentVariable("token");
    string? accountId = Environment.GetEnvironmentVariable("account_id");
    string? userId = Environment.GetEnvironmentVariable("user_id");
       
    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
	     var sdkManager = SdkManagerBuilder
	     .Create()
	     .Add(new ApsConfiguration())
	     .Add(ResiliencyConfiguration.CreateDefault())
	     .Build();
        
	     _adminClient = new AdminClient(sdkManager);
    }
    
    [TestMethod]
    public async Task TestGetUserProjectsAsync()
    {
	     UserProjectsPage userProjectsPage = await _adminClient.GetUserProjectsAsync(accessToken: token, accountId: accountId, userId: userId);
	     Assert.IsInstanceOfType(userProjectsPage.Results, typeof(List<UserProject>));
    }
}
