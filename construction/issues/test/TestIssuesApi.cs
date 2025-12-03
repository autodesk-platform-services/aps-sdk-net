namespace Autodesk.Construction.Issues.Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.Construction.Issues;
using Autodesk.Construction.Issues.Model;
using Autodesk.SDKManager;
using System.Net.Http.Headers;

[TestClass]
public class TestIssuesApi
{


    private const string token = "<Token>";
    private const string projectid = "<ProjectId>";
    private const string issueId = "<IssueId>";
    private const string attachmentId = "<AttachmentId>";

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
    public async Task getUserInfo()
    {
        User userProfile = await issuesClient.GetUserProfileAsync(projectid, xAdsRegion: Region.US, accessToken: token);
        Assert.AreNotSame(userProfile.Id, null);
    }

    [TestMethod]
    public async Task getIssueType()
    {
        TypesPage Type = await issuesClient.GetIssuesTypesAsync(projectid, xAdsRegion: Region.US, accessToken: token);
        Assert.AreNotSame(Type.Pagination, null);
    }

    [TestMethod]
    public async Task getIssues()
    {
        IssuesPage issues = await issuesClient.GetIssuesAsync(projectid, xAdsRegion: Region.US, accessToken: token);
        Assert.AreNotSame(issues.Pagination, null);
    }

    [TestMethod]
    public async Task getIssueDetail()
    {
        Issue issuedetail = await issuesClient.GetIssueDetailsAsync(projectid, issueId, xAdsRegion: Region.US, accessToken: token);
        Assert.AreNotSame(issuedetail.Id, null);

    }

    [TestMethod]
    public async Task createIssue()
    {
        IssuePayload newIssue = new IssuePayload();
        newIssue.Title = "<Title>";
        newIssue.Description = "<Description>";
        newIssue.Status = Status.Open;
        newIssue.AssignedTo = "<AssigneeUserId>";
        newIssue.AssignedToType = AssignedToType.User;
        newIssue.IssueSubtypeId = "<IssueSubTypeId>";
        newIssue.DueDate = "<DueDate>";
        Issue createissue = await issuesClient.CreateIssueAsync(projectid, newIssue, xAdsRegion: Region.US, accessToken: token);
        Assert.AreNotSame(createissue.Id, null);
    }

    [TestMethod]
    public async Task createComment()
    {
        CommentsPayload newcomment = new CommentsPayload();
        newcomment.Body = "<Body>";
        Comments createComment = await issuesClient.CreateCommentsAsync(projectid, issueId, xAdsRegion: Region.US, commentsPayload: newcomment, accessToken: token);
        Assert.AreNotSame(createComment.Id, null);


    }

    [TestMethod]
    public async Task getComments()
    {
        CommentsPage getComments = await issuesClient.GetCommentsAsync(projectid, issueId, xAdsRegion: Region.US, accessToken: token);
        Assert.AreNotSame(getComments.Pagination, null);
    }

    [TestMethod]
    public async Task getAttrdefinition()
    {
        AttrDefinitionPage attrDefinition = await issuesClient.GetAttributeDefinitionsAsync(projectid, xAdsRegion: Region.US, accessToken: token);
        Assert.AreNotSame(attrDefinition.Pagination, null);
    }

    [TestMethod]
    public async Task getAttachments()
    {
        Attachments attachments = await issuesClient.GetAttachmentsAsync(projectid, issueId, accessToken: token);
        Assert.AreNotSame(attachments, null);
    }

    [TestMethod]
    public async Task deleteAttachment()
    {
        HttpResponseMessage response = await issuesClient.DeleteAttachmentAsync(projectid, issueId, attachmentId, accessToken: token);
        Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.NoContent);
    }
    [TestMethod]
    public async Task addAttachment()
    {
        AttachmentsPayload newAttachment = new AttachmentsPayload()
        {
            DomainEntityId = "<DomainEntityId>",
            Attachments =
        [
        new AttachmentObject
        {
            AttachmentId="<AttachmentId>",
            FileName = "<FileName>",
            DisplayName = "<DisplayName>",
            AttachmentType = "<AttachmentType>",
            StorageUrn = "<StorageUrn>"

        }
        ]

        };

        Attachments createAttachment = await issuesClient.AddAttachmentsAsync(projectid, newAttachment, accessToken: token);
        Assert.AreNotSame(createAttachment, null);
    }


}