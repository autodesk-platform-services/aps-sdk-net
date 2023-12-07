using System.Data;
using Autodesk.Construction.Issues;
using Autodesk.Construction.Issues.Model;
using Autodesk.SDKManager;

namespace Samples
{
    class Issues
    {
        string token = "<token>";
        string projectid = "<project_id>";
        IssuesClient issuesClient = null!;

        public void Initialise()
        {
            // Instantiate SDK manager as below.  
            SDKManager sdkManager = SdkManagerBuilder
                            .Create() // Creates SDK Manager Builder itself.
                            .Build();

            // Instantiate AuthenticationClient using the created SDK manager
            issuesClient = new IssuesClient(sdkManager);
        }

        // Get user Permission
        public async Task getUserInfo()
        {
            User userProfile = await issuesClient.GetUserProfileAsync(projectid, xAdsRegion: XAdsRegion.US, accessToken: token);
        }


        // Get IssueType
        public async Task getIssueType()
        {
            IssueType Type = await issuesClient.GetIssuesTypesAsync(projectid, xAdsRegion: XAdsRegion.US, accessToken: token);
        }

        //Get Issues
        public async Task getIssues()
        {
            IssuesPage issues = await issuesClient.GetIssuesAsync(projectid, xAdsRegion: XAdsRegion.US, accessToken: token);
        }

        //Get details of a issue
        public async Task getIssueDetail()
        {
            string issueId = "d59ba4ba-8070-474c-a0a0-adad106ae1a5";
            Issue issuedetail = await issuesClient.GetIssueDetailsAsync(projectid, issueId, xAdsRegion: XAdsRegion.US, accessToken: token);
        }

        //Create Issue 
        public async Task createIssue()
        {
            IssuePayload newIssue = new IssuePayload();
            newIssue.Title = "Issue Created By using SDK ";
            newIssue.Description = "Created for test";
            newIssue.Status = Status.Open;
            newIssue.AssignedTo = "J2Q2EL4FKPKRHTKF";
            newIssue.AssignedToType = AssignedToType.User;
            newIssue.IssueSubtypeId = "9f39edab-8773-440d-848b-99d098e86ce3";
            newIssue.DueDate = "2023-10-10";
            Issue createissue = await issuesClient.CreateIssueAsync(projectid, xAdsRegion: XAdsRegion.US, newIssue, accessToken: token);
        }

        // Create Comment
        public async Task createComment()
        {
            string issueId = "d59ba4ba-8070-474c-a0a0-adad106ae1a5";
            CommentsPayload newcomment = new CommentsPayload();
            newcomment.Body = "Created a Comment for testing SDK";
            CreatedComment createComment = await issuesClient.CreateCommentsAsync(projectid, issueId, xAdsRegion: XAdsRegion.US, commentsPayload: newcomment, accessToken: token);
        }

        //Get Comments
        public async Task getComments()
        {
            string issueId = "d59ba4ba-8070-474c-a0a0-adad106ae1a5";
            Comments getComments = await issuesClient.GetCommentsAsync(projectid, issueId, xAdsRegion: XAdsRegion.US, accessToken: token);
            Console.WriteLine(getComments);
        }

        public async Task getAttrdefinition()
        {
            AttrDefinition attrDefinition = await issuesClient.GetAttributeDefinitionsAsync(projectid, xAdsRegion: XAdsRegion.US, accessToken: token);
            Console.WriteLine(attrDefinition);
        }

        public async void Main()
        {
            // Initialise SDKManager & Issueslient
            Initialise();
            // Call respective methods
            await getUserInfo();
            await getIssueType();
            await getIssues();
            await getIssueDetail();
            await createComment();
            await getComments();
            await getAttrdefinition();
        }
    }
}

