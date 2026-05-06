/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components 
 * that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk's expertise 
 * in design and engineering.
 *
 * Secure Service Account
 *
 * Contact: aps.help@autodesk.com
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace Autodesk.SecureServiceAccount.Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.SDKManager;
using Autodesk.SecureServiceAccount;
using Autodesk.SecureServiceAccount.Model;

[TestClass]
public class TestSecureServiceAccount
{
    private static SecureServiceAccountClient _ssaClient = null!;

    string token = "<token>";
    string serviceAccountId = "<service_account_id>";
    string keyId = "<key_id>";
    string assertion = "<jwt_assertion>";
    string clientId = "<client_id>";
    string clientSecret = "<client_secret>";

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        SDKManager sdkManager = SdkManagerBuilder
            .Create() // Creates SDK Manager Builder itself.
            .Build();

        _ssaClient = new SecureServiceAccountClient(sdkManager);
    }

    #region AccountManagementApi Tests

    [TestMethod]
    public async Task TestCreateServiceAccountAsync()
    {
        ServiceAccount serviceAccount = await _ssaClient.CreateServiceAccountAsync(
            new CreateServiceAccountPayload { Name = "test-service-account" },
            accessToken: token);
        Assert.IsNotNull(serviceAccount);
    }

    [TestMethod]
    public async Task TestDeleteServiceAccountAsync()
    {
        var response = await _ssaClient.DeleteServiceAccountAsync(serviceAccountId, accessToken: token);
        Assert.IsTrue(response.IsSuccessStatusCode);
    }

    [TestMethod]
    public async Task TestEnableServiceAccountAsync()
    {
        ServiceAccountDetails details = await _ssaClient.EnableServiceAccountAsync(serviceAccountId, accessToken: token);
        Assert.IsNotNull(details);
    }

    [TestMethod]
    public async Task TestDisableServiceAccountAsync()
    {
        ServiceAccountDetails details = await _ssaClient.DisableServiceAccountAsync(serviceAccountId, accessToken: token);
        Assert.IsNotNull(details);
    }

    [TestMethod]
    public async Task TestGetServiceAccountAsync()
    {
        ServiceAccountDetails details = await _ssaClient.GetServiceAccountAsync(serviceAccountId, accessToken: token);
        Assert.IsNotNull(details);
    }

    [TestMethod]
    public async Task TestGetAllServiceAccountsAsync()
    {
        ServiceAccounts serviceAccounts = await _ssaClient.GetAllServiceAccountsAsync(accessToken: token);
        Assert.IsNotNull(serviceAccounts);
    }

    #endregion AccountManagementApi Tests

    #region ExchangeTokenApi Tests

    [TestMethod]
    public async Task TestExchangeJwtAssertionAsync()
    {
        ExchangeJwtToken exchangeJwtToken = await _ssaClient.ExchangeJwtAssertionAsync(
            assertion: assertion,
            clientId: clientId,
            clientSecret: clientSecret,
            scope: new List<Scopes> { Scopes.DataRead });
        Assert.IsNotNull(exchangeJwtToken);
        Assert.IsNotNull(exchangeJwtToken.AccessToken);
    }

    #endregion ExchangeTokenApi Tests

    #region KeyManagementApi Tests

    [TestMethod]
    public async Task TestCreateServiceAccountKeyAsync()
    {
        ServiceAccountPrivateKey privateKey = await _ssaClient.CreateServiceAccountKeyAsync(serviceAccountId, accessToken: token);
        Assert.IsNotNull(privateKey);
    }

    [TestMethod]
    public async Task TestDeleteServiceAccountKeyAsync()
    {
        var response = await _ssaClient.DeleteServiceAccountKeyAsync(serviceAccountId, keyId, accessToken: token);
        Assert.IsTrue(response.IsSuccessStatusCode);
    }

    [TestMethod]
    public async Task TestEnableServiceAccountKeyAsync()
    {
        var response = await _ssaClient.EnableServiceAccountKeyAsync(serviceAccountId, keyId, accessToken: token);
        Assert.IsTrue(response.IsSuccessStatusCode);
    }

    [TestMethod]
    public async Task TestDisableServiceAccountKeyAsync()
    {
        var response = await _ssaClient.DisableServiceAccountKeyAsync(serviceAccountId, keyId, accessToken: token);
        Assert.IsTrue(response.IsSuccessStatusCode);
    }

    [TestMethod]
    public async Task TestGetAllServiceAccountKeysAsync()
    {
        ServiceAccountKeys keys = await _ssaClient.GetAllServiceAccountKeysAsync(serviceAccountId, accessToken: token);
        Assert.IsNotNull(keys);
    }

    #endregion KeyManagementApi Tests
}
