using Autodesk.Authentication.SecureServiceAccount.Model;
using Autodesk.SDKManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Text;

namespace Autodesk.Authentication.SecureServiceAccount.Test;

[TestClass]
public class TestSecureServiceAccount
{
   private static SecureServiceAccountClient _secureServiceAccountClient = null!;

   private readonly string? _clientId = Environment.GetEnvironmentVariable("clientId");
   private readonly string? _clientSecret = Environment.GetEnvironmentVariable("clientSecret");
   private readonly string? _twoLeggedToken = Environment.GetEnvironmentVariable("twoLeggedToken");

   private readonly string? _serviceAccountName = Environment.GetEnvironmentVariable("serviceAccountName");
   private readonly string? _serviceAccountFirstName = Environment.GetEnvironmentVariable("serviceAccountFirstName");
   private readonly string? _serviceAccountLastName = Environment.GetEnvironmentVariable("serviceAccountLastName");
   private readonly string? _serviceAccountId = Environment.GetEnvironmentVariable("serviceAccountId");

   private readonly string? _pathToPrivateKeyFile = Environment.GetEnvironmentVariable("pathToPrivateKeyFile");
   private readonly string? _keyId = Environment.GetEnvironmentVariable("keyId");

   [ClassInitialize]
   public static void ClassInitialize(TestContext testContext)
   {
      SDKManager.SDKManager sdkManager = SdkManagerBuilder
         .Create()
         .Add(new ApsConfiguration())
         .Add(ResiliencyConfiguration.CreateDefault())
         .Build();

      _secureServiceAccountClient = new SecureServiceAccountClient(sdkManager);
   }

   #region AccountManagementApi

   [TestMethod]
   public async Task TestCreateServiceAccountAsync()
   {
      ServiceAccountCreatePayload serviceAccountCreatePayload = new()
      {
         Name = _serviceAccountName,
         FirstName = _serviceAccountFirstName,
         LastName = _serviceAccountLastName,
      };

      ServiceAccountCreated serviceAccount = await _secureServiceAccountClient.CreateServiceAccountAsync(
         serviceAccountCreatePayload: serviceAccountCreatePayload,
         accessToken: _twoLeggedToken);
      Assert.IsNotNull(serviceAccount);
   }

   [TestMethod]
   public async Task TestDeleteServiceAccountAsync()
   {
      HttpResponseMessage httpResponseMessage = await _secureServiceAccountClient.DeleteServiceAccountAsync(
         serviceAccountId: _serviceAccountId,
         accessToken: _twoLeggedToken);
      Assert.IsTrue(httpResponseMessage.StatusCode == HttpStatusCode.NoContent);
   }

   [TestMethod]
   public async Task TestGetServiceAccountAsync()
   {
      ServiceAccount serviceAccount = await _secureServiceAccountClient.GetServiceAccountAsync(
         serviceAccountId: _serviceAccountId,
         accessToken: _twoLeggedToken);
      Assert.IsNotNull(serviceAccount);
   }

   [TestMethod]
   public async Task TestGetServiceAccountsAsync()
   {
      ServiceAccountsResponse serviceAccounts = await _secureServiceAccountClient.GetServiceAccountsAsync(
         accessToken: _twoLeggedToken);
      Assert.IsInstanceOfType<ServiceAccountsResponse>(serviceAccounts);
   }

   [TestMethod]
   public async Task TestUpdateServiceAccountAsync()
   {
      ServiceAccountUpdatePayload serviceAccountUpdatePayload = new()
      {
         Status = ServiceAccountStatus.Enabled,
      };

      HttpResponseMessage httpResponseMessage = await _secureServiceAccountClient.UpdateServiceAccountAsync(
          serviceAccountId: _serviceAccountId,
          serviceAccountUpdatePayload: serviceAccountUpdatePayload,
          accessToken: _twoLeggedToken);
      Assert.IsTrue(httpResponseMessage.StatusCode == HttpStatusCode.OK);
   }

   #endregion AccountManagementApi

   #region KeyManagementApi

   [TestMethod]
   public async Task TestCreateKeyAsync()
   {
      KeyCreated key = await _secureServiceAccountClient.CreateKeyAsync(
         serviceAccountId: _serviceAccountId,
         accessToken: _twoLeggedToken);
      Assert.IsNotNull(key);
   }

   [TestMethod]
   public async Task TestDeleteKeyAsync()
   {
      HttpResponseMessage httpResponseMessage = await _secureServiceAccountClient.DeleteKeyAsync(
         serviceAccountId: _serviceAccountId,
         keyId: _keyId,
         accessToken: _twoLeggedToken);
      Assert.IsTrue(httpResponseMessage.StatusCode == HttpStatusCode.NoContent);
   }

   [TestMethod]
   public async Task TestGetKeysAsync()
   {
      KeysResponse keys = await _secureServiceAccountClient.GetKeysAsync(
         serviceAccountId: _serviceAccountId,
         accessToken: _twoLeggedToken);
      Assert.IsInstanceOfType<KeysResponse>(keys);
   }

   [TestMethod]
   public async Task TestUpdateKeyAsync()
   {
      KeyUpdatePayload keyUpdatePayload = new()
      {
         Status = KeyStatus.Enabled,
      };

      HttpResponseMessage httpResponseMessage = await _secureServiceAccountClient.UpdateKeyAsync(
          serviceAccountId: _serviceAccountId,
          keyId: _keyId,
          keyUpdatePayload: keyUpdatePayload,
          accessToken: _twoLeggedToken);
      Assert.IsTrue(httpResponseMessage.StatusCode == HttpStatusCode.NoContent);
   }

   #endregion KeyManagementApi

   #region ExchangeTokenApi

   [TestMethod]
   public async Task TestExchangeJwtAssertion()
   {
      string authorization = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"));
      List<Scopes> scopes = [Scopes.DataCreate, Scopes.DataRead, Scopes.DataWrite];

      using var fileStream = File.OpenRead(_pathToPrivateKeyFile);
      string assertion = _secureServiceAccountClient.GenerateJwtAssertion(
         clientId: _clientId,
         serviceAccountId: _serviceAccountId,
         privateKey: fileStream,
         keyId: _keyId,
         scopes: scopes);

      ThreeLeggedToken threeLeggedToken = await _secureServiceAccountClient.ExchangeJwtAssertionAsync(
         authorization: authorization,
         grantType: GrantType.JwtBearer,
         assertion: assertion,
         clientId: _clientId,
         clientSecret: _clientSecret,
         scopes: scopes);
      Assert.IsNotNull(threeLeggedToken);
   }

   #endregion ExchangeTokenApi

}