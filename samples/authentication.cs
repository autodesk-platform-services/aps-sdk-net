using Autodesk.Authentication;
using Autodesk.Authentication.Model;
using Autodesk.SDKManager;

namespace Samples
{

      class Authentication
      {
            public static async void Main()
            {

                  string client_id = "<client_id>";
                  string client_secret = "<client_secret>";
                  string redirect_uri = @"<redirect_uri>";
                  string token = "<token>";
                  // Instantiate SDK manager as below.  
                  SDKManager sdkManager = SdkManagerBuilder
                        .Create() // Creates SDK Manager Builder itself.
                        .Build();

                  // Instantiate AuthenticationClient using the created SDK manager
                  AuthenticationClient authenticationClient = new AuthenticationClient(sdkManager);


                  // Get 2Legged token.
                  // Pass the  client Id and secret as in your app. The method 
                  // will convert it in '${Base64(<client_id>:<client_secret>)}' format

                  TwoLeggedToken twoLeggedToken = await authenticationClient.GetTwoLeggedTokenAsync(client_id, client_secret, new List<Scopes>() { Scopes.DataRead, Scopes.BucketRead });
                  var twoLeggedToken_accesstoken = twoLeggedToken.AccessToken;



                  // Get Authorize url
                  string url = authenticationClient.Authorize(client_id, ResponseType.Code, redirectUri: redirect_uri, new List<Scopes>() { Scopes.DataRead, Scopes.BucketRead });



                  // Get 3Legged token.
                  // Pass the  client Id and secret as in your app. The method 
                  // will convert it in Basic ${Base64(<client_id>:<client_secret>)} format
                  ThreeLeggedToken threeLeggedToken = await authenticationClient.GetThreeLeggedTokenAsync(client_id, client_secret, code: "code", redirect_uri);
                  string threeLeggedToken_accesstoken = threeLeggedToken.AccessToken;
                  string refreshToken = threeLeggedToken.RefreshToken;



                  // Get Refresh token
                  RefreshToken newToken = await authenticationClient.GetRefreshTokenAsync(client_id, client_secret, refreshToken);



                  //Retrieves the list of public keys in the JWKS format (JSON Web Key Set)
                  Jwks jwks = await authenticationClient.GetKeysAsync();



                  // Retrieves the metadata as a JSON listing of OpenID/OAuth endpoints
                  OidcSpec oidcSpec = await authenticationClient.GetOidcSpecAsync();



                  // Retrieves basic information for the given authenticated user.
                  // Only supports 3-legged access tokens.
                  UserInfo userInfo = await authenticationClient.GetUserInfoAsync(threeLeggedToken_accesstoken);



                  // Returns the status information of the tokens.
                  IntrospectToken introspectToken = await authenticationClient.IntrospectTokenAsync(token, client_id, client_secret);
                  var exp = introspectToken.Exp;


                  // This API endpoint takes an access token or refresh token and revokes it.
                  // Once the token is revoked, it becomes inactive
                  // A client can only revoke its own tokens.
                  HttpResponseMessage response = await authenticationClient.RevokeAsync(token, client_id, client_secret);

            }

      }
}

