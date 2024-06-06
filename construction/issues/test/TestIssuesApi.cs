namespace Autodesk.Construction.Issues.Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.Construction.Issues;
using Autodesk.Construction.Issues.Model;
using Autodesk.SDKManager;


[TestClass]
public class TestIssuesApi
{
    
    
         private const string  token ="<Token>";
        private const string projectid ="<ProjectId>";
        private const string issueId ="<IssueId>";

        private static IssuesClient issuesClient = null!;
    
           [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            // Instantiate SDK manager as below.  
            SDKManager sdkManager = SdkManagerBuilder
                            .Create() // Creates SDK Manager Builder itself.
                            .Build();

            // Instantiate AuthenticationClient using the created SDK manager
            issuesClient = new IssuesClient(sdkManager);
        }

    [TestMethod]
    public async Task getUserInfo(){
            User  userProfile =  await issuesClient.GetUserProfileAsync(projectid,xAdsRegion:XAdsRegion.US,accessToken:token);
            Assert.AreNotSame(userProfile.Id,null);
    }

    [TestMethod]
    public async Task getIssueType(){
        IssueType Type= await issuesClient.GetIssuesTypesAsync(projectid,xAdsRegion:XAdsRegion.US,accessToken:token);
        Assert.AreNotSame(Type.Pagination,null);
    }
    
    [TestMethod]
    public async Task getIssues(){
        IssuesPage issues = await issuesClient.GetIssuesAsync(projectid,xAdsRegion:XAdsRegion.US,accessToken:token);
        Assert.AreNotSame(issues.Pagination,null);
    }

    [TestMethod]
    public async Task getIssueDetail(){
        Issue issuedetail = await issuesClient.GetIssueDetailsAsync(projectid,issueId,xAdsRegion:XAdsRegion.US,accessToken:token);
        Assert.AreNotSame(issuedetail.Id,null);

    }

    [TestMethod] 
    public async Task createIssue(){
        IssuePayload newIssue = new IssuePayload();
        newIssue.Title = "Issue Created By using SDK ";
        newIssue.Description ="Created for test";
        newIssue.Status=Status.Open;
        newIssue.AssignedTo="J2Q2EL4FKPKRHTKF";
        newIssue.AssignedToType=AssignedToType.User;
        newIssue.IssueSubtypeId="9f39edab-8773-440d-848b-99d098e86ce3";
        newIssue.DueDate="2023-12-01";
        Issue createissue =await issuesClient.CreateIssueAsync(projectid,xAdsRegion:XAdsRegion.US,newIssue,accessToken:token);
        Assert.AreNotSame(createissue.Id,null);
    }

    [TestMethod]    
    public async Task createComment(){
        CommentsPayload newcomment=new CommentsPayload();
        newcomment.Body="Created a Comment for testing SDK";
        CreatedComment createComment=await issuesClient.CreateCommentsAsync(projectid,issueId,xAdsRegion:XAdsRegion.US,commentsPayload:newcomment,accessToken:token);
        Assert.AreNotSame(createComment.Id,null);

        
    }

    [TestMethod]
    public async Task getComments(){
        Comments getComments=await issuesClient.GetCommentsAsync(projectid,issueId,xAdsRegion:XAdsRegion.US,accessToken:token);
        Assert.AreNotSame(getComments.Pagination,null);
    }

    [TestMethod]
    public async Task getAttrdefinition(){
        AttrDefinition attrDefinition = await issuesClient.GetAttributeDefinitionsAsync(projectid,xAdsRegion:XAdsRegion.US , accessToken: token);
        Assert.AreNotSame(attrDefinition.Pagination,null);
        
    }

}