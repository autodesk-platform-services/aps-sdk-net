using Autodesk.Forge.Core;
using Autodesk.DataManagement;
using Autodesk.DataManagement.Http;
using Autodesk.DataManagement.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.SDKManager;
using Type = Autodesk.DataManagement.Model.Type;

namespace Autodesk.DataManagement.Test;


[TestClass]
public class TestDataManagement
{
    private static DataManagementClient _dataManagementApi = null!;

    string token = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
    string hubId = Environment.GetEnvironmentVariable("HUB_ID");
    string projectId = Environment.GetEnvironmentVariable("PROJECT_ID");
    string downloadId = Environment.GetEnvironmentVariable("DOWNLOAD_ID");
    string jobId = Environment.GetEnvironmentVariable("JOB_ID");
    string folderId = Environment.GetEnvironmentVariable("FOLDER_ID");
    string itemId = Environment.GetEnvironmentVariable("ITEM_ID");
    string versionId = Environment.GetEnvironmentVariable("VERSION_ID");

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
        Download download = await _dataManagementApi.GetDownloadAsync(projectId: projectId, downloadId: downloadId, accessToken: token);
        CreatedDownloadData downloadData = download.Data;
        Assert.IsTrue(downloadId == downloadData.Id);
    }

    [TestMethod]
    public async Task TestGetDownloadJobAsync()
    {
        Job job = await _dataManagementApi.GetDownloadJobAsync(projectId: projectId, jobId: jobId, accessToken: token);
        CreatedDownloadData jobData = job.Data;
        Assert.IsTrue(jobId == jobData.Id);
    }

    [TestMethod]
    public async Task TestCreateDownloadAsync()
    {
        CreateDownload createDownload = new CreateDownload();

        createDownload.Jsonapi._Version = VersionNumber._10;

        CreateDownloadData createDownloadData = createDownload.Data;
        createDownloadData.Type = Type.Downloads;

        CreateDownloadDataAttributes attributes = createDownloadData.Attributes;
        CreateDownloadDataAttributesFormat Format = attributes.Format;

        CreateDownloadDataRelationships relationships = createDownloadData.Relationships;
        StorageRequestDataRelationshipsTarget source = relationships.Source;
        StorageRequestDataRelationshipsTargetData storageData = source.Data;
        storageData.Type = Type.Versions;
        storageData.Id = versionId;

        CreatedDownload createdDownload = await _dataManagementApi.CreateDownloadAsync(projectId: projectId, createDownload: createDownload, accessToken: token);
        CreatedDownloadData createdDownloadData = createdDownload.Data;
        Assert.IsTrue(createdDownloadData.Type == "jobs");

    }

    [TestMethod]
    public async Task TestCreateStorageAsync()
    {
        StorageRequest storageRequest = new StorageRequest();

        storageRequest.Jsonapi._Version = VersionNumber._10;

        StorageRequestData storageData = storageRequest.Data;
        storageData.Type = Type.Objects;

        StorageRequestDataAttributes attributes = storageData.Attributes;
        attributes.Name = "drawing.dwg";

        StorageRequestDataRelationships relationships = storageData.Relationships;
        StorageRequestDataRelationshipsTarget target = relationships.Target;
        StorageRequestDataRelationshipsTargetData targetData = target.Data;
        targetData.Type = Type.Folders;
        targetData.Id = "urn:adsk.wipprod:fs.folder:co.mgS-lb-BThaTdHnhiN_mbA";

        Storage createdStorage = await _dataManagementApi.CreateStorageAsync(projectId: projectId, storageRequest: storageRequest, accessToken: token);
        StorageData createdStorageData = createdStorage.Data;
        Assert.IsTrue(createdStorageData.Type == "objects");
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
        FolderContents folderContents = await _dataManagementApi.GetFolderContentsAsync(projectId: projectId, folderId: folderId, accessToken: token);
        Assert.IsTrue(folderContents.Data.Count > 0);
    }

    [TestMethod]
    public async Task TestGetFolderParentAsync()
    {
        Folder folder = await _dataManagementApi.GetFolderParentAsync(projectId: projectId, folderId: folderId, accessToken: token);
        FolderData folderData = folder.Data;
        Assert.IsTrue(folderData.Type == "folders");
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
        CreateFolder createFolder = new CreateFolder();

        createFolder.Jsonapi._Version = VersionNumber._10;

        CreateFolderData folderData = createFolder.Data;
        folderData.Type = Type.Folders;

        CreateFolderDataAttributes attributes = folderData.Attributes;
        attributes.Name = "folder";

        CreateFolderDataAttributesExtension attributesExtension = attributes.Extension;
        attributesExtension.Type = Type.FoldersautodeskCoreFolder;
        attributesExtension._Version = VersionNumber._10;

        CreateFolderDataRelationships relationship = folderData.Relationships;
        StorageRequestDataRelationshipsTarget target = relationship.Parent;
        StorageRequestDataRelationshipsTargetData targetData = target.Data;
        targetData.Type = Type.Folders;
        targetData.Id = folderId;

        Folder folder = await _dataManagementApi.CreateFolderAsync(projectId: projectId, createFolder: createFolder, accessToken: token);
        FolderData createdFolderData = folder.Data;
        Assert.IsTrue(createdFolderData.Type == "folders");
    }

    [TestMethod]
    public async Task TestCreateFolderRelationshipsRefAsync()
    {
        RelationshipRefsRequest relationshipRefsRequest = new RelationshipRefsRequest();

        relationshipRefsRequest.Jsonapi._Version = VersionNumber._10;

        RelationshipRefsRequestData relData = relationshipRefsRequest.Data;
        relData.Type = Type.Versions;
        relData.Id = versionId;

        RelationshipRefsRequestDataMeta relDataMeta = relData.Meta;
        RelationshipRefsRequestDataMetaExtension relDataExtension = relDataMeta.Extension;
        relDataExtension.Type = "auxiliary:autodesk.core:Attachment";
        relDataExtension._Version = VersionNumber._10;

        HttpResponseMessage relationship = await _dataManagementApi.CreateFolderRelationshipsRefAsync(folderId: folderId, projectId: projectId, relationshipRefsRequest: relationshipRefsRequest, accessToken: token);
        var statusCode = relationship.StatusCode;
        string statusCodeString = statusCode.ToString();
        Assert.IsTrue(statusCodeString == "NoContent");
    }

    [TestMethod]
    public async Task TestPatchFolderAsync()
    {
        ModifyFolder modifyFolder = new ModifyFolder();

        modifyFolder.Jsonapi._Version = VersionNumber._10;

        ModifyFolderData modifyFolderData = modifyFolder.Data;
        modifyFolderData.Type = Type.Folders;
        modifyFolderData.Id = folderId;

        ModifyFolderDataAttributes attributes = modifyFolderData.Attributes;
        attributes.Name = "Drawings";

        Folder folder = await _dataManagementApi.PatchFolderAsync(projectId: projectId, folderId: folderId, modifyFolder: modifyFolder, accessToken: token);
        FolderData folderData = folder.Data;
        Assert.IsTrue(folderId == folderData.Id);
    }

    [TestMethod]
    public async Task TestGetItemAsync()
    {
        Item item = await _dataManagementApi.GetItemAsync(projectId: projectId, itemId: itemId, accessToken: token);
        ItemData itemData = item.Data;
        Assert.IsTrue(itemData.Type == "items");
    }

    [TestMethod]
    public async Task TestGetItemParentFolderAsync()
    {
        Folder folder = await _dataManagementApi.GetItemParentFolderAsync(projectId: projectId, itemId: itemId, accessToken: token);
        FolderData folderData = folder.Data;
        Assert.IsTrue(folderData.Type == "folders");
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
        Assert.IsTrue(itemTipData.Type == "versions");
    }

    // [TestMethod]
    // public async Task TestGetItemVersionsAsync()
    // {
    //     Versions versions = await _dataManagementApi.GetItemVersionsAsync(projectId: projectId, itemId: itemId, accessToken: token);
    //     Assert.IsInstanceOfType(versions.Data, typeof(List<VersionsData>));
    // }

    [TestMethod]
    public async Task TestCreateItemAsync()
    {
        CreateItem createItem = new CreateItem();

        createItem.Jsonapi._Version = VersionNumber._10;

        CreateItemData createItemData = createItem.Data;
        createItemData.Type = Type.Items;

        CreateItemDataAttributes attributes = createItemData.Attributes;
        attributes.DisplayName = "drawing.dwg";

        CreateItemDataAttributesExtension extension = attributes.Extension;
        extension.Type = Type.ItemsautodeskCoreFile;
        extension._Version = VersionNumber._10;

        CreateItemDataRelationships relationships = createItemData.Relationships;
        StorageRequestDataRelationshipsTarget tip = relationships.Tip;
        StorageRequestDataRelationshipsTargetData tipData = tip.Data;
        tipData.Type = Type.Versions;
        tipData.Id = "1";

        StorageRequestDataRelationshipsTarget parent = relationships.Parent;
        StorageRequestDataRelationshipsTargetData parentData = parent.Data;
        parentData.Type = Type.Versions;
        parentData.Id = "1";

        List<CreateItemIncluded> included = createItem.Included;

        foreach (var includedData in included)
        {
            includedData.Type = Type.Versions;
            includedData.Id = "1";

            CreateItemIncludedAttributes includedAttributes = includedData.Attributes;
            includedAttributes.Name = "drawing.dwg";

            CreateItemDataAttributesExtension includedExtension = includedAttributes.Extension;
            includedExtension.Type = Type.VersionsautodeskCoreFile;
            includedExtension._Version = VersionNumber._10;
        }

        Item item = await _dataManagementApi.CreateItemAsync(projectId: projectId, createItem: createItem, accessToken: token);
        ItemData itemData = item.Data;
        Assert.IsTrue(itemData.Type == "items");
    }

    [TestMethod]
    public async Task TestCreateItemRelationshipsRefAsync()
    {
        RelationshipRefsRequest relationshipRefsRequest = new RelationshipRefsRequest();

        relationshipRefsRequest.Jsonapi._Version = VersionNumber._10;

        RelationshipRefsRequestData relationshipRefsRequestData = relationshipRefsRequest.Data;
        relationshipRefsRequestData.Type = Type.Versions;
        relationshipRefsRequestData.Id = "urn:adsk.wipprod:fs.file:vf.ooWjwAQJR0uEoPRyfEnvew?version=1";

        RelationshipRefsRequestDataMeta meta = relationshipRefsRequestData.Meta;
        RelationshipRefsRequestDataMetaExtension extension = meta.Extension;
        extension.Type = "auxiliary:autodesk.core:Attachment";
        extension._Version = VersionNumber._10;

        HttpResponseMessage responseMessage = await _dataManagementApi.CreateItemRelationshipsRefAsync(projectId: projectId, itemId: itemId, relationshipRefsRequest: relationshipRefsRequest, accessToken: token);
        var statusCode = responseMessage.StatusCode;
        string statusCodeString = statusCode.ToString();
        Assert.IsTrue(statusCodeString == "NoContent");
    }

    [TestMethod]
    public async Task TestPatchItemAsync()
    {
        ItemRequest itemRequest = new ItemRequest();

        itemRequest.Jsonapi._Version = VersionNumber._10;

        ItemRequestData itemRequestData = itemRequest.Data;
        itemRequestData.Type = Type.Items;
        itemRequestData.Id = "urn:adsk.wipprod:dm.lineage:AeYgDtcTSuqYoyMweWFhhQ";

        ItemRequestDataAttributes attributes = itemRequestData.Attributes;
        attributes.DisplayName = "drawing.dwg";

        Item item = await _dataManagementApi.PatchItemAsync(projectId: projectId, itemId: itemId, itemRequest: itemRequest, accessToken: token);
        ItemData itemData = item.Data;
        Assert.IsTrue(itemData.Type == "items");
    }

    [TestMethod]
    public async Task TestGetVersionAsync()
    {
        ModelVersion modelVersion = await _dataManagementApi.GetVersionAsync(projectId: projectId, versionId: versionId, accessToken: token);
        ItemTipData modelVersionData = modelVersion.Data;
        Assert.IsTrue(modelVersionData.Type == "versions");
    }

    [TestMethod]
    public async Task TestGetVersionDownloadFormatsAsync()
    {
        DownloadFormats downloadFormats = await _dataManagementApi.GetVersionDownloadFormatsAsync(projectId: projectId, versionId: versionId, accessToken: token);
        DownloadFormatsData downloadFormatsData = downloadFormats.Data;
        Assert.IsTrue(downloadFormatsData.Type == "downloadFormats");
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
        Assert.IsTrue(itemData.Type == "items");
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
        CreateVersion createVersion = new CreateVersion();

        createVersion.Jsonapi._Version = VersionNumber._10;

        CreateVersionData createVersionData = createVersion.Data;
        createVersionData.Type = Type.Items;

        CreateVersionDataAttributes attributes = createVersionData.Attributes;
        attributes.Name = "drawing.dwg";

        CreateVersionDataAttributesExtension extension = attributes.Extension;
        extension.Type = "versions:autodesk.core:File";
        extension._Version = "1.0";

        CreateVersionDataRelationships relationships = createVersionData.Relationships;
        StorageRequestDataRelationshipsTarget item = relationships.Item;
        StorageRequestDataRelationshipsTargetData itemData = item.Data;
        itemData.Type = Type.Items;
        itemData.Id = "urn:adsk.wipprod:dm.lineage:AeYgDtcTSuqYoyMweWFhhQ";

        StorageRequestDataRelationshipsTarget storage = relationships.Storage;
        StorageRequestDataRelationshipsTargetData storageData = storage.Data;
        storageData.Type = Type.Objects;
        storageData.Id = "urn:adsk.objects:os.object:wip.dm.prod/980cff2c-f0f8-43d9-a151-4a2d916b91a2.dwg";

        CreatedVersion createdVersion = await _dataManagementApi.CreateVersionAsync(projectId: projectId, createVersion: createVersion, accessToken: token);
        CreatedVersionData createdVersionData = createdVersion.Data;
        Assert.IsTrue(createdVersionData.Type == "versions");
    }

    [TestMethod]
    public async Task TestCreateVersionRelationshipsRefAsync()
    {
        RelationshipRefsRequest relationshipRefsRequest = new RelationshipRefsRequest();

        relationshipRefsRequest.Jsonapi._Version = VersionNumber._10;

        RelationshipRefsRequestData relationshipRefsRequestData = relationshipRefsRequest.Data;
        relationshipRefsRequestData.Type = Type.Versions;
        relationshipRefsRequestData.Id = "urn:adsk.wipprod:fs.file:vf.ooWjwAQJR0uEoPRyfEnvew?version=1";

        RelationshipRefsRequestDataMeta meta = relationshipRefsRequestData.Meta;
        RelationshipRefsRequestDataMetaExtension extension = meta.Extension;
        extension.Type = "auxiliary:autodesk.core:Attachment";
        extension._Version = VersionNumber._10;

        HttpResponseMessage responseMessage = await _dataManagementApi.CreateVersionRelationshipsRefAsync(projectId: projectId, versionId: versionId, relationshipRefsRequest: relationshipRefsRequest, accessToken: token);
        var statusCode = responseMessage.StatusCode;
        string statusCodeString = statusCode.ToString();
        Assert.IsTrue(statusCodeString == "NoContent");
    }

    [TestMethod]
    public async Task TestPatchVersionAsync()
    {
        VersionRequest versionRequest = new VersionRequest();

        versionRequest.Jsonapi._Version = VersionNumber._10;

        VersionRequestData versionRequestData = versionRequest.Data;
        versionRequestData.Type = Type.Items;
        versionRequestData.Id = "urn:adsk.wipprod:fs.file:vf.ooWjwAQJR0uEoPRyfEnvew?version=1";

        VersionRequestDataAttributes attributes = versionRequestData.Attributes;
        attributes.Name = "new name for drawing.dwg";

        ModelVersion modelVersion = await _dataManagementApi.PatchVersionAsync(projectId: projectId, versionId: versionId, versionRequest: versionRequest, accessToken: token);
        ItemTipData modelVersionData = modelVersion.Data;
        Assert.IsTrue(modelVersionData.Type == "versions");
    }



}
