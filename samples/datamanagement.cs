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
FolderPayload folderPayload = new FolderPayload()
{
    Jsonapi = new ModifyFolderPayloadJsonapi()
    {
        _Version = VersionNumber._10
    },
    Data = new FolderPayloadData()
    {
        Type = Type.Folders,
        Attributes = new FolderPayloadDataAttributes()
        {
            Name = "folder",
            Extension = new RelationshipRefsPayloadDataMetaExtension()
            {
                Type = Type.FoldersautodeskCoreFolder,
                _Version = VersionNumber._10
            }
        },
        Relationships = new FolderPayloadDataRelationships()
        {
            Parent = new FolderPayloadDataRelationshipsParent()
            {
                Data = new FolderPayloadDataRelationshipsParentData()
                {
                    Type = Type.Folders,
                    Id = folderId
                }
            }
        }
    },
};

// Creates a new folder.
Folder folder = await _dataManagementApi.CreateFolderAsync(projectId: projectId, folderPayload: folderPayload, accessToken: token);

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



// Describe item to be created
ItemPayload itemPayload = new ItemPayload()
{
    Jsonapi = new ModifyFolderPayloadJsonapi()
    {
        _Version = VersionNumber._10
    },
    Data = new ItemPayloadData()
    {
        Type = Type.Items,
        Attributes = new ItemPayloadDataAttributes()
        {
            DisplayName = "drawing.dwg",
            Extension = new ItemPayloadDataAttributesExtension()
            {
                Type = Type.ItemsautodeskCoreFile,
                _Version = VersionNumber._10
            }
        },
        Relationships = new ItemPayloadDataRelationships()
        {
            Tip = new FolderPayloadDataRelationshipsParent()
            {
                Data = new FolderPayloadDataRelationshipsParentData()
                {
                    Type = Type.Versions,
                    Id = "1"
                }
            },
            Parent = new FolderPayloadDataRelationshipsParent()
            {
                Data = new FolderPayloadDataRelationshipsParentData()
                {
                    Type = Type.Versions,
                    Id = "1"
                }
            }
        }
    },
    Included = new List<ItemPayloadIncluded>()
            {
                new ItemPayloadIncluded()
                {
                    Type = Type.Versions,
                    Id = "1",
                    Attributes = new ItemPayloadIncludedAttributes()
                    {
                        Name = "drawing.dwg",
                        Extension = new ItemPayloadDataAttributesExtension()
                        {
                            Type = Type.VersionsautodeskCoreFile,
                            _Version = VersionNumber._10
                        }
                    }
                }
            }
};


Item createdItem = await _dataManagementApi.CreateItemAsync(projectId: projectId, itemPayload: itemPayload, accessToken: token);

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


// Describe the version to be created.
VersionPayload versionPayload = new VersionPayload()
{
    Jsonapi = new ModifyFolderPayloadJsonapi()
    {
        _Version = VersionNumber._10
    },
    Data = new VersionPayloadData()
    {
        Type = Type.Items,
        Attributes = new VersionPayloadDataAttributes()
        {
            Name = "drawing.dwg",
            Extension = new RelationshipRefsPayloadDataMetaExtension()
            {
                Type = Type.VersionsautodeskCoreFile,
                _Version = VersionNumber._10
            }
        },
        Relationships = new VersionPayloadDataRelationships()
        {
            Item = new FolderPayloadDataRelationshipsParent()
            {
                Data = new FolderPayloadDataRelationshipsParentData()
                {
                    Type = Type.Items,
                    Id = "urn:adsk.wipprod:dm.lineage:AeYgDtcTSuqYoyMweWFhhQ"
                }
            },
            Storage = new FolderPayloadDataRelationshipsParent()
            {
                Data = new FolderPayloadDataRelationshipsParentData()
                {
                    Type = Type.Objects,
                    Id = "urn:adsk.objects:os.object:wip.dm.prod/980cff2c-f0f8-43d9-a151-4a2d916b91a2.dwg"
                }
            }
        }
    }
};

ModelVersion createdVersion = await _dataManagementApi.CreateVersionAsync(projectId: projectId, versionPayload: versionPayload, accessToken: token);

string createdVersionJsonapiVersion = createdVersion.Jsonapi._Version;

string createdVersionLinks = createdVersion.Links.Self.Href;

string createdVersionDataType = createdVersion.Data.Type;
string createdVersionDataId = createdVersion.Data.Id;
string createdVersionDataLinksSelf = createdVersion.Data.Links.Self.Href;
string createdVersionDataLinksWebView = createdVersion.Data.Links.WebView.Href;






