using Autodesk.Constructionissues;
using Autodesk.Constructionissues.Model;
using Autodesk.SDKManager;

namespace Samples
{
    class Issues
    {
        string  token ="<token>"
        string projectid ="<ProjectId>";
        IssuesClient issuesClient = null;

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
        public async function getUserInfo(){
            User  userProfile =  await issuesClient.GetUserProfileAsync(projectid,xAdsRegion:XAdsRegion.US,accessToken:token);
        }
       

        // Get IssueType
        public async function getIssueType(){
            IssueType Type= await issuesClient.GetIssuesTypesAsync(projectid,xAdsRegion:XAdsRegion.US,accessToken:token);
        }

        //Get Issues
        public async function getIssues(){
            Issues issues = await issuesClient.GetIssuesAsync(projectid,xAdsRegion:XAdsRegion.US,accessToken:token);
        }

        //Get details of a issue
        public async function getIssueDetail(){
            string issueId ="d59ba4ba-8070-474c-a0a0-adad106ae1a5";
            Issue issuedetail = await issuesClient.GetIssueDetailsAsync(projectid,issueId,xAdsRegion:XAdsRegion.US,accessToken:token);
        }

        //Create Issue 
        public async function createIssue(){
            IssuePayload newIssue = new IssuePayload();
            newIssue.Title = "Issue Created By using SDK ";
            newIssue.Description ="Created for test";
            newIssue.Status=Status.Open;
            newIssue.AssignedTo="J2Q2EL4FKPKRHTKF";
            newIssue.AssignedToType=AssignedToType.User;
            newIssue.IssueSubtypeId="9f39edab-8773-440d-848b-99d098e86ce3";
            newIssue.DueDate="2023-10-10";
            Issue createissue =await issuesClient.CreateIssueAsync(projectid,xAdsRegion:XAdsRegion.US,newIssue,accessToken:token);
        }

        // Create Comment
        public async function createComment(){
            CommentsPayload newcomment=new CommentsPayload();
            newcomment.Body="Created a Comment for testing SDK";
            CreatedComment createComment=await issuesClient.CreateCommentsAsync(projectid,issueId,xAdsRegion:XAdsRegion.US,commentsPayload:newcomment,accessToken:token);
        }

        //Get Comments
        public async function getComments(){
            Comments getComments=await issuesClient.GetCommentsAsync(projectid,issueId,xAdsRegion:XAdsRegion.US,accessToken:token);
            Console.WriteLine(getComments);
        }

        public async function getAttrdefinition(){
            AttrDefinition attrDefinition = await issuesClient.GetAttributeDefinitionsAsync(projectid,xAdsRegion:XAdsRegion.US , accessToken: token);
            Console.WriteLine(attrDefinition);
        }

        public async void Main()
        {
            // Initialise SDKManager & AuthClient
            Initialise();
            // Call respective methods
            getUserInfo();
            getIssueType();
            getIssues();
            getIssueDetail();
            createComment();
            getComments();
            getAttrdefinition();
        }
    }
}