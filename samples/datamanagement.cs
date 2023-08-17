using Autodesk.DataManagement;
using Autodesk.DataManagement.Http;
using Autodesk.DataManagement.Model;
using Autodesk.SDKManager;
using Type = Autodesk.DataManagement.Model.Type;


var token = "<token>";
string hub_id = "<hub-id>";
string project_id = "<project-id>";
string folder_id = "<folder-id>";

SDKManager sdkManager = SdkManagerBuilder
      .Create()
      .Add(new ApsConfiguration())
      .Add(ResiliencyConfiguration.CreateDefault())
      .Build();

//Hubs
DataManagementClient _dataManagementApi = new DataManagementClient(sdkManager);

//Returns a collection of accessible hubs for this member.
Hubs getHubs = await _dataManagementApi.GetHubsAsync(accessToken: token);
// Get list of hubs data
List<HubsData> getHubsData = getHubs.Data;
foreach (var currentHub in getHubsData)
{
    string hubsType = currentHub.Type;
    string HubsId = currentHub.Id;

    // Atrributes
    HubsDataAttributes hubsAttributes = currentHub.Attributes;
    string hubsAttributeName = hubsAttributes.Name;
    string hubsAttributesRegion = hubsAttributes.Region;

    HubsDataAttributesExtension hubsDataAttributesExtension = hubsAttributes.Extension;
    string hubsDataAttributesExtensionType = hubsDataAttributesExtension.Type;
    string hubsDataAttributesExtensionVersion = hubsDataAttributesExtension._Version;

    Object hubsAttributesExtensionData = hubsDataAttributesExtension.Data;

    HubsLinksSelf hubsAttributesExtensionSchema = hubsDataAttributesExtension.Schema;
    string hubsAttributesExtensionSchemaHref = hubsAttributesExtensionSchema.Href;
}


// Returns data on a specific hub_id.
Hub getHub = await _dataManagementApi.GetHubAsync(hubId: hub_id, accessToken: token);

HubData getHubData = getHub.Data;
string hubType = getHubData.Type;
string hubId = getHubData.Id;

// Atrributes
HubDataAttributes hubAttributes = getHubData.Attributes;
string hubAttributeName = hubAttributes.Name;
string hubAttributesRegion = hubAttributes.Region;

HubDataAttributesExtension hubAttributesExtension = hubAttributes.Extension;
string hubAttributesExtensionType = hubAttributesExtension.Type;
string hubAttributesExtensionVersion = hubAttributesExtension._Version;

Object hubAttributesExtensionData = hubAttributesExtension.Data;

HubsLinksSelf hubAttributesExtensionSchema = hubAttributesExtension.Schema;
string hubAttributesExtensionSchemaHref = hubAttributesExtensionSchema.Href;



// Projects

//Returns a collection of projects for a given hub_id
Projects getHubProjects = await _dataManagementApi.GetHubProjectsAsync(hubId: hub_id, accessToken: token);

List<ProjectsData> getHubProjectsData = getHubProjects.Data;
foreach (var currentProject in getHubProjectsData)
{
    string hubProjectsType = currentProject.Type;
    string hubProjectsId = currentProject.Id;

    // Attributes
    ProjectsDataAttributes hubProjectsAttributes = currentProject.Attributes;
    string hubProjectsAttributesName = hubProjectsAttributes.Name;

    List<Object> hubProjectsAttributesScopes = hubProjectsAttributes.Scopes;
    foreach (var scope in hubProjectsAttributesScopes)
    {
        Console.WriteLine(scope);
    }

    ProjectsDataAttributesExtension hubProjectsAttributesExtension = hubProjectsAttributes.Extension;
    string hubProjectsAttributesExtensionType = hubProjectsAttributesExtension.Type;
    string hubProjectsAttributesExtensionVersion = hubProjectsAttributesExtension._Version;

    Object hubProjectsAttributesExtensionData = hubProjectsAttributesExtension.Data;

    HubsLinksSelf hubProjectsAttributesExtensionSchema = hubProjectsAttributesExtension.Schema;
    string hubProjectsAttributesExtensionSchemaHref = hubProjectsAttributesExtensionSchema.Href;
}


//Returns a project for a given project_id
Project getHubProject = await _dataManagementApi.GetProjectAsync(hubId: hub_id, projectId: project_id, accessToken: token);

