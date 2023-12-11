# sdk-manager
-Common features in one place ensure in reduced maintenance efforts 

-Consistency for application developers using Autodesk SDKs (happy customers)

-Imagine the pain if each SDK required different/separate steps for authentication

## Installations
Install dotNet 6

## Build / Package Project
1. Quick Project build
```   
  dotnet build
```

2. Package jar
```   
   dotnet pack
```  

### How to publish OSS SDK to ADSK Artifactory
#### One-Time Artifactory Setup (Example NUGET for .NET Artifacts)
1. Make sure you have your account https://art-bobcat.autodesk.com/.
2. Generate API key for Artifactory
3. Follow Setup instruction from "Set Me Up" guide.
```    
nuget sources Add -Name Artifactory -Source https://art-bobcat.autodesk.com/artifactory/api/nuget/v3/autodesk-3p-nuget/sdk.manager -username <ADS username> -password <PASSWORD>   


The NuGet.config file can be found at %appdata%\NuGet\NuGet.config (Windows) or ~/.config/NuGet/NuGet.config (Mac/Linux)
<add key="Artifactory" value="https://art-bobcat.autodesk.com/artifactory/api/nuget/v3/autodesk-3p-nuget/sdk.manager" protocolVersion="3" />

nuget setapikey <ADS username>:<Artifactory API Key> -Source Artifactory
```
4. Upgrade and update <Version> </Version> in sdk-manager.csproj 
5. 4. If all looks good, then bump the version and merge your changes to master
5. Publish your custom SDK to Artifactory
    1. Pack the package
        1. from the directory with the .csproj in it e.g. - `sdk-manager % nuget pack`
        2. this will supply you with the absolute path to the nuget package in sdk-manager/bin/debug
    2. Pushing SDK artifact the ADSK package manager.
    ```
        nuget push <absolute path to nuget package>/sdk.manager.<version>.nupkg -Source Artifactory
    ```