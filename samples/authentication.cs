using System.Threading.Tasks;
using Autodesk.Authentication;
using Autodesk.Authentication.Model;
using Autodesk.SDKManager;

namespace Samples
{

      class Authentication
      {
            AuthenticationClient authenticationClient = null!;
            string? clientId = Environment.GetEnvironmentVariable("clientId");
            string? clientSecret = Environment.GetEnvironmentVariable("clientSecret");
            string? redirectUri = Environment.GetEnvironmentVariable("redirectUri");
            string? accessToken = Environment.GetEnvironmentVariable("accessToken");
            string? authorizationCode = Environment.GetEnvironmentVariable("authorizationCode");
            string? refreshToken = Environment.GetEnvironmentVariable("refreshToken");

            public void Initialise()
            {
                  // Instantiate SDK manager as below.  
                  SDKManager sdkManager = SdkManagerBuilder
                        .Create() // Creates SDK Manager Builder itself.
                        .Build();

                  // Instantiate AuthenticationClient using the created SDK manager
                  authenticationClient = new AuthenticationClient(sdkManager);
            }

            public async Task Get2LeggedTokenAsync()
            {
                  // Get 2Legged token.
                  // Pass the  client Id and secret as in your app. The method 
                  // will convert it in '${Base64(<client_id>:<client_secret>)}' format
                  try
                  {
                        TwoLeggedToken twoLeggedToken = await authenticationClient.GetTwoLeggedTokenAsync(clientId, clientSecret, new List<Scopes>() { Scopes.DataRead, Scopes.BucketRead });
                        string accessToken = twoLeggedToken.AccessToken;
                        long? expiresAt = twoLeggedToken.ExpiresAt; // Returns the token expiry time in Unix seconds
                        DateTime expiryLocalTime = DateTimeOffset.FromUnixTimeSeconds(expiresAt!.Value).LocalDateTime; // Convert Unix seconds to local time
                  }
                  catch (AuthenticationApiException ex)
                  {
                        Console.Write(ex.Message);
                  }
            }


            public void GetAuthorizeURL()
            {
                  // Get Authorize url
                  //  List<Scopes
                  string url = authenticationClient.Authorize(clientId, ResponseType.Code, redirectUri: redirectUri, scopes: new List<Scopes>() { Scopes.DataRead, Scopes.BucketRead });
            }


            public async Task Get3LeggedTokenAsync()
            {
                  // Get 3Legged token.
                  // Pass the  client Id and secret as in your app. The method 
                  // will convert it in Basic ${Base64(<client_id>:<client_secret>)} format
                  try
                  {
                        ThreeLeggedToken threeLeggedToken = await authenticationClient.GetThreeLeggedTokenAsync(clientId, authorizationCode, redirectUri, clientSecret: clientSecret);
                        string accessToken = threeLeggedToken.AccessToken;
                  }
                  catch (AuthenticationApiException ex)
                  {
                        Console.Write(ex.Message);
                  }
            }



            public async Task RefreshTokenAsync()
            {
                  // Get Refresh token
                  try
                  {
                        ThreeLeggedToken newToken = await authenticationClient.RefreshTokenAsync(refreshToken, clientId, clientSecret);
                        string accessToken = newToken.AccessToken;

                  }
                  catch (AuthenticationApiException ex)
                  {
                        Console.Write(ex.Message);
                  }
            }


            public async Task GetKeysAsync()
            {
                  //Retrieves the list of public keys in the JWKS format (JSON Web Key Set)
                  try
                  {
                        Jwks jwks = await authenticationClient.GetKeysAsync();
                        JwksKey jwksKey = jwks.Keys[1];
                  }
                  catch (AuthenticationApiException ex)
                  {
                        Console.Write(ex.Message);
                  }
            }


            public async Task GetOidcSpecAsync()
            {
                  // Retrieves the metadata as a JSON listing of OpenID/OAuth endpoints
                  try
                  {
                        OidcSpec oidcSpec = await authenticationClient.GetOidcSpecAsync();
                        string issuer = oidcSpec.Issuer;
                  }
                  catch (AuthenticationApiException ex)
                  {
                        Console.Write(ex.Message);
                  }
            }


            public async Task GetUserInfoAsync()
            {
                  try
                  {
                        // Retrieves basic information for the given authenticated user.
                        UserInfo userInfo = await authenticationClient.GetUserInfoAsync(accessToken);
                        string userEmail = userInfo.Email;
                  }
                  catch (AuthenticationApiException ex)
                  {
                        Console.Write(ex.Message);
                  }
            }


            public async Task IntrospectTokenAsync()
            {
                  // Returns the status information of the tokens.
                  try
                  {
                        IntrospectToken introspectToken = await authenticationClient.IntrospectTokenAsync(accessToken, clientId, clientSecret);
                  }
                  catch (AuthenticationApiException ex)
                  {
                        Console.Write(ex.Message);
                  }

            }


            public async Task RevokeTokenAsync()
            {
                  // This API endpoint takes an access token or refresh token and revokes it.
                  try
                  {
                        HttpResponseMessage response = await authenticationClient.RevokeAsync(accessToken, clientId, clientSecret);
                  }
                  catch (AuthenticationApiException ex)
                  {
                        Console.Write(ex.Message);
                  }
            }


            public void GetLogoutUrl()
            {
                  string logoutUrl = authenticationClient.Logout();
            }

            public static async Task Main()
            {
                  Authentication authentication = new Authentication();
                  // Initialise SDKManager & AuthClient
                  authentication.Initialise();
                  // Call respective methods
                  await authentication.Get2LeggedTokenAsync();
                  authentication.GetAuthorizeURL();
                  await authentication.Get3LeggedTokenAsync();
                  await authentication.RefreshTokenAsync();
                  await authentication.GetOidcSpecAsync();
                  await authentication.GetKeysAsync();
                  authentication.GetLogoutUrl();



            }

      }
}

