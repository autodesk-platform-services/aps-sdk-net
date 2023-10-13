namespace AccIssueApiTest;

using Autodesk.Constructionissues;
using Autodesk.Constructionissues.Http;
using Autodesk.Constructionissues.Model;
using Autodesk.SDKManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTest1
{


    private const string token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjY0RE9XMnJoOE9tbjNpdk1NU0xlNGQ2VHEwUSIsInBpLmF0bSI6Ijd6M2gifQ.eyJzY29wZSI6WyJkYXRhOndyaXRlIiwiZGF0YTpyZWFkIl0sImNsaWVudF9pZCI6Ikp1enlEQWlmMjVjSUFYZlpuMHJBd2ltSUFaVEdMeEFRIiwiYXVkIjoiaHR0cHM6Ly9hdXRvZGVzay5jb20vYXVkL2Fqd3RleHA2MCIsImp0aSI6InVzZGVpY1FDVmQ5UWd5RkJ2MnJCUkVSdTlPZ05WZVJuNVhjZHRoZzg1cHd4RE5ocUg4cFVRZmRNTmgxRDNQUWsiLCJ1c2VyaWQiOiJKMlEyRUw0RktQS1JIVEtGIiwiZXhwIjoxNjk2OTQwOTMwfQ.F9UuQHd3xgq_kpBBZsfAAKBovZ68tGl08nTC9Y7jiIUsbwI4ru0bqCBnB3cPn_rrkgr836JaoUmu0fElz_Ygd2Ig4g4xqMHSyHTQ4ACLVWfLir-9JUBsx4K9Mou64GUO3x0uJGc1-_liYYLN3kSvg2iKhpF257dgpfWNJmjBbqb_-xFcnNtxRPofkTWvyvUz1Wv-78lj3qJaOMGHIumF-zC8Myjvp8n7w1rzs1u1DE1yTRQZT6yZwVbGqjK1dePUhelPMVqbh5hD-MkBy-Tj-UIFTRkC2HT0YbuPL_90F1ototStf-0_Ax9xPAqedckDMFFMI1BfJNNM25pXpynwcg";
    private const string projectid = "c2522227-fd2e-4944-913b-3709e2d9f96a";

    private static IssuesClient _issueClient = null!;
    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        SDKManager sdkManager = SdkManagerBuilder
                .Create() // Creates SDK Manager Builder itself.
                .Build();
        IssuesClient issuesClient=new IssuesClient(sdkManager);
    }

    [TestMethod]
    public async Task UserProfile()
    {
        var  userProfile =  await _issueClient.GetUserProfileAsync(projectid,xAdsRegion:XAdsRegion.US,accessToken:token);
        User user = userProfile;
        Assert.IsTrue(2!=2+0);
        
    }
    
    // [TestMethod]
    // public async Task IssueType()
    // {
    //     var Type= await issueTypesApi.GetIssuesTypesAsync(projectid,null,accessToken:token);
    //     IssueType issueType=Type.Content;
        
    // }
}