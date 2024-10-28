# Changelog

## [Unreleased](https://github.com/autodesk-platform-services/aps-sdk-net/tree/HEAD)

[Full Changelog](https://github.com/autodesk-platform-services/aps-sdk-net/compare/v2...HEAD)

**Closed issues:**

- Create issue without assignee fails [\#96](https://github.com/autodesk-platform-services/aps-sdk-net/issues/96)
- x-ads-force value is sent in header as True instead of true and gets ignored by MD [\#95](https://github.com/autodesk-platform-services/aps-sdk-net/issues/95)
- HookData object does not contain any HookAttributes like ProjectId [\#94](https://github.com/autodesk-platform-services/aps-sdk-net/issues/94)
- `JsonSerializationException` on `IssuesClient.GetIssuesAsync()` [\#91](https://github.com/autodesk-platform-services/aps-sdk-net/issues/91)
- OssClient.DeleteObjectAsync\(\) & OssClient.GetObjectDetailsAsync\(\) NullReferenceException [\#62](https://github.com/autodesk-platform-services/aps-sdk-net/issues/62)
- Error while using DataManagementClient.GetFolderContentsAsync [\#61](https://github.com/autodesk-platform-services/aps-sdk-net/issues/61)
- DataManagement - Missing relationships field in VersionData model [\#32](https://github.com/autodesk-platform-services/aps-sdk-net/issues/32)
- `FolderContentsIncludedAttributes.StorageSize`: An `int?` data type is insufficient for large files [\#31](https://github.com/autodesk-platform-services/aps-sdk-net/issues/31)
- DataManagement - VersionsDataAttributes does not contain FileType and other properties [\#30](https://github.com/autodesk-platform-services/aps-sdk-net/issues/30)
- Compile sources with documentation. [\#27](https://github.com/autodesk-platform-services/aps-sdk-net/issues/27)
- GetRefreshTokenAsync questions [\#25](https://github.com/autodesk-platform-services/aps-sdk-net/issues/25)
- Incorrect links in readme [\#23](https://github.com/autodesk-platform-services/aps-sdk-net/issues/23)

## [v2](https://github.com/autodesk-platform-services/aps-sdk-net/tree/v2) (2024-07-26)

[Full Changelog](https://github.com/autodesk-platform-services/aps-sdk-net/compare/v1...v2)

**Breaking changes:**

- \[Das 198\] - Updated Model Derivative with feedback and changes from Docs team. [\#50](https://github.com/autodesk-platform-services/aps-sdk-net/pull/50) ([sajith-subramanian](https://github.com/sajith-subramanian))
- \[Das 214\] - Fixes for Authentication SDK  [\#47](https://github.com/autodesk-platform-services/aps-sdk-net/pull/47) ([sajith-subramanian](https://github.com/sajith-subramanian))
- \[DAS 198\] -  Changes to Model Derivative SDK [\#45](https://github.com/autodesk-platform-services/aps-sdk-net/pull/45) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Updated region enum in webhook sdk [\#33](https://github.com/autodesk-platform-services/aps-sdk-net/pull/33) ([nishchhaldagar](https://github.com/nishchhaldagar))

**Implemented enhancements:**

- Upload function now accept memory stream and consumed docs team changes [\#48](https://github.com/autodesk-platform-services/aps-sdk-net/pull/48) ([srivastavarahull](https://github.com/srivastavarahull))
- Added Regions enum support [\#43](https://github.com/autodesk-platform-services/aps-sdk-net/pull/43) ([srivastavarahull](https://github.com/srivastavarahull))
- Added Regions enum, Removed Inline models and Accumulated Docs team changes [\#34](https://github.com/autodesk-platform-services/aps-sdk-net/pull/34) ([srivastavarahull](https://github.com/srivastavarahull))

**Fixed bugs:**

- Fixed Oss Client [\#64](https://github.com/autodesk-platform-services/aps-sdk-net/pull/64) ([srivastavarahull](https://github.com/srivastavarahull))

**Merged pull requests:**

- Release v2 - `Autodesk.Authentication` documentation. [\#59](https://github.com/autodesk-platform-services/aps-sdk-net/pull/59) ([ricaun](https://github.com/ricaun))
- Merge Release v2 branch with Main [\#58](https://github.com/autodesk-platform-services/aps-sdk-net/pull/58) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Update Oss sdk with User Agent Changes [\#57](https://github.com/autodesk-platform-services/aps-sdk-net/pull/57) ([srivastavarahull](https://github.com/srivastavarahull))
- Update release branch [\#56](https://github.com/autodesk-platform-services/aps-sdk-net/pull/56) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Updated User Agent [\#55](https://github.com/autodesk-platform-services/aps-sdk-net/pull/55) ([srivastavarahull](https://github.com/srivastavarahull))
- Updated Used Agent [\#54](https://github.com/autodesk-platform-services/aps-sdk-net/pull/54) ([srivastavarahull](https://github.com/srivastavarahull))
- \[DAS -214\] - Bump up user agent version [\#53](https://github.com/autodesk-platform-services/aps-sdk-net/pull/53) ([sajith-subramanian](https://github.com/sajith-subramanian))
- DAS 203 webhooks client fix [\#52](https://github.com/autodesk-platform-services/aps-sdk-net/pull/52) ([nishchhaldagar](https://github.com/nishchhaldagar))
- Das 219 [\#51](https://github.com/autodesk-platform-services/aps-sdk-net/pull/51) ([srivastavarahull](https://github.com/srivastavarahull))
- DAS 220 - Added DotNet SDK for ACC Admin [\#49](https://github.com/autodesk-platform-services/aps-sdk-net/pull/49) ([nishchhaldagar](https://github.com/nishchhaldagar))
- Keep branch updated with Dev [\#46](https://github.com/autodesk-platform-services/aps-sdk-net/pull/46) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Moved issues under construction [\#44](https://github.com/autodesk-platform-services/aps-sdk-net/pull/44) ([srivastavarahull](https://github.com/srivastavarahull))
- Updated Nuget Package links in the README. [\#40](https://github.com/autodesk-platform-services/aps-sdk-net/pull/40) ([tylerwarner33](https://github.com/tylerwarner33))
- \[DAS 214\] - Update Authentication SDK with changes to Documentation.  [\#37](https://github.com/autodesk-platform-services/aps-sdk-net/pull/37) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Update Changelog yml file in Dev branch [\#36](https://github.com/autodesk-platform-services/aps-sdk-net/pull/36) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Added Download function in oss sample. [\#26](https://github.com/autodesk-platform-services/aps-sdk-net/pull/26) ([srivastavarahull](https://github.com/srivastavarahull))
- Bg remove ads server ref [\#22](https://github.com/autodesk-platform-services/aps-sdk-net/pull/22) ([Arrotech](https://github.com/Arrotech))
- Das 154 [\#21](https://github.com/autodesk-platform-services/aps-sdk-net/pull/21) ([Arrotech](https://github.com/Arrotech))
- Das 169 [\#20](https://github.com/autodesk-platform-services/aps-sdk-net/pull/20) ([srivastavarahull](https://github.com/srivastavarahull))
- Das 159 [\#19](https://github.com/autodesk-platform-services/aps-sdk-net/pull/19) ([srivastavarahull](https://github.com/srivastavarahull))
- Update sln files [\#18](https://github.com/autodesk-platform-services/aps-sdk-net/pull/18) ([sajith-subramanian](https://github.com/sajith-subramanian))

## [v1](https://github.com/autodesk-platform-services/aps-sdk-net/tree/v1) (2023-12-12)

[Full Changelog](https://github.com/autodesk-platform-services/aps-sdk-net/compare/a680c97cd2d3321719b0a54d1c8b1854d90a8967...v1)

**Merged pull requests:**

- Keep Dev Branch updated [\#17](https://github.com/autodesk-platform-services/aps-sdk-net/pull/17) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Updating csproj to prepare for publishing to NuGet [\#16](https://github.com/autodesk-platform-services/aps-sdk-net/pull/16) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Keep Updated with main [\#15](https://github.com/autodesk-platform-services/aps-sdk-net/pull/15) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Update DM Sample. Rename WH custom code folder. [\#14](https://github.com/autodesk-platform-services/aps-sdk-net/pull/14) ([sajith-subramanian](https://github.com/sajith-subramanian))
- keep updated with main [\#13](https://github.com/autodesk-platform-services/aps-sdk-net/pull/13) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Refactor webhooks samples to use functions [\#12](https://github.com/autodesk-platform-services/aps-sdk-net/pull/12) ([Arrotech](https://github.com/Arrotech))
- Update with main [\#11](https://github.com/autodesk-platform-services/aps-sdk-net/pull/11) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Update Issues SDK with correct naming convention [\#10](https://github.com/autodesk-platform-services/aps-sdk-net/pull/10) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Update with main [\#9](https://github.com/autodesk-platform-services/aps-sdk-net/pull/9) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Added tests for Issues [\#7](https://github.com/autodesk-platform-services/aps-sdk-net/pull/7) ([srivastavarahull](https://github.com/srivastavarahull))
- Adjust samples to add functions [\#6](https://github.com/autodesk-platform-services/aps-sdk-net/pull/6) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Adding Issues SDK [\#5](https://github.com/autodesk-platform-services/aps-sdk-net/pull/5) ([srivastavarahull](https://github.com/srivastavarahull))
- Commented Authentication Code in Oss [\#4](https://github.com/autodesk-platform-services/aps-sdk-net/pull/4) ([srivastavarahull](https://github.com/srivastavarahull))
- Develop/sajith [\#3](https://github.com/autodesk-platform-services/aps-sdk-net/pull/3) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Migrated Packages from internal [\#2](https://github.com/autodesk-platform-services/aps-sdk-net/pull/2) ([srivastavarahull](https://github.com/srivastavarahull))
- Set up actions [\#1](https://github.com/autodesk-platform-services/aps-sdk-net/pull/1) ([Arrotech](https://github.com/Arrotech))



\* *This Changelog was automatically generated by [github_changelog_generator](https://github.com/github-changelog-generator/github-changelog-generator)*
