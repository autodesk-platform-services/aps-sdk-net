using Autodesk.Constructionissues;
using Autodesk.Constructionissues.Model;
using Autodesk.SDKManager;

string  token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjY0RE9XMnJoOE9tbjNpdk1NU0xlNGQ2VHEwUSIsInBpLmF0bSI6Ijd6M2gifQ.eyJzY29wZSI6WyJkYXRhOndyaXRlIiwiZGF0YTpyZWFkIl0sImNsaWVudF9pZCI6Ikp1enlEQWlmMjVjSUFYZlpuMHJBd2ltSUFaVEdMeEFRIiwiYXVkIjoiaHR0cHM6Ly9hdXRvZGVzay5jb20vYXVkL2Fqd3RleHA2MCIsImp0aSI6Ik1EaGhDcGtETzZYSmdyNGVVYmdQR0pDM0p6OW50Z3pzSWUzQjBMYUx4U1B1UmVFVk9SWnFGdjFzbUphbEZXTGIiLCJ1c2VyaWQiOiJKMlEyRUw0RktQS1JIVEtGIiwiZXhwIjoxNjk2OTM3MDEyfQ.Q8k11rjfAGEs9YVJ_AxIc7Fd-Ew8SNW53Q1paHuNlYfJB-NVuB3Yvs6_0UgyIa0p-wdfN00oDZ5yadzVlzbPr66coaC1hpHB_LOgb02la1jSz1C0Tn2lcKj0zOhTNWSBWVbABjOyGuoOtip5bV-ihdHQPYetNgv6yesdrt1tc3sJhs4zHd9FTplCEuH-CitpY-DPV5mcgBoUXTEbiM1Lhxw5RfOKWIYQBlj4jsAGM3JuYJ32hU724i9xs4qcpVBw_ba7BMPNB-Or0z6Vj_pjHA9kkwEBt7OYNaN0ydAGS4zmjXd62Z2225XokaSbQSAr8FuelJxBTtCDcaG-mgvIYw";

string projectid ="c2522227-fd2e-4944-913b-3709e2d9f96a";

SDKManager sdkManager = SdkManagerBuilder
                .Create() // Creates SDK Manager Builder itself.
                .Add(new ApsConfiguration()
                {
                }
                )
                .Add(ResiliencyConfiguration.CreateDefault())
                .Build();
IssuesClient issuesClient = new IssuesClient(sdkManager);

// Get user Permissions
User  userProfile =  await issuesClient.GetUserProfileAsync(projectid,xAdsRegion:XAdsRegion.US,accessToken:token);

// Get IssueType
IssueType Type= await issuesClient.GetIssuesTypesAsync(projectid,xAdsRegion:XAdsRegion.US,accessToken:token);

//Get Issues
Issues issues = await issuesClient.GetIssuesAsync(projectid,xAdsRegion:XAdsRegion.US,accessToken:token);

//Get details of a issue
string issueId ="d59ba4ba-8070-474c-a0a0-adad106ae1a5";
Issue issuedetail = await issuesClient.GetIssueDetailsAsync(projectid,issueId,xAdsRegion:XAdsRegion.US,accessToken:token);

//Create Issue 
IssuePayload newIssue = new IssuePayload();
newIssue.Title = "Issue Created By using SDK ";
newIssue.Description ="Created for test";
newIssue.Status=Status.Open;
newIssue.AssignedTo="J2Q2EL4FKPKRHTKF";
newIssue.AssignedToType=AssignedToType.User;
newIssue.IssueSubtypeId="9f39edab-8773-440d-848b-99d098e86ce3";
newIssue.DueDate="2023-10-10";
var Createissue =await issuesClient.CreateIssueAsync(projectid,xAdsRegion:XAdsRegion.US,newIssue,accessToken:token);
Console.WriteLine(Createissue);


// Create Comment
CommentsPayload newcomment=new CommentsPayload();

newcomment.Body="Created a Comment for testing SDK";
CreatedComment createComment=await issuesClient.CreateCommentsAsync(projectid,issueId,xAdsRegion:XAdsRegion.US,commentsPayload:newcomment,accessToken:token);

Console.WriteLine(createComment);


//Get Comments
Comments getComments=await issuesClient.GetCommentsAsync(projectid,issueId,xAdsRegion:XAdsRegion.US,accessToken:token);
Console.WriteLine(getComments);


AttrDefinition attrDefinition = await issuesClient.GetAttributeDefinitionsAsync(projectid,xAdsRegion:XAdsRegion.US , accessToken: token);
Console.WriteLine(attrDefinition);
