using Autodesk.DataManagement;
using Autodesk.DataManagement.Http;
using Autodesk.DataManagement.Model;
using Autodesk.SDKManager;
using Newtonsoft.Json;

class DataManagement
{
    string? token = Environment.GetEnvironmentVariable("token");
    string? folder_id = Environment.GetEnvironmentVariable("folder_id");
    string? project_top_folder_one_id = Environment.GetEnvironmentVariable("project_top_folder_one_id");
    string? project_top_folder_two_id = Environment.GetEnvironmentVariable("project_top_folder_two_id");
    string? hub_id = Environment.GetEnvironmentVariable("hub_id");
    string? project_id = Environment.GetEnvironmentVariable("project_id");
    string? download_id = Environment.GetEnvironmentVariable("download_id");
    string? job_id = Environment.GetEnvironmentVariable("job_id");
    string? item_id = Environment.GetEnvironmentVariable("item_id");
    string? version_id = Environment.GetEnvironmentVariable("version_id");
    string? storage_urn = Environment.GetEnvironmentVariable("storage_urn");

    DataManagementClient dataManagementClient = null!;

    public void Initialise()
    {
        StaticAuthenticationProvider staticAuthenticationProvider = new StaticAuthenticationProvider(token);
        dataManagementClient = new DataManagementClient(authenticationProvider: staticAuthenticationProvider);
    }


    #region hubs
    public async Task GetHubsAsync()
    {
        List<string> filter_id = new List<string> { "b.a4f95080-84fe-4281-8d0a-bd8c885695e0" };
        List<string> filter_name = new List<string> { "Autodesk Forge Partner Development" };
        List<string> filter_extension_type = new List<string> { "hubs:autodesk.bim360:Account" };

        Hubs hubs = await dataManagementClient.GetHubsAsync(filterId: filter_id, filterName: filter_name, filterExtensionType: filter_extension_type);

        List<HubData> hubsData = hubs.Data;
        foreach (var hub in hubsData)
        {
            TypeHub hubsType = hub.Type;
            string HubsId = hub.Id;

            Console.WriteLine(hubsType);
            
            Console.WriteLine(HubsId);
            Console.WriteLine(hub.Attributes.Name);
            Region region = hub.Attributes.Region;
            Console.WriteLine(hub.Attributes.Extension.Type);
        }
    }

    public async Task GetHubAsync()
    {
        Hub hub = await dataManagementClient.GetHubAsync(hubId: hub_id);

        HubData hubData = hub.Data;
        TypeHub hubType = hubData.Type;
        string hubId = hubData.Id;

        Console.WriteLine(hubType);
        Console.WriteLine(hubId);
        Console.WriteLine(hubData.Attributes.Name);
    }

    #endregion hubs


    #region projects

    public async Task GetHubProjectsAsync()
    {
        List<string> filter_id = new List<string> { "b.180e1bc8-6687-4029-a069-319f611de8a9" };
        List<string> filter_extension_type = new List<string> { "projects:autodesk.bim360:Project" };

        Projects projects = await dataManagementClient.GetHubProjectsAsync(hubId: hub_id, filterId: filter_id, filterExtensionType: filter_extension_type, pageNumber: 0, pageLimit: 1);

        List<ProjectData> projectsData = projects.Data;
        foreach (var current in projectsData)
        {
            TypeProject hubProjectsType = current.Type;
            string hubProjectsId = current.Id;

            Console.WriteLine(hubProjectsType);
            Console.WriteLine(hubProjectsId);
            Console.WriteLine(current.Attributes.Extension.Type);
        }
    }

    public async Task GetProjectAsync()
    {
        Project project = await dataManagementClient.GetProjectAsync(hubId: hub_id, projectId: project_id);

        ProjectData projectData = project.Data;
        TypeProject hubProjectDataType = projectData.Type;
        string hubProjectDataId = projectData.Id;

        Console.WriteLine(hubProjectDataType);
        Console.WriteLine(hubProjectDataId);
    }

    public async Task GetProjectHubAsync()
    {
        Hub hub = await dataManagementClient.GetProjectHubAsync(hubId: hub_id, projectId: project_id);

        HubData hubData = hub.Data;
        TypeHub hubType = hubData.Type;
        string hubId = hubData.Id;

        Console.WriteLine(hubType);
        Console.WriteLine(hubId);
    }

    public async Task GetProjectTopFoldersAsync()
    {
        TopFolders topFolders = await dataManagementClient.GetProjectTopFoldersAsync(hubId: hub_id, projectId: project_id, excludeDeleted: true, projectFilesOnly: false);

        List<TopFolderData> topFolderData = topFolders.Data;
        foreach (var topFolder in topFolderData)
        {
            TypeFolder folderType = topFolder.Type;
            string folderId = topFolder.Id;

            Console.WriteLine(folderType);
            Console.WriteLine(folderId);
        }
    }

    public async Task GetDownloadAsync()
    {
        Download download = await dataManagementClient.GetDownloadAsync(projectId: project_id, downloadId: download_id);

        DownloadData downloadData = download.Data;
        TypeDownloads downloadType = downloadData.Type;
        string downloadId = downloadData.Id;

        Console.WriteLine(downloadType);
        Console.WriteLine(downloadId);
    }

