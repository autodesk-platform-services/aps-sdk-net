using System.Data;
using System.Reflection.Metadata.Ecma335;
using Autodesk.Construction.AccountAdmin;
using Autodesk.Construction.AccountAdmin.Model;
using Autodesk.SDKManager;

namespace Samples
{
    class Admin
    {
        string token = "your token";

        string accountId = "your account id";
        string userId = "your user id";
        string adminUserId = "your admin user id";
        string projectId = "your project id";
        string companyId = "your company id";
        AdminClient adminClient = null!;

        public void Initialise()
        {
            // Optionally initialise SDKManager to pass custom configurations. 
            // SDKManager sdkManager = SdkManagerBuilder.Create().Build();

            StaticAuthenticationProvider staticAuthenticationProvider = new StaticAuthenticationProvider(token);
            // Instantiate AdminClient using the auth provider
            adminClient = new AdminClient(authenticationProvider: staticAuthenticationProvider);
        }

        // Get projects by account id
        public async Task getProjects()
        {
            ProjectsPage projectList = await adminClient.GetProjectsAsync(accountId: accountId, region: Region.US);
            Console.WriteLine(projectList);
        }


        // Get project details
        public async Task getProject()
        {
            Project project = await adminClient.GetProjectAsync(projectId: projectId, fields: [Fields.AccountId, Fields.Name]);
            Console.WriteLine(project);
        }

        //update project image
        public async Task updateProjectImage()
        {
            var filePath = "C:/Users/gitundh/Downloads/atc.png";
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                ProjectPatch resp = await adminClient.CreateProjectImageAsync(projectId, accountId, fileStream, Region.US);
                Console.WriteLine(resp);
            }
        }

        //Create Project 
        public async Task createProject()
        {
            ProjectPayload projectPayload = new ProjectPayload();
            projectPayload.Name = "testProjectFour";
            projectPayload.Type = "Bridge";
            projectPayload.Classification = Classification.Sample;
            projectPayload.City = "New York";
            projectPayload.Country = "United States";
            projectPayload.Timezone = Timezone.AmericaNewYork;
            projectPayload.Platform = Platform.Acc;
            Project project = await adminClient.CreateProjectAsync(accountId, projectPayload: projectPayload);
            Console.WriteLine(project);
        }


        // Get Companies by account id
        public async Task getCompanies()
        {
            List<Company> companiesList = await adminClient.GetCompaniesAsync(accountId: accountId, region: Region.US);
            foreach (var company in companiesList)
            {
                Console.WriteLine(company.Name);
                Console.WriteLine(company.Id);
            }
        }


        // Get Company details
        public async Task getCompany()
        {
            Company company = await adminClient.GetCompanyAsync(companyId: companyId, accountId: accountId);
            Console.WriteLine(company);
        }

        // Search Companies
        public async Task searchCompany()
        {
            List<Company> companyList = await adminClient.SearchCompaniesAsync(accountId: accountId);
            foreach (var company in companyList)
            {
                Console.WriteLine(company.Name);
                Console.WriteLine(company.Id);
            }
        }

        // Get Companies by project id
        public async Task getProjectCompanies()
        {
            List<ProjectCompanies> companyList = await adminClient.GetProjectCompaniesAsync(projectId: projectId, accountId: accountId, region: Region.US);
            foreach (var company in companyList)
            {
                Console.WriteLine(company.Name);
                Console.WriteLine(company.Id);
            }
        }

