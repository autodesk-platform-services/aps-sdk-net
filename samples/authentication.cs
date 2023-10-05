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
                  TwoLeggedToken twoLeggedToken = await authenticationClient.GetTwoLeggedTokenAsync(client_id, client_secret, new List<Scopes>() { Scopes.DataRead, Scopes.BucketRead });
            }


            public void GetAuthorizeURL()
            {
                  // Get Authorize url
                  string url = authenticationClient.Authorize(client_id, ResponseType.Code, redirectUri: redirect_uri, new List<Scopes>() { Scopes.DataRead, Scopes.BucketRead });
            }


            public async Task Get3LeggedTokenAsync()
            {
                  // Get 3Legged token.
                  // Pass the  client Id and secret as in your app. The method 
                  // will convert it in Basic ${Base64(<client_id>:<client_secret>)} format

                  ThreeLeggedToken threeLeggedToken = await authenticationClient.GetThreeLeggedTokenAsync(client_id, client_secret, authorization_code, redirect_uri);
                  string threeLeggedToken_accesstoken = threeLeggedToken.AccessToken;
            }



            public async Task GetRefreshTokenAsync()
            {
                  // Get Refresh token
                  RefreshToken newToken = await authenticationClient.GetRefreshTokenAsync(client_id, client_secret, "refreshToken");
                  string refreshToken = newToken._RefreshToken;
                  int? expiresIn = newToken.ExpiresIn;
            }


            public async Task GetKeysAsync()
            {
                  //Retrieves the list of public keys in the JWKS format (JSON Web Key Set)
                  Jwks jwks = await authenticationClient.GetKeysAsync();
                  JwksKey jwksKey = jwks.Keys[1];
            }


            public async Task GetOidcSpecAsync()
            {
                  // Retrieves the metadata as a JSON listing of OpenID/OAuth endpoints
                  OidcSpec oidcSpec = await authenticationClient.GetOidcSpecAsync();
                  string issuer = oidcSpec.Issuer;
            }


            public async Task GetUserInfoAsync()
            {
                  // Retrieves basic information for the given authenticated user.
                  UserInfo userInfo = await authenticationClient.GetUserInfoAsync("threeLeggedToken_accesstoken");
                  string userEmail = userInfo.Email;
            }


            public async Task TestIntrospectTokenAsync()
            {
                  // Returns the status information of the tokens.
                  IntrospectToken introspectToken = await authenticationClient.IntrospectTokenAsync(token, client_id, client_secret);
                  string tokenType = introspectToken.TokenType;

            }


            public async Task RevokeTokenAsync()
            {
                  // This API endpoint takes an access token or refresh token and revokes it.
                  HttpResponseMessage response = await authenticationClient.RevokeAsync(token, client_id, client_secret);

            }


            public async void Main()
            {

                  // Initialise SDKManager & AuthClient
                  Initialise();
                  // Call respective methods
                  await Get2LeggedTokenAsync();
                  await Get3LeggedTokenAsync();
                  GetAuthorizeURL();


            }

      }
}

