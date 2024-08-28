using Autodesk.DataManagement;
using Autodesk.DataManagement.Http;
using Autodesk.DataManagement.Model;
using Autodesk.SDKManager;
using Type = Autodesk.DataManagement.Model.Type;

class DataManagement
{
    string token = Environment.GetEnvironmentVariable("TOKEN") ?? "";
    string folder_id = Environment.GetEnvironmentVariable("FOLDER_ID") ?? "";
    string project_top_folder_one_id = Environment.GetEnvironmentVariable("PROJECT_TOP_FOLDER_ONE_ID") ?? "";
    string project_top_folder_two_id = Environment.GetEnvironmentVariable("PROJECT_TOP_FOLDER_TWO_ID") ?? "";
    string hub_id = Environment.GetEnvironmentVariable("HUB_ID") ?? "";
    string project_id = Environment.GetEnvironmentVariable("PROJECT_ID") ?? "";
    string download_id = Environment.GetEnvironmentVariable("DOWNLOAD_ID") ?? "";
    string job_id = Environment.GetEnvironmentVariable("JOB_ID") ?? "";
    string item_id = Environment.GetEnvironmentVariable("ITEM_ID") ?? "";
    string version_id = Environment.GetEnvironmentVariable("VERSION_ID") ?? "";
    string file_type = Environment.GetEnvironmentVariable("FILE_TYPE") ?? "rvt";
    string object_name = Environment.GetEnvironmentVariable("OBJECT_NAME") ?? "";
    string new_folder_name = Environment.GetEnvironmentVariable("NEW_FOLDER_NAME") ?? "";
    string modified_folder_name = Environment.GetEnvironmentVariable("MODIFIED_FOLDER_NAME") ?? "";
    string item_display_name = Environment.GetEnvironmentVariable("ITEM_DISPLAY_NAME") ?? "";

    string object_id = Environment.GetEnvironmentVariable("OBJECT_ID") ?? "";
    DataManagementClient dataManagementClient = null!;

    public void Initialise()
    {
        // Instantiate SDK manager as below.  
        SDKManager sdkManager = SdkManagerBuilder
            .Create() // Creates SDK Manager Builder itself.
            .Build();

        // Instantiate DataManagement using the created SDK manager
        dataManagementClient = new DataManagementClient(sdkManager);
    }


    #region hubs
    public async Task GetHubsAsync()
    {
        Hubs hubs = await dataManagementClient.GetHubsAsync(accessToken: token);

        List<HubData> hubsData = hubs.Data;
        foreach (var hub in hubsData)
        {
            Type hubsType = hub.Type;
            string HubsId = hub.Id;

            Console.WriteLine(hubsType);
            Console.WriteLine(HubsId);
        }
    }

    public async Task GetHubAsync()
    {
        Hub hub = await dataManagementClient.GetHubAsync(hubId: hub_id, accessToken: token);

        HubData hubData = hub.Data;
        Type hubType = hubData.Type;
        string hubId = hubData.Id;

        Console.WriteLine(hubType);
        Console.WriteLine(hubId);
    }

    #endregion hubs


    #region projects

    public async Task GetHubProjectsAsync()
    {
        Projects projects = await dataManagementClient.GetHubProjectsAsync(hubId: hub_id, accessToken: token);

        List<ProjectData> projectsData = projects.Data;
        foreach (var project in projectsData)
        {
            Type hubProjectsType = project.Type;
            string hubProjectsId = project.Id;

            Console.WriteLine(hubProjectsType);
            Console.WriteLine(hubProjectsId);
        }
    }

    public async Task GetProjectAsync()
    {
        Project project = await dataManagementClient.GetProjectAsync(hubId: hub_id, projectId: project_id, accessToken: token);

        ProjectData projectData = project.Data;
        Type hubProjectDataType = projectData.Type;
        string hubProjectDataId = projectData.Id;

        Console.WriteLine(hubProjectDataType);
        Console.WriteLine(hubProjectDataId);
    }

    public async Task GetProjectHubAsync()
    {
        Hub hub = await dataManagementClient.GetProjectHubAsync(hubId: hub_id, projectId: project_id, accessToken: token);

        HubData hubData = hub.Data;
        Type hubType = hubData.Type;
        string hubId = hubData.Id;

        Console.WriteLine(hubType);
        Console.WriteLine(hubId);
    }