        // Create Company
        public async Task createCompany()
        {
            CompanyPayload companyPayload = new CompanyPayload();
            companyPayload.Name = "Test Company Five";
            companyPayload.Trade = Trade.Communications;
            companyPayload.AddressLine1 = "The Fifth Avenue";
            companyPayload.City = "New York";
            companyPayload.WebsiteUrl = "http://www.autodesk.com";
            companyPayload.Description = "This is a test company";
            Company company = await adminClient.CreateCompanyAsync(accountId, companyPayload: companyPayload);
            Console.WriteLine(company);
        }
        public async Task getCompaniesWithPagination()
        {
            // Example values for demonstration
            Region region = Region.US;
            string userId = adminUserId;
            string filterName = "004";
            string filterTrade = "Cast-in-Place";
            string filterErpId = "c79bf096-5a3e-41a4-aaf8-a771ed329047";
            string filterTaxId = "413-07-5767";
            string filterUpdatedAt = "2025-05-19T00:00:00.000Z..";
            List<CompanyOrFilters> orFilters = new List<CompanyOrFilters> { CompanyOrFilters.Name, CompanyOrFilters.Trade };
            FilterTextMatch filterTextMatch = FilterTextMatch.Equals;
            List<FilterCompanySort> sort = new List<FilterCompanySort> { FilterCompanySort.Namedesc };
            List<FilterCompanyFields> fields = new List<FilterCompanyFields> {
                FilterCompanyFields.Name,
                FilterCompanyFields.Trade,
            };
            int? limit = 1;
            int? offset = 0;

            CompaniesPage response = await adminClient.GetCompaniesWithPaginationAsync(
                accountId: accountId,
                region: region,
                userId: userId,
                filterName: filterName,
                filterTrade: filterTrade,
                filterErpId: filterErpId,
                filterTaxId: filterTaxId,
                filterUpdatedAt: filterUpdatedAt,
                orFilters: orFilters,
                filterTextMatch: filterTextMatch,
                sort: sort,
                fields: fields,
                limit: limit,
                offset: offset
            );

            // Print pagination info
            Console.WriteLine($"Limit: {response.Pagination.Limit}");
            Console.WriteLine($"Offset: {response.Pagination.Offset}");

            // Print company details
            foreach (var company in response.Results)
            {
                Console.WriteLine($"\nCompany: {company.Name}");
                Console.WriteLine($"ID: {company.Id}");
                Console.WriteLine($"Trade: {company.Trade}");
                Console.WriteLine($"TaxId: {company.TaxId}");
                Console.WriteLine($"ErpId: {company.ErpId}");
                Console.WriteLine($"UpdatedAt: {company.UpdatedAt}");
            }
        }
        // Import Companies
        public async Task importCompanies()
        {
            CompanyPayload companyPayload = new CompanyPayload();
            companyPayload.Name = "Test Companyy Furth";
            companyPayload.Trade = Trade.Communications;
            companyPayload.AddressLine1 = "The Fifth Avenue";
            companyPayload.City = "New York";
            companyPayload.WebsiteUrl = "http://www.autodesk.com";
            companyPayload.Description = "This is a test company";

            List<CompanyPayload> importCompanyPayload = [companyPayload];
            CompanyImport response = await adminClient.ImportCompaniesAsync(accountId, companyPayload: importCompanyPayload);
            Console.WriteLine(response);
        }

        //update company details
        public async Task updateCompany()
        {
            CompanyPatchPayload companyPatchPayload = new()
            {
                Trade = Trade.Concrete,
                City = "New Jersy"
            };
            Company response = await adminClient.PatchCompanyDetailsAsync(companyId, accountId, region: Region.US, companyPatchPayload: companyPatchPayload);
            Console.WriteLine(response);
        }