ProjectsData getHubProjectData = getHubProject.Data;

string getHubProjectDataType = getHubProjectData.Type;
string getHubProjectDataId = getHubProjectData.Id;

// Attributes
ProjectsDataAttributes hubProjectAttributes = getHubProjectData.Attributes;
string hubProjectAttributesName = hubProjectAttributes.Name;

List<Object> hubProjectAttributesScopes = hubProjectAttributes.Scopes;
foreach (var scope in hubProjectAttributesScopes)
{
    Console.WriteLine(scope);
}

ProjectsDataAttributesExtension hubProjectAttributesExtension = hubProjectAttributes.Extension;
string hubProjectAttributesExtensionType = hubProjectAttributesExtension.Type;
string hubProjectAttributesExtensionVersion = hubProjectAttributesExtension._Version;

Object hubProjectAttributesExtensionData = hubProjectAttributesExtension.Data;

HubsLinksSelf hubProjectAttributesExtensionSchema = hubProjectAttributesExtension.Schema;
string hubProjectAttributesExtensionSchemaHref = hubProjectAttributesExtensionSchema.Href;


// Returns the details of the highest level folders the user has access to for a given project
TopFolders projectTopFolders = await _dataManagementApi.GetProjectTopFoldersAsync(hubId: hub_id, projectId: project_id, accessToken: token);

string projectTopFoldersJsonapiVersion = projectTopFolders.Jsonapi._Version;
string projectTopFoldersLinksSelfHref = projectTopFolders.Links.Self.Href;

List<TopFoldersData> topFoldersData = projectTopFolders.Data;
foreach (var topFolder in topFoldersData)
{
    string topFolderDataAttributesName = topFolder.Attributes.Name;
    string topFolderDataAttributesDisplayName = topFolder.Attributes.DisplayName;

    string topFolderDataAttributesExtensionType = topFolder.Attributes.Extension.Type;
    string topFolderDataAttributesExtensionVersion = topFolder.Attributes.Extension._Version;
    string topFolderDataAttributesExtensionSchemaHref = topFolder.Attributes.Extension.Schema.Href;

}



// Folders

// Describe the folder to be created
CreateFolder createFolder = new CreateFolder();
createFolder.Jsonapi._Version = VersionNumber._10;
CreateFolderData createFolderData = createFolder.Data;
createFolderData.Type = Type.Folders;
CreateFolderDataAttributes createFolderDataAttributes = createFolderData.Attributes;
createFolderDataAttributes.Name = "Plans";
CreateFolderDataAttributesExtension createFolderDataAttributesExtension = createFolderDataAttributes.Extension;
createFolderDataAttributesExtension.Type = Type.FoldersautodeskCoreFolder;
createFolderDataAttributesExtension._Version = VersionNumber._10;
CreateFolderDataRelationships createFolderDataRelationships = createFolderData.Relationships;
StorageRequestDataRelationshipsTarget createFolderDataRelationshipsParent = createFolderDataRelationships.Parent;
StorageRequestDataRelationshipsTargetData createFolderDataRelationshipsParentData = createFolderDataRelationshipsParent.Data;
createFolderDataRelationshipsParentData.Type = Type.Folders;
createFolderDataRelationshipsParentData.Id = "urn:adsk.wipprod:dm.folder:sdfedf8wefl";

// Creates a new folder.
Folder createdFolder = await _dataManagementApi.CreateFolderAsync(projectId: project_id, createFolder: createFolder, accessToken: token);

FolderData createdFolderData = createdFolder.Data;
string createdFolderDataType = createdFolderData.Type;
string createdFolderDataId = createdFolderData.Id;
FolderDataAttributes createdFolderDataAttributes = createdFolderData.Attributes;
string createdFolderDataAttributesName = createdFolderDataAttributes.Name;
string createdFolderDataAttributesDisplayName = createdFolderDataAttributes.DisplayName;
string createdFolderDataAttributesCreateTime = createdFolderDataAttributes.CreateTime;
string createdFolderDataAttributesCreateUserId = createdFolderDataAttributes.CreateUserId;
string createdFolderDataAttributesCreateUserName = createdFolderDataAttributes.CreateUserName;
string createdFolderDataAttributesLastModifiedTime = createdFolderDataAttributes.LastModifiedTime;
string createdFolderDataAttributesLastModifiedUserId = createdFolderDataAttributes.LastModifiedUserId;
string createdFolderDataAttributesLastModifiedUserName = createdFolderDataAttributes.LastModifiedUserName;
string createdFolderDataAttributesLastModifiedTimeRollup = createdFolderDataAttributes.LastModifiedTimeRollup;
decimal? createdFolderDataAttributesObjectCount = createdFolderDataAttributes.ObjectCount;
bool? createdFolderDataAttributesHidden = createdFolderDataAttributes.Hidden;