    public async Task GetProjectTopFoldersAsync()
    {
        TopFolders topFolders = await dataManagementClient.GetProjectTopFoldersAsync(hubId: hub_id, projectId: project_id, accessToken: token);

        List<TopFolderData> topFolderData = topFolders.Data;
        foreach (var topFolder in topFolderData)
        {
            Type folderType = topFolder.Type;
            string folderId = topFolder.Id;

            Console.WriteLine(folderType);
            Console.WriteLine(folderId);
        }
    }

    public async Task GetDownloadAsync()
    {
        Download download = await dataManagementClient.GetDownloadAsync(projectId: project_id, downloadId: download_id, accessToken: token);

        DownloadData downloadData = download.Data;
        Type downloadType = downloadData.Type;
        string downloadId = downloadData.Id;

        Console.WriteLine(downloadType);
        Console.WriteLine(downloadId);
    }

    public async Task GetDownloadJobAsync()
    {
        Job job = await dataManagementClient.GetDownloadJobAsync(projectId: project_id, jobId: job_id, accessToken: token);

        JobData jobData = job.Data;
        Type jobDataType = jobData.Type;
        string jobDataId = jobData.Id;

        Console.WriteLine(jobDataType);
        Console.WriteLine(jobDataId);
    }

    public async Task StartDownloadAsync()
    {
        DownloadPayload downloadPayload = new DownloadPayload()
        {
            Jsonapi = new JsonApiVersion()
            {
                VarVersion = VersionNumber._10
            },
            Data = new DownloadPayloadData()
            {
                Type = Type.Downloads,
                Attributes = new DownloadPayloadDataAttributes()
                {
                    Format = new DownloadPayloadDataAttributesFormat()
                    {
                        FileType = file_type;
                    }
                },
                Relationships = new DownloadPayloadDataRelationships()
                {
                    Source = new DownloadPayloadDataRelationshipsSource()
                    {
                        Data = new DownloadPayloadDataRelationshipsSourceData()
                        {
                            Type = Type.Versions,
                            Id = version_id
                        }
                    }
                }
            }
        }

        CreatedDownload createdDownload = await dataManagementClient.StartDownloadAsync(projectId: project_id, downloadPayload: downloadPayload, accessToken: token);

        List<CreatedDownloadData> createdDownloadData = createdDownload.Data;
        foreach (var downloadData in createdDownloadData)
        {
            Type downloadDataType = downloadData.Type;
            string downloadDataId = downloadData.Id;

            Console.WriteLine(downloadDataType);
            Console.WriteLine(downloadDataId);
        }
    }

    public async Task CreateStorageAsync()
    {
        StoragePayload storagePayload = new StoragePayload()
        {
            Jsonapi = new JsonApiVersion()
            {
                VarVersion = VersionNumber._10
            },
            Data = new StoragePayloadData()
            {
                Type = Type.Objects,
                Attributes = new StoragePayloadDataAttributes()
                {
                    Name = object_name,

                },
                Relationships = new StoragePayloadDataRelationships()
                {
                    Target = new StoragePayloadDataRelationshipsTarget()
                    {
                        Data = new StoragePayloadDataRelationshipsTargetData()
                        {
                            Type = Type.Folders,
                            Id = folder_id
                        }
                    }
                }
            }
        }

        Storage storage = await dataManagementClient.CreateStorageAsync(projectId: project_id, storagePayload: storagePayload, accessToken: token: token);

        StorageData storageData = storage.Data;
        Type storageDataType = storageData.Type;
        string storageDataId = storageData.Id;

        Console.WriteLine(storageDataType);
        Console.WriteLine(storageDataId);
    }

    #endregion projects


    #region folders

