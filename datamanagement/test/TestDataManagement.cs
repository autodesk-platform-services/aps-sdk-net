using Autodesk.DataManagement.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.SDKManager;

namespace Autodesk.DataManagement.Test;

[TestClass]
public class TestDataManagement
{
    private static DataManagementClient _DataManagement = null!;
       
    string? token = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
    string? hubId = Environment.GetEnvironmentVariable("HUB_ID");
    string? projectId = Environment.GetEnvironmentVariable("PROJECT_ID");
    string? downloadId = Environment.GetEnvironmentVariable("DOWNLOAD_ID");
    string? jobId = Environment.GetEnvironmentVariable("JOB_ID");
    string? folderId = Environment.GetEnvironmentVariable("FOLDER_ID");
    string? itemId = Environment.GetEnvironmentVariable("ITEM_ID");
    string? versionId = Environment.GetEnvironmentVariable("VERSION_ID");

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        var sdkManager = SdkManagerBuilder
                .Create() // Creates SDK Manager Builder itself.
                .Add(new ApsConfiguration())
                .Add(ResiliencyConfiguration.CreateDefault())
                .Build();

        _DataManagement = new DataManagementClient(sdkManager);
    }

    [TestMethod]
    public async Task TestGetHubsAsync()
    {
        Hubs getHubsResponse = await _DataManagement.GetHubsAsync(accessToken: token);
        Assert.IsTrue(getHubsResponse.Data.Count > 0);
    }

    [TestMethod]
    public async Task TestGetHubAsync()
    {
        Hub getHubResponse = await _DataManagement.GetHubAsync(hubId: hubId, accessToken: token);
        HubData getHubData = getHubResponse.Data;
        Assert.IsTrue(hubId == getHubData.Id);
    }

    [TestMethod]
    public async Task TestGetHubProjectsAsync()
    {
        Projects getHubProjects = await _DataManagement.GetHubProjectsAsync(hubId: hubId, accessToken: token);
        Assert.IsTrue(getHubProjects.Data.Count > 0);
    }

    [TestMethod]
    public async Task TestGetProjectAsync()
    {
        Project getHubProject = await _DataManagement.GetProjectAsync(hubId: hubId, projectId: projectId, accessToken: token);
        ProjectData getHubProjectData = getHubProject.Data;
        Assert.IsTrue(projectId == getHubProjectData.Id);
    }

    [TestMethod]
    public async Task TestGetProjectHubAsync()
    {
        Hub getHub = await _DataManagement.GetProjectHubAsync(hubId: hubId, projectId: projectId, accessToken: token);
        HubData getHubData = getHub.Data;
        Assert.IsTrue(hubId == getHubData.Id);
    }

    [TestMethod]
    public async Task TestGetProjectTopFoldersAsync()
    {
        TopFolders projectTopFolders = await _DataManagement.GetProjectTopFoldersAsync(hubId: hubId, projectId: projectId, accessToken: token);
        Assert.IsTrue(projectTopFolders.Data.Count > 0);
    }

    // [TestMethod]
    // public async Task TestGetDownloadAsync()
    // {
    //     Download downloadDetails = await _DataManagement.GetDownloadAsync(projectId: projectId, downloadId: downloadId, accessToken: token);
    //     DownloadData downloadDetailsData = downloadDetails.Data;
    //     Assert.IsTrue(downloadId == downloadDetailsData.Id);
    // }

    // [TestMethod]
    // public async Task TestGetDownloadJobAsync()
    // {
    //     Job job = await _DataManagement.GetDownloadJobAsync(projectId: projectId, jobId: jobId, accessToken: token);
    //     JobData jobData = job.Data;
    //     Assert.IsTrue(jobId == jobData.Id);
    // }

    // [TestMethod]
    // public async Task TestCreateDownloadAsync()
    // {
    //     DownloadPayload downloadPayload = new DownloadPayload()
    //     {
    //         Jsonapi = new JsonApiVersion()
    //         {
    //             VarVersion = VersionNumber._10
    //         },
    //         Data = new DownloadPayloadData()
    //         {
    //             Type = Type.Downloads,
    //             Attributes = new DownloadPayloadDataAttributes()
    //             {
    //                 Format = new DownloadPayloadDataAttributesFormat()
    //                 {
    //                     FileType = "rvt"
    //                 }
    //             },
    //             Relationships = new DownloadPayloadDataRelationships()
    //             {
    //                 Source = new DownloadPayloadDataRelationshipsSource()
    //                 {
    //                     Data = new DownloadPayloadDataRelationshipsSourceData()
    //                     {
    //                         Type = Type.Versions,
    //                         Id = versionId
    //                     }
    //                 }
    //             }
    //         }
    //     };

    //     CreatedDownload createdDownload = await _DataManagement.StartDownloadAsync(projectId: projectId, downloadPayload: downloadPayload, accessToken: token);
    //     List<CreatedDownloadData> downloadData = createdDownload.Data;
    //     Assert.AreNotSame(downloadData, null);
    //     // Assert.IsTrue(downloadData, typeof(List<CreatedDownloadData>));
    // }

    // [TestMethod]
    // public async Task TestCreateStorageAsync()
    // {
    //     StoragePayload storagePayload = new StoragePayload()
    //     {
    //         Jsonapi = new ModifyFolderPayloadJsonapi()
    //         {
    //             _Version = VersionNumber._10
    //         },
    //         Data = new StoragePayloadData()
    //         {
    //             Type = Type.Objects,
    //             Attributes = new StoragePayloadDataAttributes()
    //             {
    //                 Name = "drawing.dwg"
    //             },
    //             Relationships = new StoragePayloadDataRelationships()
    //             {
    //                 Target = new ModifyFolderPayloadDataRelationshipsParent()
    //                 {
    //                     Data = new ModifyFolderPayloadDataRelationshipsParentData()
    //                     {
    //                         Type = Type.Folders,
    //                         Id = "urn:adsk.wipprod:fs.folder:co.mgS-lb-BThaTdHnhiN_mbA"
    //                     }
    //                 }
    //             }
    //         }
    //     };

    //     Storage storage = await _DataManagement.CreateStorageAsync(projectId: projectId, storagePayload: storagePayload, accessToken: token);
    //     StorageData storageData = storage.Data;
    //     Assert.IsTrue(storageData.Type == Type.Objects);
    // }

    [TestMethod]
    public async Task TestGetFolderAsync()
    {
        Folder folder = await _DataManagement.GetFolderAsync(projectId: projectId, folderId: folderId, accessToken: token);
        FolderData folderData = folder.Data;
        Assert.IsTrue(folderId == folderData.Id);
    }

    [TestMethod]
    public async Task TestGetFolderContentsAsync()
    {
        FolderContents folderContents = await _DataManagement.GetFolderContentsAsync(projectId: projectId, folderId: folderId, accessToken: token);
        Assert.IsTrue(folderContents.Data.Count > 0);
    }

    [TestMethod]
    public async Task TestGetFolderParentAsync()
    {
        Folder folder = await _DataManagement.GetFolderParentAsync(projectId: projectId, folderId: folderId, accessToken: token);
        FolderData folderData = folder.Data;
      Assert.IsTrue(folderData.Type == TypeFolder.Folders);
    }

    [TestMethod]
    public async Task TestGetFolderRefsAsync()
    {
        FolderRefs folderRefs = await _DataManagement.GetFolderRefsAsync(projectId: projectId, folderId: folderId, accessToken: token);
        Assert.IsInstanceOfType(folderRefs.Data, typeof(List<IFolderRefsData>));
    }

    [TestMethod]
    public async Task TestGetFolderRelationshipsLinksAsync()
    {
        RelationshipLinks relationshipLinks = await _DataManagement.GetFolderRelationshipsLinksAsync(projectId: projectId, folderId: folderId, accessToken: token);
        Assert.IsInstanceOfType(relationshipLinks.Data, typeof(List<RelationshipLinksData>));
    }

    [TestMethod]
    public async Task TestGetFolderRelationshipsRefsAsync()
    {
        RelationshipRefs relationshipRefs = await _DataManagement.GetFolderRelationshipsRefsAsync(folderId: folderId, projectId: projectId, accessToken: token);
        Assert.IsTrue(relationshipRefs.Data.Count > 0);
    }

    [TestMethod]
    public async Task TestGetFolderSearchAsync()
    {
        Search search = await _DataManagement.GetFolderSearchAsync(folderId: folderId, projectId: projectId, accessToken: token);
        Assert.IsTrue(search.Data.Count > 0);
    }

    // [TestMethod]
    // public async Task TestCreateFolderAsync()
    // {
    //     FolderPayload folderPayload = new FolderPayload()
    //     {
    //         Jsonapi = new ModifyFolderPayloadJsonapi()
    //         {
    //             _Version = VersionNumber._10
    //         },
    //         Data = new FolderPayloadData()
    //         {
    //             Type = Type.Folders,
    //             Attributes = new FolderPayloadDataAttributes()
    //             {
    //                 Name = "folder",
    //                 Extension = new RelationshipRefsPayloadDataMetaExtension()
    //                 {
    //                     Type = Type.FoldersautodeskCoreFolder,
    //                     _Version = VersionNumber._10
    //                 }
    //             },
    //             Relationships = new FolderPayloadDataRelationships()
    //             {
    //                 Parent = new FolderPayloadDataRelationshipsParent()
    //                 {
    //                     Data = new FolderPayloadDataRelationshipsParentData()
    //                     {
    //                         Type = Type.Folders,
    //                         Id = folderId
    //                     }
    //                 }
    //             }
    //         },
    //     };

    //     Folder folder = await _DataManagement.CreateFolderAsync(projectId: projectId, folderPayload: folderPayload, accessToken: token);
    //     FolderData folderData = folder.Data;
    //     Assert.IsTrue(folderData.Type == "folders");
    // }

    // [TestMethod]
    // public async Task TestCreateFolderRelationshipsRefAsync()
    // {
    //     RelationshipRefsPayload relationshipRefsPayload = new RelationshipRefsPayload()
    //     {
    //         Jsonapi = new ModifyFolderPayloadJsonapi()
    //         {
    //             _Version = VersionNumber._10
    //         },
    //         Data = new RelationshipRefsPayloadData()
    //         {
    //             Type = Type.Versions,
    //             Id = versionId,
    //             Meta = new RelationshipRefsPayloadDataMeta()
    //             {
    //                 Extension = new RelationshipRefsPayloadDataMetaExtension()
    //                 {
    //                     Type = Type.AuxiliaryautodeskCoreAttachment,
    //                     _Version = VersionNumber._10
    //                 }
    //             }
    //         }
    //     };

    //     HttpResponseMessage relationship = await _DataManagement.CreateFolderRelationshipsRefAsync(folderId: folderId, projectId: projectId, relationshipRefsPayload: relationshipRefsPayload, accessToken: token);
    //     var statusCode = relationship.StatusCode;
    //     string statusCodeString = statusCode.ToString();
    //     Assert.IsTrue(statusCodeString == "NoContent");
    // }

    // [TestMethod]
    // public async Task TestPatchFolderAsync()
    // {
    //     ModifyFolderPayload modifyFolderPayload = new ModifyFolderPayload()
    //     {
    //         Jsonapi = new ModifyFolderPayloadJsonapi()
    //         {
    //             _Version = VersionNumber._10
    //         },
    //         Data = new ModifyFolderPayloadData()
    //         {
    //             Type = Type.Folders,
    //             Id = folderId,
    //             Attributes = new ModifyFolderPayloadDataAttributes()
    //             {
    //                 Name = "Drawings"
    //             }
    //         }
    //     };

    //     Folder folder = await _DataManagement.PatchFolderAsync(projectId: projectId, folderId: folderId, modifyFolderPayload: modifyFolderPayload, accessToken: token);
    //     FolderData folderData = folder.Data;
    //     Assert.IsTrue(folderId == folderData.Id);
    // }

    [TestMethod]
    public async Task TestGetItemAsync()
    {
       Item item = await _DataManagement.GetItemAsync(projectId: projectId, itemId: itemId, accessToken: token, includePathInProject: true);
       
       Assert.IsTrue(item?.Data?.Type == TypeItem.Items);
    }

   // [TestMethod]
   // public async Task TestGetItemParentFolderAsync()
   // {
   //     Folder folder = await _DataManagement.GetItemParentFolderAsync(projectId: projectId, itemId: itemId, accessToken: token);
   //     FolderData folderData = folder.Data;
   //     Assert.IsTrue(folderData.Type == Type.Folders);
   // }

   // [TestMethod]
   // public async Task TestGetItemRefsAsync()
   // {
   //     Refs refs = await _DataManagement.GetItemRefsAsync(projectId: projectId, itemId: itemId, accessToken: token);
   //     Assert.IsInstanceOfType(refs.Data, typeof(List<RefsData>));
   // }

   // [TestMethod]
   // public async Task TestGetItemRelationshipsLinksAsync()
   // {
   //     RelationshipLinks relationshipLinks = await _DataManagement.GetItemRelationshipsLinksAsync(projectId: projectId, itemId: itemId, accessToken: token);
   //     Assert.IsInstanceOfType(relationshipLinks.Data, typeof(List<RelationshipLinksData>));
   // }

   // [TestMethod]
   // public async Task TestGetItemRelationshipsRefsAsync()
   // {
   //     RelationshipRefs relationshipRefs = await _DataManagement.GetItemRelationshipsRefsAsync(projectId: projectId, itemId: itemId, accessToken: token);
   //     Assert.IsInstanceOfType(relationshipRefs.Data, typeof(List<RelationshipRefsData>));
   // }

   // [TestMethod]
   // public async Task TestGetItemTipAsync()
   // {
   //     ItemTip itemTip = await _DataManagement.GetItemTipAsync(projectId: projectId, itemId: itemId, accessToken: token);
   //     VersionData itemTipData = itemTip.Data;
   //     Assert.IsTrue(itemTipData.Type == Type.Versions);
   // }

   // [TestMethod]
   // public async Task TestGetItemVersionsAsync()
   // {
   //     Versions versions = await _DataManagement.GetItemVersionsAsync(projectId: projectId, itemId: itemId, accessToken: token);
   //     Assert.IsInstanceOfType(versions.Data, typeof(List<VersionData>));
   // }

   // [TestMethod]
   // public async Task TestCreateItemAsync()
   // {

   //     ItemPayload itemPayload = new ItemPayload()
   //     {
   //         Jsonapi = new ModifyFolderPayloadJsonapi()
   //         {
   //             _Version = VersionNumber._10
   //         },
   //         Data = new ItemPayloadData()
   //         {
   //             Type = Type.Items,
   //             Attributes = new ItemPayloadDataAttributes()
   //             {
   //                 DisplayName = "drawing.dwg",
   //                 Extension = new ItemPayloadDataAttributesExtension()
   //                 {
   //                     Type = Type.ItemsautodeskCoreFile,
   //                     _Version = VersionNumber._10
   //                 }
   //             },
   //             Relationships = new ItemPayloadDataRelationships()
   //             {
   //                 Tip = new FolderPayloadDataRelationshipsParent()
   //                 {
   //                     Data = new FolderPayloadDataRelationshipsParentData()
   //                     {
   //                         Type = Type.Versions,
   //                         Id = "1"
   //                     }
   //                 },
   //                 Parent = new FolderPayloadDataRelationshipsParent()
   //                 {
   //                     Data = new FolderPayloadDataRelationshipsParentData()
   //                     {
   //                         Type = Type.Versions,
   //                         Id = "1"
   //                     }
   //                 }
   //             }
   //         },
   //         Included = new List<ItemPayloadIncluded>()
   //         {
   //             new ItemPayloadIncluded()
   //             {
   //                 Type = Type.Versions,
   //                 Id = "1",
   //                 Attributes = new ItemPayloadIncludedAttributes()
   //                 {
   //                     Name = "drawing.dwg",
   //                     Extension = new ItemPayloadDataAttributesExtension()
   //                     {
   //                         Type = Type.VersionsautodeskCoreFile,
   //                         _Version = VersionNumber._10
   //                     }
   //                 }
   //             }
   //         }
   //     };


   //     Item item = await _DataManagement.CreateItemAsync(projectId: projectId, itemPayload: itemPayload, accessToken: token);
   //     ItemData itemData = item.Data;
   //     Assert.IsTrue(itemData.Type == "items");
   // }

   // [TestMethod]
   // public async Task TestCreateItemRelationshipsRefAsync()
   // {
   //     RelationshipRefsPayload relationshipRefsPayload = new RelationshipRefsPayload()
   //     {
   //         Jsonapi = new ModifyFolderPayloadJsonapi()
   //         {
   //             _Version = VersionNumber._10
   //         },
   //         Data = new RelationshipRefsPayloadData()
   //         {
   //             Type = Type.Versions,
   //             Id = "urn:adsk.wipprod:fs.file:vf.ooWjwAQJR0uEoPRyfEnvew?version=1",
   //             Meta = new RelationshipRefsPayloadDataMeta()
   //             {
   //                 Extension = new RelationshipRefsPayloadDataMetaExtension()
   //                 {
   //                     Type = Type.AuxiliaryautodeskCoreAttachment,
   //                     _Version = VersionNumber._10
   //                 }
   //             }
   //         }
   //     };

   //     HttpResponseMessage responseMessage = await _DataManagement.CreateItemRelationshipsRefAsync(projectId: projectId, itemId: itemId, relationshipRefsPayload: relationshipRefsPayload, accessToken: token);
   //     var statusCode = responseMessage.StatusCode;
   //     string statusCodeString = statusCode.ToString();
   //     Assert.IsTrue(statusCodeString == "NoContent");
   // }

   // [TestMethod]
   // public async Task TestPatchItemAsync()
   // {
   //     ModifyItemPayload modifyItemPayload = new ModifyItemPayload()
   //     {
   //         Jsonapi = new ModifyFolderPayloadJsonapi()
   //         {
   //             _Version = VersionNumber._10
   //         },
   //         Data = new ModifyItemPayloadData()
   //         {
   //             Type = Type.Items,
   //             Id = "urn:adsk.wipprod:dm.lineage:AeYgDtcTSuqYoyMweWFhhQ",
   //             Attributes = new ModifyItemPayloadDataAttributes()
   //             {
   //                 DisplayName = "drawing.dwg"
   //             }
   //         }
   //     };

   //     Item item = await _DataManagement.PatchItemAsync(projectId: projectId, itemId: itemId, modifyItemPayload: modifyItemPayload, accessToken: token);
   //     ItemData itemData = item.Data;
   //     Assert.IsTrue(itemData.Type == "items");
   // }

   [TestMethod]
    public async Task TestGetVersionAsync()
    {
        ModelVersion versionDetails = await _DataManagement.GetVersionAsync(projectId: projectId, versionId: versionId, accessToken: token);
        VersionData versionDetailsData = versionDetails.Data;
        Assert.IsTrue(versionDetailsData.Type == TypeVersion.Versions);
    }

    [TestMethod]
    public async Task TestGetVersionDownloadFormatsAsync()
    {
        DownloadFormats downloadFormats = await _DataManagement.GetVersionDownloadFormatsAsync(projectId: projectId, versionId: versionId, accessToken: token);
        DownloadFormatsData downloadFormatsData = downloadFormats.Data;
        Assert.IsTrue(downloadFormatsData.Type == TypeDownloadformats.DownloadFormats);
    }

    // [TestMethod]
    // public async Task TestGetVersionDownloadsAsync()
    // {
    //     Downloads downloads = await _DataManagement.GetVersionDownloadsAsync(projectId: projectId, versionId: versionId, accessToken: token);
    //     Assert.IsInstanceOfType(downloads.Data, typeof(List<DownloadData>));
    // }

    [TestMethod]
    public async Task TestGetVersionItemAsync()
    {
        Item item = await _DataManagement.GetVersionItemAsync(projectId: projectId, versionId: versionId, accessToken: token);
        ItemData itemData = item.Data;
        Assert.IsTrue(itemData.Type == TypeItem.Items);
    }

    [TestMethod]
    public async Task TestGetVersionRefsAsync()
    {
        Refs refs = await _DataManagement.GetVersionRefsAsync(projectId: projectId, versionId: versionId, accessToken: token);
        Assert.IsInstanceOfType(refs.Data, typeof(List<IRefsData>));
    }

    // [TestMethod]
    // public async Task TestGetVersionRelationshipsLinksAsync()
    // {
    //     RelationshipLinks relationshipLinks = await _DataManagement.GetVersionRelationshipsLinksAsync(projectId: projectId, versionId: versionId, accessToken: token);
    //     Assert.IsInstanceOfType(relationshipLinks.Data, typeof(List<RelationshipLinksData>));
    // }

    [TestMethod]
    public async Task TestGetVersionRelationshipsRefsAsync()
    {
        RelationshipRefs relationshipRefs = await _DataManagement.GetVersionRelationshipsRefsAsync(projectId: projectId, versionId: versionId, accessToken: token);
        Assert.IsInstanceOfType(relationshipRefs.Data, typeof(List<RelationshipRefsData>));
    }

    // [TestMethod]
    // public async Task TestCreateVersionAsync()
    // {
    //     VersionPayload versionPayload = new VersionPayload()
    //     {
    //         Jsonapi = new ModifyFolderPayloadJsonapi()
    //         {
    //             _Version = VersionNumber._10
    //         },
    //         Data = new VersionPayloadData()
    //         {
    //             Type = Type.Items,
    //             Attributes = new VersionPayloadDataAttributes()
    //             {
    //                 Name = "drawing.dwg",
    //                 Extension = new RelationshipRefsPayloadDataMetaExtension()
    //                 {
    //                     Type = Type.VersionsautodeskCoreFile,
    //                     _Version = VersionNumber._10
    //                 }
    //             },
    //             Relationships = new VersionPayloadDataRelationships()
    //             {
    //                 Item = new FolderPayloadDataRelationshipsParent()
    //                 {
    //                     Data = new FolderPayloadDataRelationshipsParentData()
    //                     {
    //                         Type = Type.Items,
    //                         Id = "urn:adsk.wipprod:dm.lineage:AeYgDtcTSuqYoyMweWFhhQ"
    //                     }
    //                 },
    //                 Storage = new FolderPayloadDataRelationshipsParent()
    //                 {
    //                     Data = new FolderPayloadDataRelationshipsParentData()
    //                     {
    //                         Type = Type.Objects,
    //                         Id = "urn:adsk.objects:os.object:wip.dm.prod/980cff2c-f0f8-43d9-a151-4a2d916b91a2.dwg"
    //                     }
    //                 }
    //             }
    //         }
    //     };

    //     ModelVersion modelVersion = await _DataManagement.CreateVersionAsync(projectId: projectId, versionPayload: versionPayload, accessToken: token);
    //     VersionData modelVersionData = modelVersion.Data;
    //     Assert.IsTrue(modelVersionData.Type == "versions");
    // }

    // [TestMethod]
    // public async Task TestCreateVersionRelationshipsRefAsync()
    // {
    //     RelationshipRefsPayload relationshipRefsPayload = new RelationshipRefsPayload()
    //     {
    //         Jsonapi = new ModifyFolderPayloadJsonapi()
    //         {
    //             _Version = VersionNumber._10
    //         },
    //         Data = new RelationshipRefsPayloadData()
    //         {
    //             Type = Type.Versions,
    //             Id = "urn:adsk.wipprod:fs.file:vf.ooWjwAQJR0uEoPRyfEnvew?version=1",
    //             Meta = new RelationshipRefsPayloadDataMeta()
    //             {
    //                 Extension = new RelationshipRefsPayloadDataMetaExtension()
    //                 {
    //                     Type = Type.AuxiliaryautodeskCoreAttachment,
    //                     _Version = VersionNumber._10
    //                 }
    //             }
    //         }
    //     };

    //     HttpResponseMessage responseMessage = await _DataManagement.CreateVersionRelationshipsRefAsync(projectId: projectId, versionId: versionId, relationshipRefsPayload: relationshipRefsPayload, accessToken: token);
    //     var statusCode = responseMessage.StatusCode;
    //     string statusCodeString = statusCode.ToString();
    //     Assert.IsTrue(statusCodeString == "NoContent");
    // }

    // [TestMethod]
    // public async Task TestPatchVersionAsync()
    // {
    //     ModifyVersionPayload modifyVersionPayload = new ModifyVersionPayload()
    //     {
    //         Jsonapi = new JsonApiVersion()
    //         {
    //             VarVersion = VersionNumber._10
    //         },
    //         Data = new ModifyVersionPayloadData()
    //         {
    //             Type = Type.Versions,
    //             Id = "urn:adsk.wipprod:fs.file:vf.ooWjwAQJR0uEoPRyfEnvew?version=3",
    //             Attributes = new ModifyVersionPayloadDataAttributes()
    //             {
    //                 Name = "rawing.dwg"
    //             }
    //         }
    //     };

    //     VersionDetails versionDetails = await _DataManagement.PatchVersionAsync(projectId: projectId, versionId: versionId, modifyVersionPayload: modifyVersionPayload, accessToken: token);
    //     VersionData versionDetailsData = versionDetails.Data;
    //     Assert.IsTrue(versionDetailsData.Type == Type.Versions);
    // }



}