FolderDataAttributesExtension createdFolderDataAttributesExtension = createdFolderDataAttributes.Extension;
string createdFolderDataAttributesExtensionType = createdFolderDataAttributesExtension.Type;
string createdFolderDataAttributesExtensionVersion = createdFolderDataAttributesExtension._Version;

HubsLinksSelf createdFolderDataAttributesExtensionSchema = createdFolderDataAttributesExtension.Schema;
string createdFolderDataAttributesExtensionSchemaHref = createdFolderDataAttributesExtensionSchema.Href;

FolderDataAttributesExtensionData createdFolderDataAttributesExtensionData = createdFolderDataAttributesExtension.Data;
List<Object> createdFolderDataAttributesExtensionDataAllowedTypes = createdFolderDataAttributesExtensionData.AllowedTypes;
foreach (var allowedType in createdFolderDataAttributesExtensionDataAllowedTypes)
{
    Console.WriteLine(allowedType);
}

List<Object> createdFolderDataAttributesExtensionDataVisibleTypes = createdFolderDataAttributesExtensionData.VisibleTypes;
foreach (var visibleType in createdFolderDataAttributesExtensionDataVisibleTypes)
{
    Console.WriteLine(visibleType);
}

List<Object> createdFolderDataAttributesExtensionDataNamingStandardIds = createdFolderDataAttributesExtensionData.NamingStandardIds;
foreach (var namingStandardId in createdFolderDataAttributesExtensionDataNamingStandardIds)
{
    Console.WriteLine(namingStandardId);
}


// Returns a collection of items and folders within a folder
FolderContents folderContents = await _dataManagementApi.GetFolderContentsAsync(projectId: project_id, folderId: folder_id, accessToken: token);

string folderContentsJsonapiVersion = folderContents.Jsonapi._Version;

string folderContentsLinksSelfHref = folderContents.Links.Self.Href;
string folderContentsLinksFirstHref = folderContents.Links.First.Href;
string folderContentsLinksPrevHref = folderContents.Links.Prev.Href;
string folderContentsLinksNextHref = folderContents.Links.Next.Href;

List<FolderContentsData> folderContentsData = folderContents.Data;
foreach (var contentData in folderContentsData)
{
    string contentDataType = contentData.Type;
    string contentDataId = contentData.Id;

    string contentDataAttributesName = contentData.Attributes.Name;
    string contentDataAttributesDisplayName = contentData.Attributes.DisplayName;

    string contentDataAttributesExtensionType = contentData.Attributes.Extension.Type;
    string contentDataAttributesExtensionVersion = contentData.Attributes.Extension._Version;
}


// Returns the parent folder (if it exists)
Folder parentFolder = await _dataManagementApi.GetFolderParentAsync(projectId: project_id, folderId: folder_id, accessToken: token);

string parentFolderJsonapiVersion = parentFolder.Jsonapi._Version;

string parentFolderLinksSelfHref = parentFolder.Links.Self.Href;

string parentFolderDataType = parentFolder.Data.Type;
string parentFolderDataId = parentFolder.Data.Id;

string parentFolderDataAttributesName = parentFolder.Data.Attributes.Name;
string parentFolderDataAttributesDisplayName = parentFolder.Data.Attributes.DisplayName;
string parentFolderDataAttributesExtensionType = parentFolder.Data.Attributes.Extension.Type;
string parentFolderDataAttributesExtensionVersion = parentFolder.Data.Attributes.Extension._Version;


// Items
ItemsApi _itemsApi = new ItemsApi(sdkManager);


// Describe item to be created
CreateItem createItem = new CreateItem();

createItem.Jsonapi._Version = VersionNumber._10;