    public async Task GetFolderAsync()
    {
        Folder folder = await dataManagementClient.GetFolderAsync(projectId: project_id, folderId: folder_id, accessToken: token);

        FolderData folderData = folder.Data;
        Type folderDataType = folderData.Type;
        string folderDataId = folderData.Id;

        Console.WriteLine(folderDataType);
        Console.WriteLine(folderDataId);
    }
    public async Task GetFolderContentsAsync()
    {
        FolderContents folderContents = await dataManagementClient.GetFolderContentsAsync(projectId: project_id, folderId: folder_id, accessToken: token);

        List<FolderContentsData> folderContentsData = folderContents.Data;
        Console.WriteLine(folderContents);
        // foreach (var folderContentData in folderContentsData)
        // {
        //     Type folderContentDataType = folderContentData.Type;
        //     string folderContentDataId = folderContentData.Id;

        //     Console.WriteLine(folderContentDataType);
        //     Console.WriteLine(folderContentDataId);
        // }
    }

    public async Task GetFolderParentAsync()
    {

        Folder folder = await dataManagementClient.GetFolderParentAsync(projectId: project_id, folderId: folder_id, accessToken: token);

        FolderData folderData = folder.Data;
        Type folderDataType = folderData.Type;
        string folderDataId = folderData.Id;

        Console.WriteLine(folderDataType);
        Console.WriteLine(folderDataId);
    }

    public async Task GetFolderRefsAsync()
    {
        FolderRefs folderRefs = await dataManagementClient.GetFolderRefsAsync(projectId: project_id, folder_id: folder_id, accessToken: token);

        List<FolderRefsData> folderRefsData = folderRefs.Data;
        foreach (var folderRefData in folderRefsData)
        {
            Type folderRefDataType = folderRefData.Type;
            string folderRefDataId = folderRefData.Id;

            Console.WriteLine(folderRefDataType);
            Console.WriteLine(folderRefDataId);
        }
    }

    public async Task GetFolderRelationshipsLinksAsync()
    {
        RelationshipLinks relationshipLinks = await dataManagementClient.GetFolderRelationshipsLinksAsync(projectId: project_id, folderId: folder_id, accessToken: token);

        List<RelationshipLinksData> relationshipLinksData = relationshipLinks.Data;
        foreach (var relationshipLinkData in relationshipLinksData)
        {
            Type relationshipLinkDataType = relationshipLinkData.Type;
            string relationshipLinkDataId = relationshipLinkData.Id;

            Console.WriteLine(relationshipLinkDataType);
            Console.WriteLine(relationshipLinkDataId);
        }
    }

    public async Task GetFolderRelationshipsRefsAsync()
    {
        RelationshipRefs relationshipRefs = await dataManagementClient.GetFolderRelationshipsRefsAsync(folderId: folder_id, projectId: project_id, accessToken: token);

        List<RelationshipRefsData> relationshipRefsData = relationshipRefs.Data;
        foreach (var relationshipRefData in relationshipRefsData)
        {
            Type relationshipRefDataType = relationshipRefData.Type;
            string relationshipRefDataId = relationshipRefData.Id;

            Console.WriteLine(relationshipRefDataType);
            Console.WriteLine(relationshipRefDataId);
        }
    }

    public async Task GetFolderSearchAsync()
    {
        Search search = await dataManagementClient.GetFolderSearchAsync(projectId: project_id, foldeId: folder_id, accessToken: token);

        List<VersionData> searchData = search.Data;
        foreach (var currentSearchData in searchData)
        {
            Type currentSearchDataType = currentSearchData.Type;
            string currentSearchDataId = currentSearchData.Id;

            Console.WriteLine(currentSearchDataType);
            Console.WriteLine(currentSearchDataId);
        }
    }

    public async Task CreateFolderAsync()
    {
        FolderPayload folderPayload = new FolderPayload()
        {
            Jsonapi = new JsonApiVersion()
            {
                VarVersion = VersionNumber._10
            },
            Data = new FolderPayloadData()
            {
                Type = Type.Folders,
                Attributes = new FolderPayloadDataAttributes()
                {
                    Name = new_folder_name,
                    Extension = new FolderPayloadDataAttributesExtension()
                    {
                        Type = Type.FoldersautodeskCoreFolder,
                        VarVersion = VersionNumber._10
                    }
                },
                Relationships = new FolderPayloadDataRelationships()
                {
                    Parent = new FolderPayloadDataRelationshipsParent()
                    {
                        Data = new FolderPayloadDataRelationshipsParentData()
                        {
                            Type = Type.Folders,
                            Id = folder_id
                        }
                    }
                }
            },
        };

        Folder folder = await dataManagementClient.CreateFolderAsync(projectId: project_id, folderPayload: folderPayload, accessToken: token);

        FolderData folderData = folder.Data;
        Type folderDataType = folderData.Type;
        string folderDataId = folderData.Id;

        Console.WriteLine(folderDataType);
        Console.WriteLine(folderDataId);
    }