    public async Task GetDownloadJobAsync()
    {
        Job job = await dataManagementClient.GetDownloadJobAsync(projectId: project_id, jobId: job_id);

        JobData jobData = job.Data;
        TypeJob jobDataType = jobData.Type;
        string jobDataId = jobData.Id;

        Console.WriteLine(jobDataType);
        Console.WriteLine(jobDataId);
    }

    public async Task CreateDownloadAsync()
    {
        DownloadPayload downloadPayload = new DownloadPayload()
        {
            Jsonapi = new JsonApiVersion()
            {
                VarVersion = JsonApiVersionValue._10
            },
            Data = new DownloadPayloadData()
            {
                Type = TypeDownloads.Downloads,
                Attributes = new DownloadPayloadDataAttributes()
                {
                    Format = new DownloadPayloadDataAttributesFormat()
                    {
                        FileType = "dwg"
                    }
                },
                Relationships = new DownloadPayloadDataRelationships()
                {
                    Source = new DownloadPayloadDataRelationshipsSource()
                    {
                        Data = new DownloadPayloadDataRelationshipsSourceData()
                        {
                            Type = TypeVersion.Versions,
                            Id = version_id
                        }
                    }
                }
            }
        };

        CreatedDownload createdDownload = await dataManagementClient.CreateDownloadAsync(projectId: project_id, downloadPayload: downloadPayload);

        List<CreatedDownloadData> createdDownloadData = createdDownload.Data;
        foreach (var downloadData in createdDownloadData)
        {
            TypeJob downloadDataType = downloadData.Type;
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
                VarVersion = JsonApiVersionValue._10
            },
            Data = new StoragePayloadData()
            {
                Type = TypeObject.Objects,
                Attributes = new StoragePayloadDataAttributes()
                {
                    Name = "drawing.dwg",

                },
                Relationships = new StoragePayloadDataRelationships()
                {
                    Target = new StoragePayloadDataRelationshipsTarget()
                    {
                        Data = new StoragePayloadDataRelationshipsTargetData()
                        {
                            Type = TypeFolderItemsForStorage.Folders,
                            Id = folder_id
                        }
                    }
                }
            }
        };

        Storage storage = await dataManagementClient.CreateStorageAsync(projectId: project_id, storagePayload: storagePayload);

        StorageData storageData = storage.Data;
        TypeObject storageDataType = storageData.Type;
        string storageDataId = storageData.Id;