createItem.Data.Type = Type.Items;
createItem.Data.Attributes.DisplayName = "drawing.dwg";
createItem.Data.Attributes.Extension.Type = Type.ItemsautodeskCoreFile;
createItem.Data.Attributes.Extension._Version = VersionNumber._10;
createItem.Data.Relationships.Tip.Data.Type = Type.Versions;
createItem.Data.Relationships.Tip.Data.Id = "1";
createItem.Data.Relationships.Parent.Data.Type = Type.Folders;
createItem.Data.Relationships.Parent.Data.Id = "urn:adsk.wipprod:fs.folder:co.mgS-lb-BThaTdHnhiN_mbA";

List<CreateItemIncluded> Included = createItem.Included;
foreach (var included in Included)
{
    included.Type = Type.Versions;
    included.Id = "1";
    included.Attributes.Name = "drawing.dwg";
    included.Attributes.Extension.Type = Type.VersionsautodeskCoreFile;
    included.Attributes.Extension._Version = VersionNumber._10;

    included.Relationships.Storage.Data.Type = Type.Objects;
    included.Relationships.Storage.Data.Id = "urn:adsk.objects:os.object:wip.dm.prod/2a6d61f2-49df-4d7b-9aed-439586d61df7.dwg";
}

// Creates the first version of a file (item)
Item createdItem = await _dataManagementApi.CreateItemAsync(projectId: project_id, createItem: createItem, accessToken: token);

string createdItemJsonapiVersion = createdItem.Jsonapi._Version;

string createdItemLinks = createdItem.Links.Self.Href;

string createdItemDataType = createdItem.Data.Type;
string createdItemDataId = createdItem.Data.Id;

string createdItemDataAttributesDisplayName = createdItem.Data.Attributes.DisplayName;
string createdItemDataAttributesCreateTime = createdItem.Data.Attributes.CreateTime;
string createdItemDataAttributesCreateUserId = createdItem.Data.Attributes.CreateUserId;
string createdItemDataAttributesCreateUserName = createdItem.Data.Attributes.CreateUserName;
string createdItemDataAttributesLastModifiedTime = createdItem.Data.Attributes.LastModifiedTime;
string createdItemDataAttributesLastModifiedUserId = createdItem.Data.Attributes.LastModifiedUserId;
string createdItemDataAttributesLastModifiedUserName = createdItem.Data.Attributes.LastModifiedUserName;
bool? createdItemDataAttributesHidden = createdItem.Data.Attributes.Hidden;
bool? createdItemDataAttributesReserved = createdItem.Data.Attributes.Reserved;
string createdItemDataAttributesExtensionType = createdItem.Data.Attributes.Extension.Type;
string createdItemDataAttributesExtensionVersion = createdItem.Data.Attributes.Extension._Version;


// Versions
VersionsApi _versionsApi = new VersionsApi(sdkManager);

// Describe the version to be created.
CreateVersion createVersion = new CreateVersion();

createVersion.Jsonapi._Version = VersionNumber._10;
createVersion.Data.Type = Type.Versions;
createVersion.Data.Attributes.Name = "drawing.dwg";
createVersion.Data.Attributes.Extension.Type = "versions:autodesk.core:File";
createVersion.Data.Attributes.Extension._Version = "1.0";

createVersion.Data.Relationships.Item.Data.Type = Type.Items;
createVersion.Data.Relationships.Item.Data.Id = "urn:adsk.wipprod:dm.lineage:AeYgDtcTSuqYoyMweWFhhQ";

createVersion.Data.Relationships.Storage.Data.Type = Type.Objects;
createVersion.Data.Relationships.Storage.Data.Id = "urn:adsk.objects:os.object:wip.dm.prod/980cff2c-f0f8-43d9-a151-4a2d916b91a2.dwg";

// Creates new versions of a file (item), except for the first version of the item
CreatedVersion createdVersion = await _dataManagementApi.CreateVersionAsync(projectId: project_id, createVersion: createVersion, accessToken: token);

string createdVersionJsonapiVersion = createdVersion.Jsonapi._Version;

string createdVersionLinks = createdVersion.Links.Self.Href;

string createdVersionDataType = createdVersion.Data.Type;
string createdVersionDataId = createdVersion.Data.Id;
string createdVersionDataLinksSelf = createdVersion.Data.Links.Self.Href;
string createdVersionDataLinksWebView = createdVersion.Data.Links.WebView.Href;