    public async Task CreateFolderRelationshipsRefAsync()
    {
        RelationshipRefsPayload relationshipRefsPayload = new RelationshipRefsPayload()
        {
            Jsonapi = new JsonApiVersion()
            {
                VarVersion = VersionNumber._10
            },
            Data = new RelationshipRefsPayloadData()
            {
                Type = Type.Versions,
                Id = versionId,
                Meta = new RelationshipRefsPayloadDataMeta()
                {
                    Extension = new BaseAttributesExtensionObjectWithoutSchemaLink()
                    {
                        Type = Type.AuxiliaryautodeskCoreAttachment,
                        VarVersion = VersionNumber._10
                    }
                }
            }
        };

        HttpResponseMessage relationship = await dataManagementClient.CreateFolderRelationshipsRefAsync(folderId: folderId, projectId: projectId, relationshipRefsPayload: relationshipRefsPayload, accessToken: token);
        var statusCode = relationship.StatusCode;
        string statusCodeString = statusCode.ToString();

        Console.WriteLine(statusCodeString);
    }

    public async Task PatchFolderAsync()
    {
        ModifyFolderPayload modifyFolderPayload = new ModifyFolderPayload()
        {
            Jsonapi = new JsonApiVersion()
            {
                VarVersion = VersionNumber._10
            },
            Data = new ModifyFolderPayloadData()
            {
                Type = Type.Folders,
                Id = folderId,
                Attributes = new ModifyFolderPayloadDataAttributes()
                {
                    Name = modified_folder_name
                }
            }
        };

        Folder folder = await dataManagementClient.PatchFolderAsync(projectId: projectId, folderId: folderId, modifyFolderPayload: modifyFolderPayload, accessToken: token);

        FolderData folderData = folder.Data;
        Type folderDataType = folderData.Type;
        string folderDataId = folderData.Id;

        Console.WriteLine(folderDataType);
        Console.WriteLine(folderDataId);
    }

    #endregion folders


    #region items

    public async Task GetItemAsync()
    {
        Item item = await dataManagementClient.GetItemAsync(projectId: projectId, itemId: itemId, accessToken: token);

        ItemData itemData = item.Data;
        Type itemDataType = itemData.Type;
        string itemDataId = itemData.Id;

        Console.WriteLine(itemDataType);
        Console.WriteLine(itemDataId);
    }

    public async Task GetItemParentFolderAsync()
    {
        Folder folder = await dataManagementClient.GetItemParentFolderAsync(projectId: projectId, itemId: itemId, accessToken: token);

        FolderData folderData = folder.Data;
        Type folderDataType = folderData.Type;
        string folderDataId = folderData.Id;

        Console.WriteLine(folderDataType);
        Console.WriteLine(folderDataId);
    }

    public async Task GetItemRefsAsync()
    {
        Refs refs = await dataManagementClient.GetItemRefsAsync(projectId: projectId, itemId: itemId, accessToken: token);

        List<RefsData> refsData = refs.Data;
        foreach (var refData in refsData)
        {
            Type refDataType = refData.Type;
            string refDataId = refData.Id;

            Console.WriteLine(refDataType);
            Console.WriteLine(refDataId);
        }
    }

    public async Task GetItemRelationshipsLinksAsync()
    {
        RelationshipLinks relationshipLinks = await dataManagementClient.GetItemRelationshipsLinksAsync(projectId: projectId, itemId: itemId, accessToken: token);

        List<RelationshipLinksData> relationshipLinksData = relationshipLinks.Data;
        foreach (var relationshipLinkData in relationshipLinksData)
        {
            Type relationshipLinkDataType = relationshipLinkData.Type;
            string relationshipLinkDataId = relationshipLinkData.Id;

            Console.WriteLine(relationshipLinkDataType);
            Console.WriteLine(relationshipLinkDataId);
        }
    }