        //update Company image
        public async Task updateCompanyImage()
        {
            var filePath = "C:/Users/gitundh/Downloads/atc.png";
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var resp = await adminClient.PatchCompanyImageAsync(companyId, accountId, fileStream, Region.US);
                Console.WriteLine(resp);
            }
        }

        //list account users
        public async Task listUsers()
        {
            List<User> response = await adminClient.GetUsersAsync(accountId);
            Console.Write(response[0]);
        }

        //get account user details
        public async Task getUser()
        {
            User response = await adminClient.GetUserAsync(accountId, adminUserId);
            Console.WriteLine(response);
        }

        // Create new User
        public async Task createUser()
        {
            UserPayload userPayload = new UserPayload();
            userPayload.Name = "Test User Two";
            userPayload.Email = "abcTwo@autodesk.com";
            userPayload.AddressLine1 = "The Fifth Avenue";
            userPayload.City = "New York";
            userPayload.AboutMe = "This is a test user";
            User response = await adminClient.CreateUserAsync(accountId, userPayload: userPayload);
            Console.WriteLine(response);
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

            List<UserPayload> importUserPayload = [userPayload];
            UserImport response = await adminClient.ImportUsersAsync(accountId, userPayload: importUserPayload);
            Console.WriteLine(response);
        }

        //update user details
        public async Task updateUser()
        {
            UserPatchPayload userPatchPayload = new()
            {
                Status = UserPatchStatus.Active
            };
            User response = await adminClient.PatchUserDetailsAsync(accountId, userId, region: Region.US, userPatchPayload: userPatchPayload);
            Console.WriteLine(response);
        }

        // get Project Users
        public async Task getProjectUsers()
        {
            ProjectUsersPage response = await adminClient.GetProjectUsersAsync(projectId);
            Console.WriteLine(response);
        }

        public async Task getUserProjects()
        {
            List<string> filterId = new List<string> { "828e49fe-8a96-4eed-bec1-4a617bda6b09" };
            List<UserProjectFields> fields = new List<UserProjectFields> { UserProjectFields.AddressLine1, UserProjectFields.AddressLine2 };
            List<Classification> filterClassification = new List<Classification> { Classification.Sample };
            string filterName = "st";
            List<Platform> filterPlatform = new List<Platform> { Platform.Acc };
            List<Status> filterStatus = new List<Status> { Status.Active };
            List<string> filterType = new List<string> { "Demonstration Project" };
            string filterJobNumber = "1234567890";
            string filterUpdatedAt = "2024-01-23T19:46:18.160-04:00"; // not working
            List<FilterUserProjectsAccessLevels> filterAccessLevels = new List<FilterUserProjectsAccessLevels> { FilterUserProjectsAccessLevels.ProjectAdmin };
            FilterTextMatch filterTextMatch = FilterTextMatch.EndsWith;
            List<UserProjectSortBy> sort = new List<UserProjectSortBy> { UserProjectSortBy.Namedesc };
            int limit = 1;
            int offset = 2;
            UserProjectsPage response = await adminClient.GetUserProjectsAsync(accountId, userId);

            Pagination page = response.Pagination;
            Console.WriteLine(page.Limit);

            foreach (var project in response.Results)
            {
                Console.WriteLine(project.Name);
                Console.WriteLine(project.Id);
                Console.WriteLine(project.Platform);
                Console.WriteLine(project.Type);
                Console.WriteLine(project.JobNumber);
                Console.WriteLine(project.UpdatedAt);
                Console.WriteLine(project.Status);
                Console.WriteLine(project.AccessLevels);
                Console.WriteLine(project.Timezone);
            }
        }

        // fetch specified user in the project
        public async Task getProjectUser()
        {
            ProjectUser response = await adminClient.GetProjectUserAsync(projectId, userId: adminUserId);
            Console.WriteLine(response);
        }

        //assign user to project
        public async Task assignProjectUser()
        {
            ProjectUserPayload projectUserPayload = new()
            {
                Email = "xyz@autodesk.com",
                Products = [
                    new ProjectUserPayloadProducts(){
                        Key = ProductKeys.Build,
                        Access = ProductAccess.Member
                    }
                ]
            };
            ProjectUserDetails response = await adminClient.AssignProjectUserAsync(projectId, projectUserPayload: projectUserPayload);
            Console.WriteLine(response);
        }

        // import users to the specified project
        public async Task importProjectUsers()
        {
            ProjectUsersImportPayload projectUsersImportPayload = new()
            {
                Users = [
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
            ProjectUsersImport response = await adminClient.ImportProjectUsersAsync(projectId, projectUsersImportPayload: projectUsersImportPayload);
            Console.WriteLine(response);
        }

        // Update specified user's details in a project
        public async Task updateProjectUser()
        {
            ProjectUsersUpdatePayload projectUsersUpdatePayload = new()
            {
                RoleIds = [
                    "8da864e0-8a8c-424f-8a90-338cc6ea09d7",
                    "d52d31ee-00f2-43cd-ae11-32aba34490df"
                ]
            };
            ProjectUserDetails response = await adminClient.UpdateProjectUserAsync(projectId, adminUserId, projectUsersUpdatePayload: projectUsersUpdatePayload);
            Console.WriteLine(response);
        }

        // Remove the specified user from a project
        public async Task deleteProjectUser()
        {
            var response = await adminClient.RemoveProjectUserAsync(projectId, userId);
        }

        // fetch all the business units in a specific account
        public async Task getBusinessUnits()
        {
            BusinessUnits response = await adminClient.GetBusinessUnitsAsync(accountId);
            Console.Write(response);
        }

        // Create business units of a specific account
        public async Task putBusinessUnits()
        {
            BusinessUnitsPayload businessUnitsPayload = new()
            {
                BusinessUnits = [
                    new(){
                        Name =  "test unit two",
                        Description = "testing business_units API"
                    }
                ]
            };
            BusinessUnits response = await adminClient.CreateBusinessUnitsAsync(accountId, businessUnitsPayload: businessUnitsPayload);
            Console.WriteLine(response);
        }

        public static async Task Main()
        {
            Admin admin = new Admin();
            // Initialise SDKManager & AdminClient
            admin.Initialise();
            // Call respective methods
            // await admin.getProjects();
            // await admin.getProject();
            // await admin.updateProjectImage();
            // await admin.createProject();
            // await admin.getCompanies();
            // await admin.getCompany();
            // await admin.searchCompany();
            // await admin.getProjectCompanies();
            // await admin.createCompany();
            await admin.getCompaniesWithPagination();
            // await admin.importCompanies();
            // await admin.updateCompany();
            // await admin.updateCompanyImage();
            // await admin.listUsers();
            // await admin.getUser();
            // await admin.createUser();
            // await admin.importUsers();
            // await admin.updateUser();
            // await admin.getProjectUsers();
            // await admin.getUserProjects();
            // await admin.getProjectUser();
            // await admin.assignProjectUser();
            // await admin.importProjectUsers();
            // await admin.updateProjectUser();
            // await admin.deleteProjectUser();
            // await admin.getBusinessUnits();
            // await admin.putBusinessUnits();
        }
    }
}