        Console.WriteLine(storageDataType);
        Console.WriteLine(storageDataId);
    }

    #endregion projects


    #region folders

    public async Task GetFolderAsync()
    {
        Folder folder = await dataManagementClient.GetFolderAsync(projectId: project_id, folderId: folder_id);

        FolderData folderData = folder.Data;
        TypeFolder folderDataType = folderData.Type;
        string folderDataId = folderData.Id;

        Console.WriteLine(folderDataType);
        Console.WriteLine(folderDataId);
    }
    public async Task GetFolderContentsAsync()
    {
        List<FilterType> filter_type = new List<FilterType> { FilterType.Items, FilterType.Folders };

        FolderContents folderContents = await dataManagementClient.GetFolderContentsAsync(projectId: project_id, folderId: folder_id, filterType: filter_type);
        Console.WriteLine(folderContents);
        List<IFolderContentsData> folderContentsData = folderContents.Data;

        // Prepare to serialize using the FolderContentsDataConverter
        var converter = new FolderContentsDataConverter();
        var serializer = new JsonSerializer();

        using (var stringWriter = new StringWriter())
        using (var jsonWriter = new JsonTextWriter(stringWriter))
        {
            // Call WriteJson manually
            converter.WriteJson(jsonWriter, folderContents.Data, serializer);

            // Output the resulting JSON string
            string jsonOutput = stringWriter.ToString();
            Console.WriteLine(jsonOutput);
        }

        foreach (var current in folderContentsData)
        {
            if (current is FolderData folder)
            {
                Console.WriteLine(folder.Id);
                Console.WriteLine(folder.Type);
                Console.WriteLine(folder.Relationships.Parent.Data.Type);
            }
            else if (current is ItemData item)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Type);
            }
        }
    }

    public async Task GetFolderParentAsync()
    {

        Folder folder = await dataManagementClient.GetFolderParentAsync(projectId: project_id, folderId: folder_id);

        FolderData folderData = folder.Data;
        TypeFolder folderDataType = folderData.Type;
        string folderDataId = folderData.Id;

        Console.WriteLine(folderDataType);
        Console.WriteLine(folderDataId);
    }

    public async Task GetFolderRefsAsync()
    {
        FolderRefs folderRefs = await dataManagementClient.GetFolderRefsAsync(projectId: project_id, folderId: folder_id);
        List<IFolderRefsData> folderRefsData = folderRefs.Data;
        foreach (var current in folderRefsData)
        {
            if (current is FolderData folder)
            {
                Console.WriteLine(folder.Id);
                Console.WriteLine(folder.Type);
                Console.WriteLine(folder.Relationships.Parent.Data.Type);
            }
            else if (current is ItemData item)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Type);
            }
            else if (current is VersionData version)
            {
                Console.WriteLine(version.Id);
                Console.WriteLine(version.Type);
            }
        }
    }

    public async Task GetFolderRelationshipsLinksAsync()
    {
        RelationshipLinks relationshipLinks = await dataManagementClient.GetFolderRelationshipsLinksAsync(projectId: project_id, folderId: folder_id);

        List<RelationshipLinksData> relationshipLinksData = relationshipLinks.Data;
        foreach (var relationshipLinkData in relationshipLinksData)
        {
            TypeLink relationshipLinkDataType = relationshipLinkData.Type;
            string relationshipLinkDataId = relationshipLinkData.Id;

            Console.WriteLine(relationshipLinkDataType);
            Console.WriteLine(relationshipLinkDataId);
        }
    }

    public async Task GetFolderRelationshipsRefsAsync()
    {
        RelationshipRefs relationshipRefs = await dataManagementClient.GetFolderRelationshipsRefsAsync(folderId: folder_id, projectId: project_id);

        IRelationshipRefsLinks links = relationshipRefs.Links;
        Console.WriteLine(links);

        List<RelationshipRefsData> relationshipRefsData = relationshipRefs.Data;
        foreach (var relationshipRefData in relationshipRefsData)
        {
            TypeEntity relationshipRefDataType = relationshipRefData.Type;
            string relationshipRefDataId = relationshipRefData.Id;

            Console.WriteLine(relationshipRefDataType);
            Console.WriteLine(relationshipRefDataId);
        }

        List<IRelationshipRefsIncluded> relationshipRefsIncluded = relationshipRefs.Included;
        foreach (var current in relationshipRefsIncluded)
        {
            if (current is FolderData folder)
            {
                Console.WriteLine(folder.Id);
                Console.WriteLine(folder.Type);
                Console.WriteLine(folder.Relationships.Parent.Data.Type);
            }
            else if (current is ItemData item)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Type);
            }
            else if (current is VersionData version)
            {
                Console.WriteLine(version.Id);
                Console.WriteLine(version.Type);
            }
        }
    }

    public async Task GetFolderSearchAsync()
    {
        var filters = new List<(string fieldName, ComparisonTypes? operatorType, List<string> values)>
        {
            // ("id", null, new List<string> { "urn:adsk.wipprod:fs.file:vf.lwzzqBEUQXaSukbg0uYXPg?version=1" }),
            // ("attributes.displayName", null, new List<string> { "drawingmyt.rvt"}),
            ("attributes.displayName", ComparisonTypes.EqualTo, new List<string> { "drawingmyt.rvt"}),
            // ("createUserName", null, new List<string> { "Harun Gitundu" }),
        };

        Search search = await dataManagementClient.GetFolderSearchAsync(
            projectId: project_id,
            folderId: folder_id,
            filters: filters,
            pageNumber: 0
        );
    
        // Process the search data
        List<VersionData> searchData = search.Data;
        foreach (var currentSearchData in searchData)
        {
            TypeVersion currentSearchDataType = currentSearchData.Type;
            string currentSearchDataId = currentSearchData.Id;

            Console.WriteLine(currentSearchDataType);
            Console.WriteLine(currentSearchDataId);
            Console.WriteLine(currentSearchData.Attributes.Name);
            Console.WriteLine(currentSearchData.Attributes.CreateUserName);
            Console.WriteLine(currentSearchData.Attributes.LastModifiedUserName);
            Console.WriteLine(currentSearchData.Attributes.FileType);
            Console.WriteLine(currentSearchData.Attributes.DisplayName);
            Console.WriteLine(currentSearchData.Attributes.Extension.Type);
        }
    }


    public async Task CreateFolderAsync()
    {
        FolderPayload folderPayload = new FolderPayload()
        {
            Jsonapi = new JsonApiVersion()
            {
                VarVersion = JsonApiVersionValue._10
            },
            Data = new FolderPayloadData()
            {
                Type = TypeFolder.Folders,
                Attributes = new FolderPayloadDataAttributes()
                {
                    Name = "Preject 2030",
                    Extension = new FolderPayloadDataAttributesExtension()
                    {
                        Type = "folders:autodesk.bim360:Folder",
                        VarVersion = "1.0"
                    }
                },
                Relationships = new FolderPayloadDataRelationships()
                {
                    Parent = new FolderPayloadDataRelationshipsParent()
                    {
                        Data = new FolderPayloadDataRelationshipsParentData()
                        {
                            Type = TypeFolder.Folders,
                            Id = folder_id,
                        }
                    }
                }
            },
        };

        Console.WriteLine(folderPayload);

        Folder folder = await dataManagementClient.CreateFolderAsync(projectId: project_id, folderPayload: folderPayload);

        FolderData folderData = folder.Data;
        TypeFolder folderDataType = folderData.Type;
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
                VarVersion = JsonApiVersionValue._10
            },
            Data = new RelationshipRefsPayloadData()
            {
                Type = TypeEntity.Versions,
                Id = version_id,
                Meta = new RelationshipRefsPayloadDataMeta()
                {
                    Extension = new BaseAttributesExtensionObjectWithoutSchemaLink()
                    {
                        Type = "auxiliary:autodesk.core:Attachment",
                        VarVersion = "1.0"
                    }
                }
            }
        };

        HttpResponseMessage relationship = await dataManagementClient.CreateFolderRelationshipsRefAsync(folderId: folder_id, projectId: project_id, relationshipRefsPayload: relationshipRefsPayload);
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
                VarVersion = JsonApiVersionValue._10
            },
            Data = new ModifyFolderPayloadData()
            {
                Type = TypeFolder.Folders,
                Id = folder_id,
                Attributes = new ModifyFolderPayloadDataAttributes()
                {
                    Name = "Project 3096"
                }
            }
        };

        Console.WriteLine(modifyFolderPayload);

        Folder folder = await dataManagementClient.PatchFolderAsync(projectId: project_id, folderId: folder_id, modifyFolderPayload: modifyFolderPayload);

        FolderData folderData = folder.Data;
        TypeFolder folderDataType = folderData.Type;
        string folderDataId = folderData.Id;

        Console.WriteLine(folderDataType);
        Console.WriteLine(folderDataId);
    }

    #endregion folders


    #region items

    public async Task GetItemAsync()
    {
        Item item = await dataManagementClient.GetItemAsync(projectId: project_id, itemId: item_id);

        ItemData itemData = item.Data;
        TypeItem itemDataType = itemData.Type;
        string itemDataId = itemData.Id;

        Console.WriteLine(itemDataType);
        Console.WriteLine(itemDataId);
    }

    public async Task GetItemParentFolderAsync()
    {
        Folder folder = await dataManagementClient.GetItemParentFolderAsync(projectId: project_id, itemId: item_id);

        FolderData folderData = folder.Data;
        TypeFolder folderDataType = folderData.Type;
        string folderDataId = folderData.Id;

        Console.WriteLine(folderDataType);
        Console.WriteLine(folderDataId);
    }

    public async Task GetItemRefsAsync()
    {
        Refs refs = await dataManagementClient.GetItemRefsAsync(projectId: project_id, itemId: item_id);

        List<IRefsData> refsData = refs.Data;
        foreach (var current in refsData)
        {
            if (current is FolderData folder)
            {
                Console.WriteLine(folder.Id);
                Console.WriteLine(folder.Type);
                Console.WriteLine(folder.Relationships.Parent.Data.Type);
            }
            else if (current is ItemData item)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Type);
            }
            else if (current is VersionData version)
            {
                Console.WriteLine(version.Id);
                Console.WriteLine(version.Type);
            }
        }
    }

    public async Task GetItemRelationshipsLinksAsync()
    {
        RelationshipLinks relationshipLinks = await dataManagementClient.GetItemRelationshipsLinksAsync(projectId: project_id, itemId: item_id);

        List<RelationshipLinksData> relationshipLinksData = relationshipLinks.Data;
        foreach (var relationshipLinkData in relationshipLinksData)
        {
            TypeLink relationshipLinkDataType = relationshipLinkData.Type;
            string relationshipLinkDataId = relationshipLinkData.Id;

            Console.WriteLine(relationshipLinkDataType);
            Console.WriteLine(relationshipLinkDataId);
        }
    }

    public async Task GetItemRelationshipsRefsAsync()
    {
        RelationshipRefs relationshipRefs = await dataManagementClient.GetItemRelationshipsRefsAsync(projectId: project_id, itemId: item_id);

        IRelationshipRefsLinks links = relationshipRefs.Links;
        Console.WriteLine(links);

        List<RelationshipRefsData> relationshipRefsData = relationshipRefs.Data;
        foreach (var relationshipRefData in relationshipRefsData)
        {
            TypeEntity relationshipRefDataType = relationshipRefData.Type;
            string relationshipRefDataId = relationshipRefData.Id;

            Console.WriteLine(relationshipRefDataType);
            Console.WriteLine(relationshipRefDataId);
        }

        List<IRelationshipRefsIncluded> relationshipRefsIncluded = relationshipRefs.Included;
        foreach (var current in relationshipRefsIncluded)
        {
            if (current is FolderData folder)
            {
                Console.WriteLine(folder.Id);
                Console.WriteLine(folder.Type);
                Console.WriteLine(folder.Relationships.Parent.Data.Type);
            }
            else if (current is ItemData item)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Type);
            }
            else if (current is VersionData version)
            {
                Console.WriteLine(version.Id);
                Console.WriteLine(version.Type);
            }
        }
    }

    public async Task GetItemTipAsync()
    {
        ItemTip itemTip = await dataManagementClient.GetItemTipAsync(projectId: project_id, itemId: item_id);

        VersionData itemTipData = itemTip.Data;
        TypeVersion itemTipDataType = itemTipData.Type;
        string itemTipDataId = itemTipData.Id;

        Console.WriteLine(itemTipDataType);
        Console.WriteLine(itemTipDataId);
    }

    public async Task GetItemVersionsAsync()
    {
        Versions versions = await dataManagementClient.GetItemVersionsAsync(projectId: project_id, itemId: item_id);

        List<VersionData> versionsData = versions.Data;
        foreach (var versionData in versionsData)
        {
            TypeVersion versionDataType = versionData.Type;
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
                VarVersion = JsonApiVersionValue._10
            },
            Data = new ItemPayloadData()
            {
                Type = TypeItem.Items,
                Attributes = new ItemPayloadDataAttributes()
                {
                    DisplayName = "drawingmytmz.rvt",
                    Extension = new ItemPayloadDataAttributesExtension()
                    {
                        Type = "items:autodesk.bim360:File",
                        VarVersion = "1.0"
                    }
                },
                Relationships = new ItemPayloadDataRelationships()
                {
                    Tip = new ItemPayloadDataRelationshipsTip()
                    {
                        Data = new ItemPayloadDataRelationshipsTipData()
                        {
                            Type = TypeVersion.Versions,
                            Id = "1"
                        }
                    },
                    Parent = new ItemPayloadDataRelationshipsParent()
                    {
                        Data = new ItemPayloadDataRelationshipsParentData()
                        {
                            Type = TypeFolder.Folders,
                            Id = folder_id,
                        }
                    }
                }
            },
            Included = new List<ItemPayloadIncluded>()
            {
                new ItemPayloadIncluded()
                {
                    Type = TypeVersion.Versions,
                    Id = "1",
                    Attributes = new ItemPayloadIncludedAttributes()
                    {
                        Name = "drawingmytmz.rvt",
                        Extension = new ItemPayloadIncludedAttributesExtension()
                        {
                            Type = "versions:autodesk.bim360:File",
                            VarVersion = "1.0"
                        }
                    },
                    Relationships = new ItemPayloadIncludedRelationships()
                    {
                        Storage = new ItemPayloadIncludedRelationshipsStorage()
                        {
                            Data = new ItemPayloadIncludedRelationshipsStorageData()
                            {
                                Type = TypeObject.Objects,
                                Id = "urn:adsk.objects:os.object:wip.dm.prod/462aed7c-8d5d-47a1-ae5f-5c930a35931c.rvt"
                            }
                        }
                    }
                }
            }
        };

        CreatedItem item = await dataManagementClient.CreateItemAsync(projectId: project_id, itemPayload: itemPayload);

        ItemData itemData = item.Data;
        TypeItem itemDataType = itemData.Type;
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
                VarVersion = JsonApiVersionValue._10
            },
            Data = new RelationshipRefsPayloadData()
            {
                Type = TypeEntity.Versions,
                Id = version_id,
                Meta = new RelationshipRefsPayloadDataMeta()
                {
                    Extension = new BaseAttributesExtensionObjectWithoutSchemaLink()
                    {
                        Type = "auxiliary:autodesk.core:Attachment",
                        VarVersion = "1.0"
                    }
                }
            }
        };

        HttpResponseMessage responseMessage = await dataManagementClient.CreateItemRelationshipsRefAsync(projectId: project_id, itemId: item_id, relationshipRefsPayload: relationshipRefsPayload);
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
                VarVersion = JsonApiVersionValue._10
            },
            Data = new ModifyItemPayloadData()
            {
                Type = TypeItem.Items,
                Id = item_id,
                Attributes = new ModifyItemPayloadDataAttributes()
                {
                    DisplayName = "newDrawing.rvt"
                }
            }
        };

        Item item = await dataManagementClient.PatchItemAsync(projectId: project_id, itemId: item_id, modifyItemPayload: modifyItemPayload);

        ItemData itemData = item.Data;
        TypeItem itemDataType = itemData.Type;
        string itemDataId = itemData.Id;

        Console.WriteLine(itemDataType);
        Console.WriteLine(itemDataId);
    }

    #endregion items


    #region versions
    public async Task GetVersionAsync()
    {
        ModelVersion versionDetails = await dataManagementClient.GetVersionAsync(projectId: project_id, versionId: version_id);

        VersionData versionDetailsData = versionDetails.Data;
        TypeVersion versionDetailsDataType = versionDetailsData.Type;
        string versionDetailsDataId = versionDetailsData.Id;

        Console.WriteLine(versionDetailsDataType);
        Console.WriteLine(versionDetailsDataId);
    }

    public async Task GetVersionDownloadFormatsAsync()
    {
        DownloadFormats downloadFormats = await dataManagementClient.GetVersionDownloadFormatsAsync(projectId: project_id, versionId: version_id);

        DownloadFormatsData downloadFormatsData = downloadFormats.Data;
        TypeDownloadformats downloadFormatsDataType = downloadFormatsData.Type;
        string downloadFormatsDataId = downloadFormatsData.Id;

        Console.WriteLine(downloadFormatsDataType);
        Console.WriteLine(downloadFormatsDataId);
    }

    public async Task GetVersionDownloadsAsync()
    {
        Downloads downloads = await dataManagementClient.GetVersionDownloadsAsync(projectId: project_id, versionId: version_id);

        List<DownloadData> downloadsData = downloads.Data;
        foreach (var downloadData in downloadsData)
        {
            TypeDownloads downloadDataType = downloadData.Type;
            string downloadDataId = downloadData.Id;

            Console.WriteLine(downloadDataType);
            Console.WriteLine(downloadDataId);
        }
    }

    public async Task GetVersionItemAsync()
    {
        Item item = await dataManagementClient.GetVersionItemAsync(projectId: project_id, versionId: version_id);

        ItemData itemData = item.Data;
        TypeItem itemDataType = itemData.Type;
        string itemDataId = itemData.Id;

        Console.WriteLine(itemDataType);
        Console.WriteLine(itemDataId);
    }

    public async Task GetVersionRefsAsync()
    {
        Refs refs = await dataManagementClient.GetVersionRefsAsync(projectId: project_id, versionId: version_id);

        List<IRefsData> refsData = refs.Data;
        foreach (var current in refsData)
        {
            if (current is FolderData folder)
            {
                Console.WriteLine(folder.Id);
                Console.WriteLine(folder.Type);
                Console.WriteLine(folder.Relationships.Parent.Data.Type);
            }
            else if (current is ItemData item)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Type);
            }
            else if (current is VersionData version)
            {
                Console.WriteLine(version.Id);
                Console.WriteLine(version.Type);
            }
        }
    }

    public async Task GetVersionRelationshipsLinksAsync()
    {
        RelationshipLinks relationshipLinks = await dataManagementClient.GetVersionRelationshipsLinksAsync(projectId: project_id, versionId: version_id);

        List<RelationshipLinksData> relationshipLinksData = relationshipLinks.Data;
        foreach (var relationshipLinkData in relationshipLinksData)
        {
            TypeLink relationshipLinkDataType = relationshipLinkData.Type;
            string relationshipLinkDataId = relationshipLinkData.Id;

            Console.WriteLine(relationshipLinkDataType);
            Console.WriteLine(relationshipLinkDataId);
        }
    }

    public async Task GetVersionRelationshipsRefsAsync()
    {
        RelationshipRefs relationshipRefs = await dataManagementClient.GetVersionRelationshipsRefsAsync(projectId: project_id, versionId: version_id);

        IRelationshipRefsLinks links = relationshipRefs.Links;
        Console.WriteLine(links);

        List<RelationshipRefsData> relationshipRefsData = relationshipRefs.Data;
        foreach (var relationshipRefData in relationshipRefsData)
        {
            TypeEntity relationshipRefDataType = relationshipRefData.Type;
            string relationshipRefDataId = relationshipRefData.Id;

            Console.WriteLine(relationshipRefDataType);
            Console.WriteLine(relationshipRefDataId);
        }

        List<IRelationshipRefsIncluded> relationshipRefsIncluded = relationshipRefs.Included;
        foreach (var current in relationshipRefsIncluded)
        {
            if (current is FolderData folder)
            {
                Console.WriteLine(folder.Id);
                Console.WriteLine(folder.Type);
                Console.WriteLine(folder.Relationships.Parent.Data.Type);
            }
            else if (current is ItemData item)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Type);
            }
            else if (current is VersionData version)
            {
                Console.WriteLine(version.Id);
                Console.WriteLine(version.Type);
            }
        }
    }

    public async Task CreateVersionAsync()
    {
        VersionPayload versionPayload = new VersionPayload()
        {
            Jsonapi = new JsonApiVersion()
            {
                VarVersion = JsonApiVersionValue._10
            },
            Data = new VersionPayloadData()
            {
                Type = TypeVersion.Versions,
                Attributes = new VersionPayloadDataAttributes()
                {
                    Name = "racteded.rvt",
                    Extension = new VersionPayloadDataAttributesExtension()
                    {
                        Type = "versions:autodesk.bim360:File",
                        VarVersion = "1.0"
                    }
                },
                Relationships = new VersionPayloadDataRelationships()
                {
                    Item = new VersionPayloadDataRelationshipsItem()
                    {
                        Data = new VersionPayloadDataRelationshipsItemData()
                        {
                            Type = TypeItem.Items,
                            Id = item_id
                        }
                    },
                    Storage = new VersionPayloadDataRelationshipsStorage()
                    {
                        Data = new VersionPayloadDataRelationshipsStorageData()
                        {
                            Type = TypeObject.Objects,
                            Id = storage_urn
                        }
                    }
                }
            }
        };

        CreatedVersion createdVersion = await dataManagementClient.CreateVersionAsync(projectId: project_id, versionPayload: versionPayload);

        CreatedVersionData createdVersionData = createdVersion.Data;
        TypeVersion createdVersionDataType = createdVersionData.Type;
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
                VarVersion = JsonApiVersionValue._10
            },
            Data = new RelationshipRefsPayloadData()
            {
                Type = TypeEntity.Versions,
                Id = version_id,
                Meta = new RelationshipRefsPayloadDataMeta()
                {
                    Extension = new BaseAttributesExtensionObjectWithoutSchemaLink()
                    {
                        Type = "auxiliary:autodesk.core:Attachment",
                        VarVersion = "1.0"
                    }
                }
            }
        };

        HttpResponseMessage responseMessage = await dataManagementClient.CreateVersionRelationshipsRefAsync(projectId: project_id, versionId: version_id, relationshipRefsPayload: relationshipRefsPayload);

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
                VarVersion = JsonApiVersionValue._10
            },
            Data = new ModifyVersionPayloadData()
            {
                Type = TypeVersion.Versions,
                Id = version_id,
                Attributes = new ModifyVersionPayloadDataAttributes()
                {
                    Name = "project2624.rvt"
                }
            }
        };

        ModelVersion versionDetails = await dataManagementClient.PatchVersionAsync(projectId: project_id, versionId: version_id, modifyVersionPayload: modifyVersionPayload);

        VersionData versionDetailsData = versionDetails.Data;
        TypeVersion versionDetailsDataType = versionDetailsData.Type;
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
            Type = TypeCommands.Commands,
            Attributes = new CheckPermissionPayloadAttributes()
            {
                Extension = new CheckPermissionPayloadAttributesExtension()
                {
                    Type = TypeCommandtypeCheckPermission.CommandsautodeskCoreCheckPermission,
                    VarVersion = "1.0.0",
                    Data = new CheckPermissionPayloadAttributesExtensionData()
                    {

                        RequiredActions = new List<string>
                            {
                               "download",
                               "view",
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
                                Type = TypeEntity.Folders,
                                Id = "urn:adsk.wipprod:fs.folder:co.-tmPjozvRFC-q0MiANsZew"
                            },
                        }
                }
            }
        };

        CheckPermission checkPermission = await dataManagementClient.ExecuteCheckPermissionAsync(projectId: project_id, checkPermissionPayload: checkPermissionPayload);

        TypeCommands checkPermissionType = checkPermission.Type;
        string checkPermissionId = checkPermission.Id;


        Console.WriteLine(checkPermission);
        Console.WriteLine(checkPermissionType);
        Console.WriteLine(checkPermissionId);
    }

    public async Task ExecuteListRefsCommandAsync()
    {
        ListRefsPayload listRefsPayload = new ListRefsPayload()
        {
            Type = TypeCommands.Commands,
            Attributes = new ListRefsPayloadAttributes()
            {
                Extension = new ListRefsPayloadAttributesExtension()
                {
                    Type = TypeCommandtypeListRefs.CommandsautodeskCoreListRefs,
                    VarVersion = "1.0.0"
                }
            },
            Relationships = new ListRefsPayloadRelationships()
            {
                Resources = new ListRefsPayloadRelationshipsResources()
                {
                    Data = new List<ListRefsPayloadRelationshipsResourcesData>
                        {
                            new ListRefsPayloadRelationshipsResourcesData
                            {
                                Type = TypeVersion.Versions,
                                Id = version_id
                            },
                        }
                }
            }
        };

        ListRefs listRefs = await dataManagementClient.ExecuteListRefsAsync(projectId: project_id, listRefsPayload: listRefsPayload);

        TypeCommands listRefsType = listRefs.Type;
        string listRefsId = listRefs.Id;

        Console.WriteLine(listRefsType);
        Console.WriteLine(listRefsId);

        Console.WriteLine(listRefs);


        // Prepare to serialize using the ListRefsIncludedConverter
        var converter = new ListRefsIncludedConverter();
        var serializer = new JsonSerializer();

        using (var stringWriter = new StringWriter())
        using (var jsonWriter = new JsonTextWriter(stringWriter))
        {
            // Call WriteJson manually
            converter.WriteJson(jsonWriter, listRefs.Included, serializer);

            // Output the resulting JSON string
            string jsonOutput = stringWriter.ToString();
            Console.WriteLine(jsonOutput);
        }

        List<IListRefsIncluded> listRefsIncluded = listRefs.Included;
        foreach (var current in listRefsIncluded)
        {
            if (current is ItemData item)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Type);
            }
            else if (current is VersionData version)
            {
                Console.WriteLine(version.Id);
                Console.WriteLine(version.Type);
            }
        }
    }

    public async Task ExecuteListItemsCommandAsync()
    {
        ListItemsPayload listItemsPayload = new ListItemsPayload()
        {
            Type = TypeCommands.Commands,
            Attributes = new ListItemsPayloadAttributes()
            {
                Extension = new ListItemsPayloadAttributesExtension()
                {
                    Type = TypeCommandtypeListItems.CommandsautodeskCoreListItems,
                    VarVersion = "1.0.0"
                }
            },
            Relationships = new ListItemsPayloadRelationships()
            {
                Resources = new ListItemsPayloadRelationshipsResources()
                {
                    Data = new List<ListItemsPayloadRelationshipsResourcesData>
                        {
                            new ListItemsPayloadRelationshipsResourcesData
                            {
                                Type = TypeItem.Items,
                                Id = item_id
                            },
                        }
                }
            }
        };

        ListItems listItems = await dataManagementClient.ExecuteListItemsAsync(projectId: project_id, listItemsPayload: listItemsPayload);

        TypeCommands listItemsType = listItems.Type;
        string listItemsId = listItems.Id;

        Console.WriteLine(listItemsType);
        Console.WriteLine(listItemsId);

        Console.WriteLine(listItems);
    }

    public async Task ExecuteGetPublishModelJobAsync()
    {
        PublishModelJobPayload publishModelJobPayload = new PublishModelJobPayload()
        {
            Type = TypeCommands.Commands,
            Attributes = new PublishModelJobPayloadAttributes()
            {
                Extension = new PublishModelJobPayloadAttributesExtension()
                {
                    Type = TypeCommandtypeGetPublishModelJob.CommandsautodeskBim360C4RModelGetPublishJob,
                    VarVersion = "1.0.0"
                }
            },
            Relationships = new PublishModelJobPayloadRelationships()
            {
                Resources = new PublishModelJobPayloadRelationshipsResources()
                {
                    Data = new List<PublishModelJobPayloadRelationshipsResourcesData>
                        {
                            new PublishModelJobPayloadRelationshipsResourcesData
                            {
                                Type = TypeItem.Items,
                                Id = item_id
                            },
                        }
                }
            }
        };

        PublishModelJob publishModelJob = await dataManagementClient.ExecuteGetPublishModelJobAsync(projectId: project_id, publishModelJobPayload: publishModelJobPayload);

        TypeCommands publishModelJobType = publishModelJob.Type;
        string publishModelJobId = publishModelJob.Id;

        Console.WriteLine(publishModelJobType);
        Console.WriteLine(publishModelJobId);

        Console.WriteLine(publishModelJob);
    }

    public async Task ExecutePublishModelAsync()
    {
        PublishModelPayload publishModelPayload = new PublishModelPayload()
        {
            Type = TypeCommands.Commands,
            Attributes = new PublishModelPayloadAttributes()
            {
                Extension = new PublishModelPayloadAttributesExtension()
                {
                    Type = TypeCommandtypePublishmodel.CommandsautodeskBim360C4RModelPublish,
                    VarVersion = "1.0.0"
                }
            },
            Relationships = new PublishModelPayloadRelationships()
            {
                Resources = new PublishModelPayloadRelationshipsResources()
                {
                    Data = new List<PublishModelPayloadRelationshipsResourcesData>
                        {
                            new PublishModelPayloadRelationshipsResourcesData
                            {
                                Type = TypeItem.Items,
                                Id = item_id
                            },
                        }
                }
            }
        };

        PublishModel publishModel = await dataManagementClient.ExecutePublishModelAsync(projectId: project_id, publishModelPayload: publishModelPayload);

        TypeCommands publishModelType = publishModel.Type;
        string publishModelId = publishModel.Id;

        Console.WriteLine(publishModelType);
        Console.WriteLine(publishModelId);

        Console.WriteLine(publishModel);
    }

    public async Task ExecutePublishWithoutLinksAsync()
    {
        PublishWithoutLinksPayload publishWithoutLinksPayload = new PublishWithoutLinksPayload()
        {
            Type = TypeCommands.Commands,
            Attributes = new PublishWithoutLinksPayloadAttributes()
            {
                Extension = new PublishWithoutLinksPayloadAttributesExtension()
                {
                    Type = TypeCommandtypePublishWithoutLinks.CommandsautodeskBim360C4RPublishWithoutLinks,
                    VarVersion = "1.0.0"
                }
            },
            Relationships = new PublishWithoutLinksPayloadRelationships()
            {
                Resources = new PublishWithoutLinksPayloadRelationshipsResources()
                {
                    Data = new List<PublishWithoutLinksPayloadRelationshipsResourcesData>
                        {
                            new PublishWithoutLinksPayloadRelationshipsResourcesData
                            {
                                Type = TypeItem.Items,
                                Id = item_id
                            },
                        }
                }
            }
        };

        PublishWithoutLinks publishWithoutLinks = await dataManagementClient.ExecutePublishWithoutLinksAsync(projectId: project_id, publishWithoutLinksPayload: publishWithoutLinksPayload);

        TypeCommands publishWithoutLinksType = publishWithoutLinks.Type;
        string publishWithoutLinksId = publishWithoutLinks.Id;

        Console.WriteLine(publishWithoutLinksType);
        Console.WriteLine(publishWithoutLinksId);

        Console.WriteLine(publishWithoutLinks);
    }

    #endregion commands

    public static async Task Main(string[] args)
    {
        DotNetEnv.Env.Load();

        DataManagement dataManagement = new DataManagement();

        // Initialise SDKManager & AuthClient
        dataManagement.Initialise();

        // Hubs
        // await dataManagement.GetHubsAsync();
        // await dataManagement.GetHubAsync();

        // // Projects
        // await dataManagement.GetHubProjectsAsync();
        // await dataManagement.GetProjectAsync();
        // await dataManagement.GetProjectHubAsync();
        // await dataManagement.GetProjectTopFoldersAsync();
        // await dataManagement.GetDownloadAsync();
        // await dataManagement.GetDownloadJobAsync();
        // await dataManagement.StartDownloadAsync();
        // await dataManagement.CreateStorageAsync();

        // Folders
        // await dataManagement.GetFolderAsync();
        // await dataManagement.GetFolderContentsAsync();
        // await dataManagement.GetFolderParentAsync();
        // await dataManagement.GetFolderRefsAsync();
        // await dataManagement.GetFolderRelationshipsLinksAsync();
        // await dataManagement.GetFolderRelationshipsRefsAsync();
        // await dataManagement.GetFolderSearchAsync();
        // await dataManagement.CreateFolderAsync(); 
        // await dataManagement.CreateFolderRelationshipsRefAsync();
        // await dataManagement.PatchFolderAsync();

        // // Items
        // await dataManagement.GetItemAsync();
        // await dataManagement.GetItemParentFolderAsync();
        // await dataManagement.GetItemRefsAsync();
        // await dataManagement.GetItemRelationshipsLinksAsync();
        // await dataManagement.GetItemRelationshipsRefsAsync();
        // await dataManagement.GetItemTipAsync();
        // await dataManagement.GetItemVersionsAsync();
        // await dataManagement.CreateItemAsync();
        // await dataManagement.CreateItemRelationshipsRefAsync();
        // await dataManagement.PatchItemAsync();

        // // Versions
        // await dataManagement.GetVersionAsync();
        // await dataManagement.GetVersionDownloadFormatsAsync();
        // await dataManagement.GetVersionDownloadsAsync();
        // await dataManagement.GetVersionItemAsync();
        // await dataManagement.GetVersionRefsAsync();
        // await dataManagement.GetVersionRelationshipsLinksAsync();
        // await dataManagement.GetVersionRelationshipsRefsAsync();
        // await dataManagement.CreateVersionAsync();
        // await dataManagement.CreateVersionRelationshipsRefAsync();
        // await dataManagement.PatchVersionAsync();

        // Commands
        // await dataManagement.ExecuteCheckPermissionCommandAsync();
        // await dataManagement.ExecuteListRefsCommandAsync();
        // await dataManagement.ExecuteListItemsCommandAsync();
        // await dataManagement.ExecuteGetPublishModelJobAsync();
        // await dataManagement.ExecutePublishModelAsync();
        // await dataManagement.ExecutePublishWithoutLinksAsync();
    }
}