    public async Task GetItemRelationshipsRefsAsync()
    {
        RelationshipRefs relationshipRefs = await dataManagementClient.GetItemRelationshipsRefsAsync(projectId: projectId, itemId: itemId, accessToken: token);

        List<RelationshipRefsData> relationshipRefsData = relationshipRefs.Data;
        foreach (var relationshipRefData in relationshipRefsData)
        {
            Type relationshipRefDataType = relationshipRefData.Type;
            string relationshipRefDataId = relationshipRefData.Id;

            Console.WriteLine(relationshipRefDataType);
            Console.WriteLine(relationshipRefDataId);
        }
    }

    public async Task GetItemTipAsync()
    {
        ItemTip itemTip = await dataManagementClient.GetItemTipAsync(projectId: projectId, itemId: itemId, accessToken: token);

        VersionData itemTipData = itemTip.Data;
        Type itemTipDataType = itemTipData.Type;
        string itemTipDataId = itemTipData.Id;

        Console.WriteLine(itemTipDataType);
        Console.WriteLine(itemTipDataId);
    }

    public async Task GetItemVersionsAsync()
    {
        Versions versions = await dataManagementClient.GetItemVersionsAsync(projectId: projectId, itemId: itemId, accessToken: token);

        List<VersionData> versionsData = versions.Data;
        foreach (var versionData in versionsData)
        {
            Type versionDataType = versionData.Type;
            string versionDataId = versionData.Id;

            Console.WriteLine(versionDataType);
            Console.WriteLine(versionDataId);
        }
    }

