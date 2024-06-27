using System.Data;
using System.Reflection.Metadata.Ecma335;
using Autodesk.Constructionaccountadmin;
using Autodesk.Constructionaccountadmin.Model;
using Autodesk.SDKManager;

namespace Samples
{
    class Admin
    {
        string token = "<token>";
        string accountId = "<accountId>";
        string projectId = "<projectId>";
        AdminClient adminClient = null!;

        public void Initialise()
        {
            // Instantiate SDK manager as below.  
            SDKManager sdkManager = SdkManagerBuilder
                            .Create() // Creates SDK Manager Builder itself.
                            .Build();

            // Instantiate AdminClient using the created SDK manager
            adminClient = new AdminClient(sdkManager);
        }

        // Get projects by account id
        public async Task getProjects()
        {
            Projects projectList = await adminClient.GetProjectsAsync(accessToken: token, accountId: accountId, region: Region.US);
        }


        // Get project details
        public async Task getProject()
        {
            Project project = await adminClient.GetProjectAsync(projectId: projectId, accessToken: token, fields: [Fields.AccountId, Fields.Name]);
        }

        //update project image
        public async Task updateProjectImage()
        {
            var filePath = "test.png";
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read)){
                var resp = await adminClient.CreateProjectImageAsync(projectId, accountId, fileStream, Region.US, token);
                Console.WriteLine(resp);
            }
        }

        //Create Project 
        public async Task createProject()
        {
            ProjectPayload projectPayload = new ProjectPayload();
            projectPayload.Name =  "testProject";
            projectPayload.Type = "Bridge";
            projectPayload.Classification = Classification.Sample;
            projectPayload.City = "New York";
            projectPayload.Country = "United States";
            projectPayload.Timezone = Timezone.AmericaNewYork;
            projectPayload.Platform = Platform.Acc;
            Project project = await adminClient.CreateProjectAsync(accountId, projectPayload: projectPayload , accessToken: token);
        }


        // Get Companies by account id
        public async Task getCompanies()
        {
            List<Company> companiesList = await adminClient.GetCompaniesAsync(accessToken: token, accountId: accountId, region: Region.US);
        }


        // Get Company details
        public async Task getCompany()
        {
            var companyId = "";
            Company company = await adminClient.GetCompanyAsync(companyId: companyId, accountId: accountId, accessToken: token);
        }

        // Search Companies
        public async Task searchCompany()
        {
            List<Company> companyList = await adminClient.SearchCompaniesAsync(accountId: accountId, accessToken: token);
        }

        // Get Companies by project id
        public async Task getProjectCompanies()
        {
            List<CompanyResponse> companyList = await adminClient.GetProjectCompaniesAsync(accessToken: token, projectId:projectId, accountId: accountId, region: Region.US);
        }

        // Create Company
        public async Task createCompany()
        {
            CompanyPayload companyPayload = new CompanyPayload();
            companyPayload.Name = "Test Companyy";
            companyPayload.Trade = Trade.Communications;
            companyPayload.AddressLine1 = "The Fifth Avenue";
            companyPayload.City = "New York";
            companyPayload.WebsiteUrl = "http://www.autodesk.com";
            companyPayload.Description = "This is a test company";
            Company company = await adminClient.CreateCompanyAsync(accountId,companyPayload: companyPayload, accessToken: token);
        }

        // Import Companies
        public async Task importCompanies()
        {
            CompanyPayload companyPayload = new CompanyPayload();
            companyPayload.Name = "Test Companyy";
            companyPayload.Trade = Trade.Communications;
            companyPayload.AddressLine1 = "The Fifth Avenue";
            companyPayload.City = "New York";
            companyPayload.WebsiteUrl = "http://www.autodesk.com";
            companyPayload.Description = "This is a test company";

            List<CompanyPayload> importCompanyPayload= [companyPayload];
            CompanyImportResponse response = await adminClient.ImportCompaniesAsync(accountId, accessToken: token, companyPayload: importCompanyPayload);
        }

        //update company details
        public async Task updateCompany()
        {
            var companyId = "";
            CompanyPatchPayload companyPatchPayload = new()
            {
                Trade = Trade.Concrete,
                City = "New Jersy"
            };
            Company response = await adminClient.PatchCompanyDetailsAsync(companyId, accountId, region: Region.US, accessToken: token, companyPatchPayload:companyPatchPayload);
            Console.WriteLine(response);
        }

        //update Company image
        public async Task updateCompanyImage()
        {
            var companyId = "";
            var filePath = "test.png";
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read)){
                var resp = await adminClient.PatchCompanyImageAsync(companyId, accountId, fileStream, Region.US, token);
                Console.WriteLine(resp);
            }
        }

        //list account users
        public async Task listUsers()
        {
            await adminClient.GetUsersAsync(accountId, accessToken: token);
        }

        //get account user details
        public async Task getUser()
        {
            var userId = "";
            await adminClient.GetUserAsync(accountId, userId, accessToken: token);
        }

        // Create new User
        public async Task createUser()
        {
            UserPayload userPayload = new UserPayload();
            userPayload.Name = "Test User";
            userPayload.Email = "abc@autodesk.com";
            userPayload.AddressLine1 = "The Fifth Avenue";
            userPayload.City = "New York";
            userPayload.AboutMe = "This is a test user";
            User response = await adminClient.CreateUserAsync(accountId, userPayload: userPayload, accessToken: token);
        }

        // Import Users
        public async Task importUsers()
        {
            UserPayload userPayload = new UserPayload();
            userPayload.Name = "Test User";
            userPayload.Email = "abc@autodesk.com";
            userPayload.AddressLine1 = "The Fifth Avenue";
            userPayload.City = "New York";
            userPayload.AboutMe = "This is a test user";

            List<UserPayload> importUserPayload= [userPayload];
            UserImportResponse response = await adminClient.ImportUsersAsync(accountId, accessToken: token, userPayload: importUserPayload);
        }

        //update user details
        public async Task updateUser()
        {
            var userId = "";
            UserPatchPayload userPatchPayload = new()
            {
                Status =  UserPatchStatus.Active
            };
            User response = await adminClient.PatchUserDetailsAsync( accountId, userId, region: Region.US, accessToken: token, userPatchPayload: userPatchPayload);
            Console.WriteLine(response);
        }

        // get Project Users
        public async Task getProjectUsers() {
            ProjectUsers response = await adminClient.GetProjectUsersAsync(projectId, accessToken:token);
        }

        // fetch specified user in the project
        public async Task getProjectUser() {
            var userId = "";
            ProjectUser response = await adminClient.GetProjectUserAsync(projectId, userId: userId, accessToken: token);
        }

        //assign user to project
        public async Task assignProjectUser() {
            ProjectUserPayload projectUserPayload = new()
            {
                Email =  "xyz@autodesk.com",
                Products = [
                    new ProjectUserPayloadProducts(){
                        Key = ProductKeys.Build,
                        Access = ProductAccess.Member
                    }
                ]
            };
            var response = await adminClient.AssignProjectUserAsync(projectId, projectUserPayload: projectUserPayload, accessToken: token);
        }

        // import users to the specified project
        public async Task importProjectUsers() {
            ProjectUsersImportPayload projectUsersImportPayload = new(){
                Users =  [
                    new ProjectUsersImportPayloadUsers(){
                        Email = "harry.potter@hmail.com",
                        Products = [
                            new ProjectUsersImportPayloadUsersProducts(){
                                Key = ProductKeys.ProjectAdministration,
                                Access = ProductAccess.Administrator
                            }
                        ]
                    }
                ]
            };
            ProjectUsersImportResponse response = await adminClient.ImportProjectUsersAsync(projectId, accessToken: token, projectUsersImportPayload: projectUsersImportPayload);
        }

        // Update specified user's details in a project
        public async Task updateProjectUser() {
            ProjectUsersUpdatePayload projectUsersUpdatePayload = new(){
                CompanyId = "0cc4c32a-6ef9-471a-993e-8776c994d257",
                RoleIds = [
                    "8da864e0-8a8c-424f-8a90-338cc6ea09d7",
                    "d52d31ee-00f2-43cd-ae11-32aba34490df"
                ]
            };
            ProjectUserResponse response = await adminClient.UpdateProjectUserAsync(projectId, "4ca99e9a-cce9-40a1-abb7-d69a1fd79178", accessToken: token, projectUsersUpdatePayload: projectUsersUpdatePayload);
        }

        // Remove the specified user from a project
        public async Task deleteProjectUser() {
            var response = await adminClient.RemoveProjectUserAsync(projectId, "4ca99e9a-cce9-40a1-abb7-d69a1fd79178", accessToken: token);
        }

        // fetch all the business units in a specific account
        public async Task getBusinessUnits() {
            BusinessUnitsResponse response = await adminClient.GetBusinessUnitsAsync(accountId, accessToken: token);
        }

        // Create business units of a specific account
        public async Task putBusinessUnits() {
            BusinessUnitsRequestPyload businessUnitsRequestPyload = new(){
                BusinessUnits = [
                    new(){
                        Name =  "test unit",
                        Description = "testing business_units API"
                    }
                ]
            };
            BusinessUnitsResponse response = await adminClient.CreateBusinessUnitsAsync(accountId ,accessToken: token, businessUnitsRequestPyload: businessUnitsRequestPyload);
        }

        public async void Main()
        {
            // Initialise SDKManager & AdminClient
            Initialise();
            // Call respective methods
            await getProject();
            await getProjects();
            await createProject();
            await updateProjectImage();
            await createCompany();
            await importCompanies();
            await updateCompany();
            await updateCompanyImage();
        }
    }
}

