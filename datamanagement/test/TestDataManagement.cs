using Autodesk.Forge.Core;
using Autodesk.DataManagement;
using Autodesk.DataManagement.Http;
using Autodesk.DataManagement.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.SDKManager;
using Type = Autodesk.DataManagement.Model.Type;
using System.Reflection.Metadata.Ecma335;
using System.Data.Common;

namespace Autodesk.DataManagement.Test;


[TestClass]
public class TestDataManagement
{
    private static DataManagementClient _dataManagementApi = null!;


    string token = Environment.GetEnvironmentVariable("THREE_LEGGED_ACCESS_TOKEN");
    string hubId = Environment.GetEnvironmentVariable("HUB_ID");
    string projectId = Environment.GetEnvironmentVariable("PROJECT_ID");
    string downloadId = Environment.GetEnvironmentVariable("DOWNLOAD_ID");
    string jobId = Environment.GetEnvironmentVariable("JOB_ID");
    string folderId = Environment.GetEnvironmentVariable("FOLDER_ID");
    string itemId = Environment.GetEnvironmentVariable("ITEM_ID");
    string versionId = Environment.GetEnvironmentVariable("VERSION_ID");
    string storageUrn = Environment.GetEnvironmentVariable("STORAGE_URN");


    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        var sdkManager = SdkManagerBuilder
                .Create() // Creates SDK Manager Builder itself.
                .Add(new ApsConfiguration())
                .Add(ResiliencyConfiguration.CreateDefault())
                .Build();

