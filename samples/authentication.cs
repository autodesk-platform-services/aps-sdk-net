using System.Threading.Tasks;
using Autodesk.Authentication;
using Autodesk.Authentication.Model;
using Autodesk.SDKManager;

namespace Samples
{

      class Authentication
      {
            AuthenticationClient authenticationClient = null!;
            string client_id = "<client_id>";
            string client_secret = "<client_secret>";
            string redirect_uri = @"<redirect_uri>";
            string token = "<token>";
            string authorization_code = "code";

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
                        TwoLeggedToken twoLeggedToken = await authenticationClient.GetTwoLeggedTokenAsync(client_id, client_secret, new List<Scopes>() { Scopes.DataRead, Scopes.BucketRead });
                        string accessToken = twoLeggedToken.AccessToken;
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
                  string url = authenticationClient.Authorize(client_id, ResponseType.Code, redirectUri: redirect_uri, scopes: new List<Scopes>() { Scopes.DataRead, Scopes.BucketRead });
            }


            public async Task Get3LeggedTokenAsync()
            {
                  // Get 3Legged token.
                  // Pass the  client Id and secret as in your app. The method 
                  // will convert it in Basic ${Base64(<client_id>:<client_secret>)} format
                  try
                  {
                        ThreeLeggedToken threeLeggedToken = await authenticationClient.GetThreeLeggedTokenAsync(client_id, authorization_code,redirect_uri, clientSecret: client_secret);
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
                        ThreeLeggedToken newToken = await authenticationClient.RefreshTokenAsync("refreshToken", client_id, client_secret);
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
                        UserInfo userInfo = await authenticationClient.GetUserInfoAsync(token);
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
                        IntrospectToken introspectToken = await authenticationClient.IntrospectTokenAsync(token, client_id, client_secret);
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
                        HttpResponseMessage response = await authenticationClient.RevokeAsync(token, client_id, client_secret);
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

            public static async void Main()
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

