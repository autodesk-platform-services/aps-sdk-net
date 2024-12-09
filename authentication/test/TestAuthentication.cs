namespace Autodesk.Authentication.Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.SDKManager;
using Autodesk.Authentication.Model;
using Autodesk.Authentication;

[TestClass]
public class TestAuthentication
{

    private static AuthenticationClient _authClient = null!;
    string client_id = "<client_id>";
    string client_secret = "<client_secret>";

    string authorization_code = "<authorization_code>";
    string redirect_uri = @"<redirect_uri>";

    string token = "<token>";
    string threeLeggedTokenAccesstoken = "<three_legged_token_accesstoken>";
    string refreshToken = "<refresh_token>";

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        SDKManager sdkManager = SdkManagerBuilder
                .Create() // Creates SDK Manager Builder itself.
                .Build();

        _authClient = new AuthenticationClient(sdkManager);

    }



    [TestMethod]
    public async Task Test2LeggedTokenAsync()
    {
        TwoLeggedToken twoLeggedToken = await _authClient.GetTwoLeggedTokenAsync(client_id, client_secret, new List<Scopes>() { Scopes.DataRead, Scopes.BucketRead });
        Assert.IsNotNull(twoLeggedToken);

    }


    [TestMethod]
    public void TestAuthorize()
    {
        string url = _authClient.Authorize(client_id, ResponseType.Code, redirectUri: redirect_uri, new List<Scopes>() { Scopes.DataRead, Scopes.BucketRead });
        Assert.IsNotNull(url);

    }

    [TestMethod]
    public async Task Test3LeggedTokenAsync()
    {

        ThreeLeggedToken threeLeggedToken = await _authClient.GetThreeLeggedTokenAsync(client_id, client_secret, authorization_code, redirect_uri);
        string threeLeggedToken_accesstoken = threeLeggedToken.AccessToken;
        Assert.IsNotNull(threeLeggedToken_accesstoken);
    }

    [TestMethod]
    public async Task TestRefreshTokenAsync()
    {
        ThreeLeggedToken newToken = await _authClient.RefreshTokenAsync("refreshToken", client_id, client_secret);
        Assert.IsNotNull(newToken.AccessToken);
    }

    [TestMethod]
    public async Task TestKeysAsync()
    {
        Jwks jwks = await _authClient.GetKeysAsync();
        Assert.AreNotSame(0, jwks.Keys.Count);
    }

    [TestMethod]
    public async Task TestOidcSpecAsync()
    {
        OidcSpec oidcSpec = await _authClient.GetOidcSpecAsync();
        Assert.IsNotNull(oidcSpec);

    }

    [TestMethod]
    public async Task TestUserInfoAsync()
    {
        UserInfo userInfo = await _authClient.GetUserInfoAsync(threeLeggedTokenAccesstoken);
        Assert.IsNotNull(userInfo);
    }

    [TestMethod]

    public async Task TestIntrospectTokenAsync()
    {
        IntrospectToken introspectToken = await _authClient.IntrospectTokenAsync(token, client_id, client_secret);
        var exp = introspectToken.Exp;
        Assert.IsNotNull(exp);
    }

    [TestMethod]
    public async Task TestRevokeTokenAsync()
    {
        HttpResponseMessage response = await _authClient.RevokeAsync(token, client_id, client_secret);
        Assert.IsTrue(response.IsSuccessStatusCode);
    }

}