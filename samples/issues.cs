using System.Data;
using Autodesk.Construction.Issues;
using Autodesk.Construction.Issues.Model;
using Autodesk.SDKManager;

namespace Samples
{
    class Issues
    {
        string token = "<token>";
        string project_id = "<project_id>";
        string issue_id = "<issueId>";

        IssuesClient issuesClient = null!;

        public void Initialise()
        {        
            // Optionally initialise SDKManager to pass custom configurations, logger, etc. 
            // SDKManager sdkManager = SdkManagerBuilder.Create().Build();
            StaticAuthenticationProvider staticAuthenticationProvider = new StaticAuthenticationProvider(token);

            // Instantiate IssueClient using the auth provider
            issuesClient = new IssuesClient(authenticationProvider: staticAuthenticationProvider);
        }

        // Get user Permission
        public async Task getUserInfo()
        {
            User userProfile = await issuesClient.GetUserProfileAsync(projectId: project_id);
        }


        // Get IssueType
        public async Task getIssueType()
        {
            IssueType Type = await issuesClient.GetIssuesTypesAsync(projectId: project_id);
        }

        //Get Issues
        public async Task getIssues()
        {
            IssuesPage issues = await issuesClient.GetIssuesAsync(projectId: project_id);
        }

        //Get details of a issue
        public async Task getIssueDetail()
        {
            Issue issuedetail = await issuesClient.GetIssueDetailsAsync(projectId: project_id, issueId: issue_id);
        }

        //Create Issue 
        public async Task createIssue()
        {
            IssuePayload newIssue = new IssuePayload();
            newIssue.Title = "Issue Created By using SDK ";
            newIssue.Description = "Created for test";
            newIssue.Status = Status.Open;
            newIssue.AssignedTo = "<AssignedTo>";
            newIssue.AssignedToType = AssignedToType.User;
            newIssue.IssueSubtypeId = "<IssueSubtypeId>";
            newIssue.DueDate = "2023-10-10";
            Issue createissue = await issuesClient.CreateIssueAsync(projectId: project_id, newIssue);
        }

        // Create Comment
        public async Task createComment()
        {
            CommentsPayload newcomment = new CommentsPayload();
            newcomment.Body = "Created a Comment for testing SDK";
            CreatedComment createComment = await issuesClient.CreateCommentsAsync(projectId: project_id, issueId: issue_id, commentsPayload: newcomment);
        }

        //Get Comments
        public async Task getComments()
        {
            Comments getComments = await issuesClient.GetCommentsAsync(projectId: project_id, issueId: issue_id);
            Console.WriteLine(getComments);
        }

        public async Task getAttrdefinition()
        {
            AttrDefinition attrDefinition = await issuesClient.GetAttributeDefinitionsAsync(projectId: project_id);
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