        _dataManagementApi = new DataManagementClient(sdkManager);
    }

    [TestMethod]
    public async Task TestGetHubsAsync()
    {
        Hubs getHubsResponse = await _dataManagementApi.GetHubsAsync(accessToken: token);
        Assert.IsTrue(getHubsResponse.Data.Count > 0);
    }

    [TestMethod]
    public async Task TestGetHubAsync()
    {
        Hub getHubResponse = await _dataManagementApi.GetHubAsync(hubId: hubId, accessToken: token);
        HubData getHubData = getHubResponse.Data;
        Assert.IsTrue(hubId == getHubData.Id);
    }

    [TestMethod]
    public async Task TestGetHubProjectsAsync()
    {
        Projects getHubProjects = await _dataManagementApi.GetHubProjectsAsync(hubId: hubId, accessToken: token);
        Assert.IsTrue(getHubProjects.Data.Count > 0);
    }

    [TestMethod]
    public async Task TestGetProjectAsync()
    {
        Project getHubProject = await _dataManagementApi.GetProjectAsync(hubId: hubId, projectId: projectId, accessToken: token);
        ProjectsData getHubProjectData = getHubProject.Data;
        Assert.IsTrue(projectId == getHubProjectData.Id);
    }

    [TestMethod]
    public async Task TestGetProjectHubAsync()
    {
        Hub getHub = await _dataManagementApi.GetProjectHubAsync(hubId: hubId, projectId: projectId, accessToken: token);
        HubData getHubData = getHub.Data;
        Assert.IsTrue(hubId == getHubData.Id);
    }

    [TestMethod]
    public async Task TestGetProjectTopFoldersAsync()
    {
        TopFolders projectTopFolders = await _dataManagementApi.GetProjectTopFoldersAsync(hubId: hubId, projectId: projectId, accessToken: token);
        Assert.IsTrue(projectTopFolders.Data.Count > 0);
    }

    [TestMethod]
    public async Task TestGetDownloadAsync()
    {
        DownloadDetails downloadDetails = await _dataManagementApi.GetDownloadAsync(projectId: projectId, downloadId: downloadId, accessToken: token);
        DownloadDetailsData downloadDetailsData = downloadDetails.Data;
        Assert.IsTrue(downloadId == downloadDetailsData.Id);
    }

    [TestMethod]
    public async Task TestGetDownloadJobAsync()
    {
        Job job = await _dataManagementApi.GetDownloadJobAsync(projectId: projectId, jobId: jobId, accessToken: token);
        DownloadData jobData = job.Data;
        Assert.IsTrue(jobId == jobData.Id);
    }

    [TestMethod]
    public async Task TestCreateDownloadAsync()
    {
        DownloadPayload downloadPayload = new DownloadPayload()
        {
            Jsonapi = new ModifyFolderPayloadJsonapi()
            {
                _Version = VersionNumber._10
            },
            Data = new DownloadPayloadData()
            {
                Type = Type.Downloads,
                Attributes = new DownloadPayloadDataAttributes()
                {
                    Format = new DownloadPayloadDataAttributesFormat()
                    {
                        FileType = ""
                    }
                },
                Relationships = new DownloadPayloadDataRelationships()
                {
                    Source = new FolderPayloadDataRelationshipsParent()
                    {
                        Data = new ModifyVersionPayloadData()
                        {
                            Type = Type.Versions,
                            Id = versionId
                        }
                    }
                }
            }
        };

        Download download = await _dataManagementApi.CreateDownloadAsync(projectId: projectId, downloadPayload: downloadPayload, accessToken: token);
        DownloadData downloadData = download.Data;
        Assert.IsTrue(downloadData.Type == Type.Jobs);

    }

    [TestMethod]
    public async Task TestCreateStorageAsync()
    {
        StoragePayload storagePayload = new StoragePayload()
        {
            Jsonapi = new ModifyFolderPayloadJsonapi()
            {
                _Version = VersionNumber._10
            },
            Data = new StoragePayloadData()
            {
                Type = Type.Objects,
                Attributes = new StoragePayloadDataAttributes()
                {
                    Name = "drawing.dwg"
                },
                Relationships = new StoragePayloadDataRelationships()
                {
                    Target = new ModifyFolderPayloadDataRelationshipsParent()
                    {
                        Data = new ModifyFolderPayloadDataRelationshipsParentData()
                        {
                            Type = Type.Folders,
                            Id = "urn:adsk.wipprod:fs.folder:co.mgS-lb-BThaTdHnhiN_mbA"
                        }
                    }
                }
            }
        };

        Storage storage = await _dataManagementApi.CreateStorageAsync(projectId: projectId, storagePayload: storagePayload, accessToken: token);
        StorageData storageData = storage.Data;
        Assert.IsTrue(storageData.Type == Type.Objects);
    }

    [TestMethod]
    public async Task TestGetFolderAsync()
    {
        Folder folder = await _dataManagementApi.GetFolderAsync(projectId: projectId, folderId: folderId, accessToken: token);
        FolderData folderData = folder.Data;
        Assert.IsTrue(folderId == folderData.Id);
    }

    [TestMethod]
    public async Task TestGetFolderContentsAsync()
    {
        FolderContents folderContents = await _dataManagementApi.GetFolderContentsAsync(projectId: projectId, folderId: folderId, pageLimit: 1, accessToken: token);
        Assert.IsTrue(folderContents.Data.Count > 0);
    }

    [TestMethod]
    public async Task TestGetFolderParentAsync()
    {
        Folder folder = await _dataManagementApi.GetFolderParentAsync(projectId: projectId, folderId: folderId, accessToken: token);
        FolderData folderData = folder.Data;
        Assert.IsTrue(folderData.Type == Type.Folders);
    }

    [TestMethod]
    public async Task TestGetFolderRefsAsync()
    {
        FolderRefs folderRefs = await _dataManagementApi.GetFolderRefsAsync(projectId: projectId, folderId: folderId, accessToken: token);
        Assert.IsInstanceOfType(folderRefs.Data, typeof(List<FolderRefsData>));
    }

    [TestMethod]
    public async Task TestGetFolderRelationshipsLinksAsync()
    {
        RelationshipLinks relationshipLinks = await _dataManagementApi.GetFolderRelationshipsLinksAsync(projectId: projectId, folderId: folderId, accessToken: token);
        Assert.IsInstanceOfType(relationshipLinks.Data, typeof(List<RelationshipLinksData>));
    }

    [TestMethod]
    public async Task TestGetFolderRelationshipsRefsAsync()
    {
        RelationshipRefs relationshipRefs = await _dataManagementApi.GetFolderRelationshipsRefsAsync(folderId: folderId, projectId: projectId, accessToken: token);
        Assert.IsInstanceOfType(relationshipRefs.Data, typeof(List<RelationshipRefsData>));
    }

    [TestMethod]
    public async Task TestGetFolderSearchAsync()
    {
        Search search = await _dataManagementApi.GetFolderSearchAsync(folderId: folderId, projectId: projectId, accessToken: token);
        Assert.IsTrue(search.Data.Count > 0);
    }

    [TestMethod]
    public async Task TestCreateFolderAsync()
    {
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
                    Name = "New Folder",
                    Extension = new RelationshipRefsPayloadDataMetaExtension()
                    {
                        Type = Type.FoldersautodeskBim360Folder,
                        _Version = VersionNumber._10
                    }
                },
                Relationships = new FolderPayloadDataRelationships()
                {
                    Parent = new FolderPayloadDataRelationshipsParent()
                    {
                        Data = new ModifyVersionPayloadData()
                        {
                            Type = Type.Folders,
                            Id = folderId
                        }
                    }
                }
            },
        };

        Folder folder = await _dataManagementApi.CreateFolderAsync(projectId: projectId, folderPayload: folderPayload, accessToken: token);
        FolderData folderData = folder.Data;
        Assert.IsTrue(folderData.Type == Type.Folders);
    }

    [TestMethod]
    public async Task TestCreateFolderRelationshipsRefAsync()
    {
        RelationshipRefsPayload relationshipRefsPayload = new RelationshipRefsPayload()
        {
            Jsonapi = new ModifyFolderPayloadJsonapi()
            {
                _Version = VersionNumber._10
            },
            Data = new RelationshipRefsPayloadData()
            {
                Type = Type.Versions,
                Id = versionId,
                Meta = new RelationshipRefsPayloadDataMeta()
                {
                    Extension = new RelationshipRefsPayloadDataMetaExtension()
                    {
                        Type = Type.AuxiliaryautodeskCoreAttachment,
                        _Version = VersionNumber._10
                    }
                }
            }
        };

        HttpResponseMessage relationship = await _dataManagementApi.CreateFolderRelationshipsRefAsync(folderId: folderId, projectId: projectId, relationshipRefsPayload: relationshipRefsPayload, accessToken: token);
        var statusCode = relationship.StatusCode;
        string statusCodeString = statusCode.ToString();
        Assert.IsTrue(statusCodeString == "NoContent");
    }

    [TestMethod]
    public async Task TestPatchFolderAsync()
    {
        ModifyFolderPayload modifyFolderPayload = new ModifyFolderPayload()
        {
            Jsonapi = new ModifyFolderPayloadJsonapi()
            {
                _Version = VersionNumber._10
            },
            Data = new ModifyFolderPayloadData()
            {
                Type = Type.Folders,
                Id = folderId,
                Attributes = new ModifyFolderPayloadDataAttributes()
                {
                    Name = "Drawings"
                }
            }
        };

        Folder folder = await _dataManagementApi.PatchFolderAsync(projectId: projectId, folderId: folderId, modifyFolderPayload: modifyFolderPayload, accessToken: token);
        FolderData folderData = folder.Data;
        Assert.IsTrue(folderId == folderData.Id);
    }

    [TestMethod]
    public async Task TestGetItemAsync()
    {
        Item item = await _dataManagementApi.GetItemAsync(projectId: projectId, itemId: itemId, accessToken: token);
        ItemData itemData = item.Data;
        Assert.IsTrue(itemData.Type == Type.Items);
    }

    [TestMethod]
    public async Task TestGetItemParentFolderAsync()
    {
        Folder folder = await _dataManagementApi.GetItemParentFolderAsync(projectId: projectId, itemId: itemId, accessToken: token);
        FolderData folderData = folder.Data;
        Assert.IsTrue(folderData.Type == Type.Folders);
    }

    [TestMethod]
    public async Task TestGetItemRefsAsync()
    {
        Refs refs = await _dataManagementApi.GetItemRefsAsync(projectId: projectId, itemId: itemId, accessToken: token);
        Assert.IsInstanceOfType(refs.Data, typeof(List<RefsData>));
    }

    [TestMethod]
    public async Task TestGetItemRelationshipsLinksAsync()
    {
        RelationshipLinks relationshipLinks = await _dataManagementApi.GetItemRelationshipsLinksAsync(projectId: projectId, itemId: itemId, accessToken: token);
        Assert.IsInstanceOfType(relationshipLinks.Data, typeof(List<RelationshipLinksData>));
    }

    [TestMethod]
    public async Task TestGetItemRelationshipsRefsAsync()
    {
        RelationshipRefs relationshipRefs = await _dataManagementApi.GetItemRelationshipsRefsAsync(projectId: projectId, itemId: itemId, accessToken: token);
        Assert.IsInstanceOfType(relationshipRefs.Data, typeof(List<RelationshipRefsData>));
    }

    [TestMethod]
    public async Task TestGetItemTipAsync()
    {
        ItemTip itemTip = await _dataManagementApi.GetItemTipAsync(projectId: projectId, itemId: itemId, accessToken: token);
        ItemTipData itemTipData = itemTip.Data;
        Assert.IsTrue(itemTipData.Type == Type.Versions);
    }

    [TestMethod]
    public async Task TestGetItemVersionsAsync()
    {
        Versions versions = await _dataManagementApi.GetItemVersionsAsync(projectId: projectId, itemId: itemId, accessToken: token);
        Assert.IsInstanceOfType(versions.Data, typeof(List<VersionsData>));
    }

    [TestMethod]
    public async Task TestCreateItemAsync()
    {

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
                        Type = Type.ItemsautodeskBim360File,
                        _Version = VersionNumber._10
                    }
                },
                Relationships = new ItemPayloadDataRelationships()
                {
                    Tip = new FolderPayloadDataRelationshipsParent()
                    {
                        Data = new ModifyVersionPayloadData()
                        {
                            Type = Type.Versions,
                            Id = "1"
                        }
                    },
                    Parent = new FolderPayloadDataRelationshipsParent()
                    {
                        Data = new ModifyVersionPayloadData()
                        {
                            Type = Type.Folders,
                            Id = folderId
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
                            Type = Type.VersionsautodeskBim360File,
                            _Version = VersionNumber._10
                        }
                    }
                }
            }
        };


        Item item = await _dataManagementApi.CreateItemAsync(projectId: projectId, itemPayload: itemPayload, accessToken: token);
        ItemData itemData = item.Data;
        Assert.IsTrue(itemData.Type == Type.Items);
    }

    [TestMethod]
    public async Task TestCreateItemRelationshipsRefAsync()
    {
        RelationshipRefsPayload relationshipRefsPayload = new RelationshipRefsPayload()
        {
            Jsonapi = new ModifyFolderPayloadJsonapi()
            {
                _Version = VersionNumber._10
            },
            Data = new RelationshipRefsPayloadData()
            {
                Type = Type.Versions,
                Id = versionId,
                Meta = new RelationshipRefsPayloadDataMeta()
                {
                    Extension = new RelationshipRefsPayloadDataMetaExtension()
                    {
                        Type = Type.AuxiliaryautodeskCoreAttachment,
                        _Version = VersionNumber._10
                    }
                }
            }
        };

        HttpResponseMessage responseMessage = await _dataManagementApi.CreateItemRelationshipsRefAsync(projectId: projectId, itemId: itemId, relationshipRefsPayload: relationshipRefsPayload, accessToken: token);
        var statusCode = responseMessage.StatusCode;
        string statusCodeString = statusCode.ToString();
        Assert.IsTrue(statusCodeString == "NoContent");
    }

    [TestMethod]
    public async Task TestPatchItemAsync()
    {
        ModifyItemPayload modifyItemPayload = new ModifyItemPayload()
        {
            Jsonapi = new ModifyFolderPayloadJsonapi()
            {
                _Version = VersionNumber._10
            },
            Data = new ModifyItemPayloadData()
            {
                Type = Type.Items,
                Id = itemId,
                Attributes = new
                {
                    DisplayName = "drawing.rvt"
                }
            }
        };

        Item item = await _dataManagementApi.PatchItemAsync(projectId: projectId, itemId: itemId, modifyItemPayload: modifyItemPayload, accessToken: token);
        ItemData itemData = item.Data;
        Assert.IsTrue(itemData.Type == Type.Items);
    }

    [TestMethod]
    public async Task TestGetVersionAsync()
    {
        VersionDetails versionDetails = await _dataManagementApi.GetVersionAsync(projectId: projectId, versionId: versionId, accessToken: token);
        VersionDetailsData versionDetailsData = versionDetails.Data;
        Assert.IsTrue(versionDetailsData.Type == Type.Versions);
    }

    [TestMethod]
    public async Task TestGetVersionDownloadFormatsAsync()
    {
        DownloadFormats downloadFormats = await _dataManagementApi.GetVersionDownloadFormatsAsync(projectId: projectId, versionId: versionId, accessToken: token);
        DownloadFormatsData downloadFormatsData = downloadFormats.Data;
        Assert.IsTrue(downloadFormatsData.Type == Type.DownloadFormats);
    }

    [TestMethod]
    public async Task TestGetVersionDownloadsAsync()
    {
        Downloads downloads = await _dataManagementApi.GetVersionDownloadsAsync(projectId: projectId, versionId: versionId, accessToken: token);
        Assert.IsInstanceOfType(downloads.Data, typeof(List<DownloadsData>));
    }

    [TestMethod]
    public async Task TestGetVersionItemAsync()
    {
        Item item = await _dataManagementApi.GetVersionItemAsync(projectId: projectId, versionId: versionId, accessToken: token);
        ItemData itemData = item.Data;
        Assert.IsTrue(itemData.Type == Type.Items);
    }

    [TestMethod]
    public async Task TestGetVersionRefsAsync()
    {
        Refs refs = await _dataManagementApi.GetVersionRefsAsync(projectId: projectId, versionId: versionId, accessToken: token);
        Assert.IsInstanceOfType(refs.Data, typeof(List<RefsData>));
    }

    [TestMethod]
    public async Task TestGetVersionRelationshipsLinksAsync()
    {
        RelationshipLinks relationshipLinks = await _dataManagementApi.GetVersionRelationshipsLinksAsync(projectId: projectId, versionId: versionId, accessToken: token);
        Assert.IsInstanceOfType(relationshipLinks.Data, typeof(List<RelationshipLinksData>));
    }

    [TestMethod]
    public async Task TestGetVersionRelationshipsRefsAsync()
    {
        RelationshipRefs relationshipRefs = await _dataManagementApi.GetVersionRelationshipsRefsAsync(projectId: projectId, versionId: versionId, accessToken: token);
        Assert.IsInstanceOfType(relationshipRefs.Data, typeof(List<RelationshipRefsData>));
    }

    [TestMethod]
    public async Task TestCreateVersionAsync()
    {
        VersionPayload versionPayload = new VersionPayload()
        {
            Jsonapi = new ModifyFolderPayloadJsonapi()
            {
                _Version = VersionNumber._10
            },
            Data = new VersionPayloadData()
            {
                Type = Type.Versions,
                Attributes = new VersionPayloadDataAttributes()
                {
                    Name = "drawing.rvt",
                    Extension = new RelationshipRefsPayloadDataMetaExtension()
                    {
                        Type = Type.VersionsautodeskBim360File,
                        _Version = VersionNumber._10
                    }
                },
                Relationships = new VersionPayloadDataRelationships()
                {
                    Item = new FolderPayloadDataRelationshipsParent()
                    {
                        Data = new ModifyVersionPayloadData()
                        {
                            Type = Type.Items,
                            Id = itemId
                        }
                    },
                    Storage = new FolderPayloadDataRelationshipsParent()
                    {
                        Data = new ModifyVersionPayloadData()
                        {
                            Type = Type.Objects,
                            Id = storageUrn
                        }
                    }
                }
            }
        };

        ModelVersion modelVersion = await _dataManagementApi.CreateVersionAsync(projectId: projectId, versionPayload: versionPayload, accessToken: token);
        VersionData modelVersionData = modelVersion.Data;
        Assert.IsTrue(modelVersionData.Type == Type.Versions);
    }

    [TestMethod]
    public async Task TestCreateVersionRelationshipsRefAsync()
    {
        RelationshipRefsPayload relationshipRefsPayload = new RelationshipRefsPayload()
        {
            Jsonapi = new ModifyFolderPayloadJsonapi()
            {
                _Version = VersionNumber._10
            },
            Data = new RelationshipRefsPayloadData()
            {
                Type = Type.Versions,
                Id = "urn:adsk.wipprod:fs.file:vf.ooWjwAQJR0uEoPRyfEnvew?version=1",
                Meta = new RelationshipRefsPayloadDataMeta()
                {
                    Extension = new RelationshipRefsPayloadDataMetaExtension()
                    {
                        Type = Type.AuxiliaryautodeskCoreAttachment,
                        _Version = VersionNumber._10
                    }
                }
            }
        };

        HttpResponseMessage responseMessage = await _dataManagementApi.CreateVersionRelationshipsRefAsync(projectId: projectId, versionId: versionId, relationshipRefsPayload: relationshipRefsPayload, accessToken: token);
        var statusCode = responseMessage.StatusCode;
        string statusCodeString = statusCode.ToString();
        Assert.IsTrue(statusCodeString == "NoContent");
    }

    [TestMethod]
    public async Task TestPatchVersionAsync()
    {
        ModifyVersionPayload modifyVersionPayload = new ModifyVersionPayload()
        {
            Jsonapi = new ModifyFolderPayloadJsonapi()
            {
                _Version = VersionNumber._10
            },
            Data = new ModifyItemPayloadData()
            {
                Type = Type.Versions,
                Id = versionId,
                Attributes = new
                {
                    Name = "New name for Drawing.rvt"
                }
            }
        };

        VersionDetails versionDetails = await _dataManagementApi.PatchVersionAsync(projectId: projectId, versionId: versionId, modifyVersionPayload: modifyVersionPayload, accessToken: token);
        VersionDetailsData versionDetailsData = versionDetails.Data;
        Assert.IsTrue(versionDetailsData.Type == Type.Versions);
    }

}