    public async Task CreateItemAsync()
    {
        ItemPayload itemPayload = new ItemPayload()
        {
            Jsonapi = new JsonApiVersion()
            {
                VarVersion = VersionNumber._10
            },
            Data = new ItemPayloadData()
            {
                Type = Type.Items,
                Attributes = new ItemPayloadDataAttributes()
                {
                    DisplayName = item_display_name,
                    Extension = new ItemPayloadDataAttributesExtension()
                    {
                        Type = Type.ItemsautodeskCoreFile,
                        VarVersion = VersionNumber._10
                    }
                },
                Relationships = new ItemPayloadDataRelationships()
                {
                    Tip = new ItemPayloadDataRelationshipsTip()
                    {
                        Data = new ItemPayloadDataRelationshipsTipData()
                        {
                            Type = Type.Versions,
                            Id = "1"
                        }
                    },
                    Parent = new ItemPayloadDataRelationshipsParent()
                    {
                        Data = new ItemPayloadDataRelationshipsParentData()
                        {
                            Type = Type.Folders,
                            Id = folder_id,
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
                        Name = object_name,
                        Extension = new ItemPayloadIncludedAttributesExtension()
                        {
                            Type = Type.VersionsautodeskCoreFile,
                            VarVersion = VersionNumber._10
                        }
                    },
                    Relationships = new ItemPayloadIncludedRelationships()
                    {
                        Storage = new ItemPayloadIncludedRelationshipsStorage()
                        {
                            Data = new ItemPayloadIncludedRelationshipsStorageData()
                            {
                                Type = Type.Objects,
                                Id = object_id
                            }
                        }
                    }
                }
            }
        };

        Item item = await dataManagementClient.CreateItemAsync(projectId: projectId, itemPayload: itemPayload, accessToken: token);

        ItemData itemData = item.Data;
        Type itemDataType = itemData.Type;
        string itemDataId = itemData.Id;

        Console.WriteLine(itemDataType);
        Console.WriteLine(itemDataId);
    }

    public async Task CreateItemRelationshipsRefAsync()
    {
        RelationshipRefsPayload relationshipRefsPayload = new RelationshipRefsPayload()
        {
            Jsonapi = new JsonApiVersion()
            {
                VarVersion = VersionNumber._10
            },
            Data = new RelationshipRefsPayloadData()
            {
                Type = Type.Versions,
                Id = version_id,
                Meta = new RelationshipRefsPayloadDataMeta()
                {
                    Extension = new BaseAttributesExtensionObjectWithoutSchemaLink()
                    {
                        Type = Type.AuxiliaryautodeskCoreAttachment,
                        VarVersion = VersionNumber._10
                    }
                }
            }
        };

        HttpResponseMessage responseMessage = await dataManagementClient.CreateItemRelationshipsRefAsync(projectId: projectId, itemId: itemId, relationshipRefsPayload: relationshipRefsPayload, accessToken: token);
        var statusCode = responseMessage.StatusCode;
        string statusCodeString = statusCode.ToString();

        Console.WriteLine(statusCodeString);
    }

    public async Task PatchItemAsync()
    {
        ModifyItemPayload modifyItemPayload = new ModifyItemPayload()
        {
            Jsonapi = new JsonApiVersion()
            {
                VarVersion = VersionNumber._10
            },
            Data = new ModifyItemPayloadData()
            {
                Type = Type.Items,
                Id = item_id,
                Attributes = new ModifyItemPayloadDataAttributes()
                {
                    DisplayName = object_name
                }
            }
        };

        Item item = await dataManagementClient.PatchItemAsync(projectId: projectId, itemId: itemId, modifyItemPayload: modifyItemPayload, accessToken: token);

        ItemData itemData = item.Data;
        Type itemDataType = itemData.Type;
        string itemDataId = itemData.Id;

        Console.WriteLine(itemDataType);
        Console.WriteLine(itemDataId);
    }

    #endregion items


    #region versions
    public async Task GetVersionAsync()
    {
        VersionDetails versionDetails = await dataManagementClient.GetVersionAsync(projectId: project_id, versionId: version_id, accessToken: token);

        VersionData versionDetailsData = versionDetails.Data;
        Type versionDetailsDataType = versionDetailsData.Type;
        string versionDetailsDataId = versionDetailsData.Id;

        Console.WriteLine(versionDetailsDataType);
        Console.WriteLine(versionDetailsDataId);
    }

    public async Task GetVersionDownloadFormatsAsync()
    {
        DownloadFormats downloadFormats = await dataManagementClient.GetVersionDownloadFormatsAsync(projectId: project_id, versionId: version_id, accessToken: token);

        DownloadFormatsData downloadFormatsData = downloadFormats.Data;
        Type downloadFormatsDataType = downloadFormatsData.Type;
        string downloadFormatsDataId = downloadFormatsData.Id;

        Console.WriteLine(downloadFormatsDataType);
        Console.WriteLine(downloadFormatsDataId);
    }

    public async Task GetVersionDownloadsAsync()
    {
        Downloads downloads = await dataManagementClient.GetVersionDownloadsAsync(projectId: project_id, versionId: version_id, accessToken: token);

        List<DownloadData> downloadsData = downloads.Data;
        foreach (var downloadData in downloadsData)
        {
            Type downloadDataType = downloadData.Type;
            string downloadDataId = downloadData.Id;

            Console.WriteLine(downloadDataType);
            Console.WriteLine(downloadDataId);
        }
    }

    public async Task GetVersionItemAsync()
    {
        Item item = await dataManagementClient.GetVersionItemAsync(projectId: project_id, versionId: version_id, accessToken: token);

        ItemData itemData = item.Data;
        Type itemDataType = itemData.Type;
        string itemDataId = itemData.Id;

        Console.WriteLine(itemDataType);
        Console.WriteLine(itemDataId);
    }

    public async Task GetVersionRefsAsync()
    {
        Refs refs = await dataManagementClient.GetVersionRefsAsync(projectId: project_id, versionId: version_id, accessToken: token);

        List<RefsData> refsData = refs.Data;
        foreach (var refData in refsData)
        {
            Type refDataType = refData.Type;
            string refDataId = refData.Id;

            Console.WriteLine(refDataType);
            Console.WriteLine(refDataId);
        }
    }

    public async Task GetVersionRelationshipsLinksAsync()
    {
        RelationshipLinks relationshipLinks = await dataManagementClient.GetVersionRelationshipsLinksAsync(projectId: project_id, versionId: version_id, accessToken: token);

        List<RelationshipLinksData> relationshipLinksData = relationshipLinks.Data;
        foreach (var relationshipLinkData in relationshipLinksData)
        {
            Type relationshipLinkDataType = relationshipLinkData.Type;
            string relationshipLinkDataId = relationshipLinkData.Id;

            Console.WriteLine(relationshipLinkDataType);
            Console.WriteLine(relationshipLinkDataId);
        }
    }

    public async Task GetVersionRelationshipsRefsAsync()
    {
        RelationshipRefs relationshipRefs = await dataManagementClient.GetVersionRelationshipsRefsAsync(projectId: project_id, versionId: version_id, accessToken: token);

        List<RelationshipRefsData> relationshipRefsData = relationshipRefs.Data;
        foreach (var relationshipRefData in relationshipRefsData)
        {
            Type relationshipRefDataType = relationshipRefData.Type;
            string relationshipRefDataId = relationshipRefData.Id;

            Console.WriteLine(relationshipRefDataType);
            Console.WriteLine(relationshipRefDataId);
        }
    }

    public async Task CreateVersionAsync()
    {
        VersionPayload versionPayload = new VersionPayload()
        {
            Jsonapi = new JsonApiVersion()
            {
                VarVersion = VersionNumber._10
            },
            Data = new VersionPayloadData()
            {
                Type = Type.Items,
                Attributes = new VersionPayloadDataAttributes()
                {
                    Name = object_name,
                    Extension = new VersionPayloadDataAttributesExtension()
                    {
                        Type = Type.VersionsautodeskCoreFile,
                        VarVersion = VersionNumber._10
                    }
                },
                Relationships = new VersionPayloadDataRelationships()
                {
                    Item = new VersionPayloadDataRelationshipsItem()
                    {
                        Data = new VersionPayloadDataRelationshipsItemData()
                        {
                            Type = Type.Items,
                            Id = item_id
                        }
                    },
                    Storage = new VersionPayloadDataRelationshipsStorage()
                    {
                        Data = new VersionPayloadDataRelationshipsStorageData()
                        {
                            Type = Type.Objects,
                            Id = object_id
                        }
                    }
                }
            }
        };

        CreatedVersion createdVersion = await dataManagementClient.CreateVersionAsync(project_id: projectId, versionPayload: versionPayload, accessToken: token);

        CreatedVersionData createdVersionData = createdVersion.Data;
        Type createdVersionDataType = createdVersionData.Type;
        string createdVersionDataId = createdVersionData.Id;

        Console.WriteLine(createdVersionDataType);
        Console.WriteLine(createdVersionDataId);
    }

    public async Task CreateVersionRelationshipsRefAsync()
    {
        RelationshipRefsPayload relationshipRefsPayload = new RelationshipRefsPayload()
        {
            Jsonapi = new JsonApiVersion()
            {
                VarVersion = VersionNumber._10
            },
            Data = new RelationshipRefsPayloadData()
            {
                Type = Type.Versions,
                Id = version_id,
                Meta = new RelationshipRefsPayloadDataMeta()
                {
                    Extension = new BaseAttributesExtensionObjectWithoutSchemaLink()
                    {
                        Type = Type.AuxiliaryautodeskCoreAttachment,
                        VarVersion = VersionNumber._10
                    }
                }
            }
        };

        HttpResponseMessage responseMessage = await dataManagementClient.CreateVersionRelationshipsRefAsync(projectId: project_id, versionId: version_id, relationshipRefsPayload: relationshipRefsPayload, accessToken: token);

        var statusCode = responseMessage.StatusCode;
        string statusCodeString = statusCode.ToString();

        Console.WriteLine(statusCodeString);
    }

    public async Task PatchVersionAsync()
    {
        ModifyVersionPayload modifyVersionPayload = new ModifyVersionPayload()
        {
            Jsonapi = new JsonApiVersion()
            {
                VarVersion = VersionNumber._10
            },
            Data = new ModifyVersionPayloadData()
            {
                Type = Type.Versions,
                Id = version_id,
                Attributes = new ModifyVersionPayloadDataAttributes()
                {
                    Name = object_name
                }
            }
        };

        VersionDetails versionDetails = await dataManagementClient.PatchVersionAsync(projectId: project_id, versionId: version_id, modifyVersionPayload: modifyVersionPayload, accessToken: token);

        VersionData versionDetailsData = versionDetails.Data;
        Type versionDetailsDataType = versionDetailsData.Type;
        string versionDetailsDataId = versionDetailsData.Id;

        Console.WriteLine(versionDetailsDataType);
        Console.WriteLine(versionDetailsDataId);
    }
    #endregion versions

    #region commands

    public async Task ExecuteCheckPermissionCommandAsync()
    {


        CheckPermissionPayload checkPermissionPayload = new CheckPermissionPayload()
        {
            Type = Type.Commands,
            Attributes = new CheckPermissionPayloadAttributes()
            {
                Extension = new CheckPermissionPayloadAttributesExtension()
                {
                    Type = Type.CommandsautodeskCoreCheckPermission,
                    VarVersion = "1.0.0",
                    Data = new CheckPermissionPayloadAttributesExtensionData()
                    {
                        RequiredActions = new List<RequiredActions>
                            {
                               RequiredActions.Download,
                               RequiredActions.View,
                            }
                    }
                }
            },
            Relationships = new CheckPermissionPayloadRelationships()
            {
                Resources = new CheckPermissionPayloadRelationshipsResources()
                {
                    Data = new List<CheckPermissionPayloadRelationshipsResourcesData>
                        {
                            new CheckPermissionPayloadRelationshipsResourcesData
                            {
                                Type = Type.Folders,
                                Id = project_top_folder_one_id
                            },
                            new CheckPermissionPayloadRelationshipsResourcesData
                            {
                                Type = Type.Folders,
                                Id = project_top_folder_two_id
                            }
                        }
                }
            }
        };

        Console.WriteLine(checkPermissionPayload);

        CheckPermission checkPermission = await dataManagementClient.ExecuteCheckPermissionAsync(project_id, checkPermissionPayload, accessToken: token);
        
        Console.WriteLine(checkPermission);

    }

    #endregion commands

    public static async Task Main(string[] args)
    {
        DataManagement dataManagement = new DataManagement();

        // Initialise SDKManager & AuthClient
        dataManagement.Initialise();

        // Hubs
        await dataManagement.GetHubsAsync();
        await dataManagement.GetHubAsync();

        // Projects
        await dataManagement.GetHubProjectsAsync();
        await dataManagement.GetProjectAsync();
        await dataManagement.GetProjectHubAsync();
        await dataManagement.GetProjectTopFoldersAsync();
        await dataManagement.GetDownloadAsync();
        await dataManagement.GetDownloadJobAsync();
        await dataManagement.StartDownloadAsync();
        await dataManagement.CreateStorageAsync();

        Folders
        await dataManagement.GetFolderAsync();
        await dataManagement.GetFolderAsync();
        await dataManagement.GetFolderContentsAsync();
        await dataManagement.GetFolderParentAsync();
        await dataManagement.GetFolderRefsAsync();
        await dataManagement.GetFolderRelationshipsLinksAsync();
        await dataManagement.GetFolderRelationshipsRefsAsync();
        await dataManagement.GetFolderSearchAsync();
        await dataManagement.CreateFolderAsync();
        await dataManagement.CreateFolderRelationshipsRefAsync();
        await dataManagement.PatchFolderAsync();

        // Items
        await dataManagement.GetItemAsync();
        await dataManagement.GetItemParentFolderAsync();
        await dataManagement.GetItemRefsAsync();
        await dataManagement.GetItemRelationshipsLinksAsync();
        await dataManagement.GetItemRelationshipsRefsAsync();
        await dataManagement.GetItemTipAsync();
        await dataManagement.GetItemVersionsAsync();
        await dataManagement.CreateItemRelationshipsRefAsync();
        await dataManagement.PatchItemAsync();

        // Versions
        await dataManagement.GetVersionAsync();
        await dataManagement.GetVersionDownloadFormatsAsync();
        await dataManagement.GetVersionDownloadsAsync();
        await dataManagement.GetVersionItemAsync();
        await dataManagement.GetVersionRefsAsync();
        await dataManagement.GetVersionRelationshipsLinksAsync();
        await dataManagement.GetVersionRelationshipsRefsAsync();
        await dataManagement.CreateVersionAsync();
        await dataManagement.CreateVersionRelationshipsRefAsync();
        await dataManagement.PatchVersionAsync();

        // Commands
        await dataManagement.ExecuteCheckPermissionCommandAsync();
    }
}

