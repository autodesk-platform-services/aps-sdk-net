using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Serialization;
using Autodesk.SDKManager;
using Autodesk.SecureServiceAccount;
using Autodesk.SecureServiceAccount.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Samples
{
    class SecureServiceAccount
    {
        SecureServiceAccountClient secureServiceAccountClient = null!;
        string? token = Environment.GetEnvironmentVariable("token");
        string? serviceAccountId = Environment.GetEnvironmentVariable("serviceAccountId");
        string? keyId = Environment.GetEnvironmentVariable("keyId");
        string? clientId = Environment.GetEnvironmentVariable("clientId");
        string? clientSecret = Environment.GetEnvironmentVariable("clientSecret");
        string? privateKey = Environment.GetEnvironmentVariable("privateKey");
        public void Initialise()
        {
            //  
            // Optionally initialise SDKManager to pass custom configurations, logger, etc. 
            // SDKManager sdkManager = SdkManagerBuilder.Create().Build();

            StaticAuthenticationProvider staticAuthenticationProvider = new StaticAuthenticationProvider(token);
            // Instantiate ModelDerivativeClient using the auth provider
            secureServiceAccountClient = new SecureServiceAccountClient(authenticationProvider: staticAuthenticationProvider);
        }

        #region Account Management
        public async Task CreateServiceAccountAsync()
        {
            CreateServiceAccountPayload createServiceAccountPayload = new CreateServiceAccountPayload
            {
                Name = "sdktestserviceaccount",
                FirstName = "SDK-Test",
                LastName = "Service-Account"
            };
            try
            {
                ServiceAccount serviceAccount = await secureServiceAccountClient.CreateServiceAccountAsync(createServiceAccountPayload);
                Console.WriteLine($"Service Account created: {serviceAccount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating service account: {ex.Message}");
            }
        }

        public async Task GetAllServiceAccountsAsync()
        {
            try
            {
                ServiceAccounts serviceAccounts = await secureServiceAccountClient.GetAllServiceAccountsAsync();
                Console.WriteLine("Service Accounts:");
                foreach (var account in serviceAccounts.ServiceAccountsList)
                {
                    Console.WriteLine(account);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving service accounts: {ex.Message}");
            }
        }

        public async Task GetServiceAccountAsync()
        {
            try
            {
                ServiceAccountDetails serviceAccount = await secureServiceAccountClient.GetServiceAccountAsync(serviceAccountId);
                Console.WriteLine($"Service Account details: {serviceAccount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving service account: {ex.Message}");
            }
        }

        public async Task EnableServiceAccountAsync()
        {
            try
            {
                ServiceAccountDetails enableServiceAccount = await secureServiceAccountClient.EnableServiceAccountAsync(serviceAccountId);
                Console.WriteLine($"Service Account enabled: {enableServiceAccount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enabling service account: {ex.Message}");
            }
        }

        public async Task DisableServiceAccountAsync()
        {
            try
            {
                ServiceAccountDetails disableServiceAccount = await secureServiceAccountClient.DisableServiceAccountAsync(serviceAccountId);
                Console.WriteLine($"Service Account disabled: {disableServiceAccount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error disabling service account: {ex.Message}");
            }
        }

        public async Task DeleteServiceAccountAsync()
        {
            try
            {
                HttpResponseMessage httpResponse = await secureServiceAccountClient.DeleteServiceAccountAsync(serviceAccountId);
                Console.WriteLine($"Service Account with ID {serviceAccountId} deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting service account: {ex.Message}");
            }
        }

        #endregion Account Management


        #region Key Management

        public async Task CreateServiceAccountKeyAsync()
        {
            try
            {
                ServiceAccountPrivateKey serviceAccountKey = await secureServiceAccountClient.CreateServiceAccountKeyAsync(serviceAccountId);
                Console.WriteLine($"Service Account Key created: {serviceAccountKey}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating service account key: {ex.Message}");
            }
        }

        public async Task GetAllServiceAccountKeysAsync()
        {
            try
            {
                ServiceAccountKeys serviceAccountKeys = await secureServiceAccountClient.GetAllServiceAccountKeysAsync(serviceAccountId);
                Console.WriteLine("Service Account Keys:");
                foreach (var key in serviceAccountKeys.Keys)
                {
                    Console.WriteLine(key);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving service account keys: {ex.Message}");
            }
        }


        public async Task EnableServiceAccountKeyAsync()
        {
            try
            {
                HttpResponseMessage enabledKey = await secureServiceAccountClient.EnableServiceAccountKeyAsync(serviceAccountId, keyId);
                Console.WriteLine($"Service Account Key enabled: {enabledKey}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enabling service account key: {ex.Message}");
            }
        }

        public async Task DisableServiceAccountKeyAsync()
        {
            try
            {
                HttpResponseMessage disabledKey = await secureServiceAccountClient.DisableServiceAccountKeyAsync(serviceAccountId, keyId);
                Console.WriteLine($"Service Account Key disabled: {disabledKey}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error disabling service account key: {ex.Message}");
            }
        }

        public async Task DeleteServiceAccountKeyAsync()
        {
            try
            {
                HttpResponseMessage deletedKey = await secureServiceAccountClient.DeleteServiceAccountKeyAsync(serviceAccountId, keyId);
                Console.WriteLine($"Service Account Key deleted: {deletedKey}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting service account key: {ex.Message}");
            }
        }

        #endregion Key Management

        #region Get Token 
        public async Task ExchangeJwtforTokenAsync()
        {
            try
            {
                string assertion = Utils.GenerateJwtAssertion(keyId, privateKey, clientId, serviceAccountId, [Scopes.ApplicationServiceAccountKeyRead, Scopes.ApplicationServiceAccountKeyWrite, Scopes.AccountRead, Scopes.ApplicationServiceAccountKeyRead]);
                ExchangeJwtToken newToken = await secureServiceAccountClient.ExchangeJwtAssertionAsync(assertion, clientId, clientSecret);
                DateTime expiryLocalTime = DateTimeOffset.FromUnixTimeSeconds(newToken.ExpiresAt!.Value).LocalDateTime;
                Console.WriteLine($"New token retrieved: {newToken}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving token: {ex.Message}");
            }
        }

        #endregion Get Token

        static async Task Main(string[] args)
        {

            SecureServiceAccount secureServiceAccount = new SecureServiceAccount();
            secureServiceAccount.Initialise();

            // Account Management methods
            // await secureServiceAccount.CreateServiceAccountAsync();
            // await secureServiceAccount.DeleteServiceAccountAsync();
            // await secureServiceAccount.GetAllServiceAccountsAsync();
            // await secureServiceAccount.GetServiceAccountAsync();
            // await secureServiceAccount.EnableServiceAccountAsync();
            // await secureServiceAccount.DisableServiceAccountAsync();

            // Key Management methods
            // await secureServiceAccount.CreateServiceAccountKeyAsync();
            // await secureServiceAccount.GetAllServiceAccountKeysAsync();
            // await secureServiceAccount.EnableServiceAccountKeyAsync();
            // await secureServiceAccount.DisableServiceAccountKeyAsync();
            // await secureServiceAccount.DeleteServiceAccountKeyAsync();

            // Exchange JWT for token
            // await secureServiceAccount.ExchangeJwtforTokenAsync();

        }
    }
}