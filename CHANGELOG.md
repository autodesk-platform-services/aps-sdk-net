# Changelog

## [v2.1.1](https://github.com/autodesk-platform-services/aps-sdk-net/tree/v2.1.1) (2025-04-02)

[Full Changelog](https://github.com/autodesk-platform-services/aps-sdk-net/compare/v2.1.0...v2.1.1)

**Closed issues:**

- Unable to find a constructor to use for type Autodesk.Authentication.Model.UserInfo [\#145](https://github.com/autodesk-platform-services/aps-sdk-net/issues/145)

## [v2.1.0](https://github.com/autodesk-platform-services/aps-sdk-net/tree/v2.1.0) (2025-02-20)

[Full Changelog](https://github.com/autodesk-platform-services/aps-sdk-net/compare/v2.0.2...v2.1.0)

**Implemented enhancements:**

- \[DAS 324\] - Updates to the Region and ManifestDerivative models [\#143](https://github.com/autodesk-platform-services/aps-sdk-net/pull/143) ([sajith-subramanian](https://github.com/sajith-subramanian))
- \[BUGFIX 136\] Fixed AssignToType Enum [\#141](https://github.com/autodesk-platform-services/aps-sdk-net/pull/141) ([srivastavarahull](https://github.com/srivastavarahull))
- \[DAS 330\] - Webhooks default enum values fix [\#140](https://github.com/autodesk-platform-services/aps-sdk-net/pull/140) ([nishchhaldagar](https://github.com/nishchhaldagar))
- \[DAS 323\] - Added AUS Region support for ACC Admin [\#135](https://github.com/autodesk-platform-services/aps-sdk-net/pull/135) ([nishchhaldagar](https://github.com/nishchhaldagar))
- \[DAS 327\] - Add AUS regions support for Webhooks [\#134](https://github.com/autodesk-platform-services/aps-sdk-net/pull/134) ([Arrotech](https://github.com/Arrotech))
- \[DAS 326\] - Add AUS region support for datamanagement [\#133](https://github.com/autodesk-platform-services/aps-sdk-net/pull/133) ([Arrotech](https://github.com/Arrotech))
- \[DAS 322\] Added AUS Region Support for Issues [\#132](https://github.com/autodesk-platform-services/aps-sdk-net/pull/132) ([srivastavarahull](https://github.com/srivastavarahull))

**Fixed bugs:**

- \[DAS 332\] - deprecate reactivated status filter [\#144](https://github.com/autodesk-platform-services/aps-sdk-net/pull/144) ([Arrotech](https://github.com/Arrotech))
- \[Das 328\] fix for ascii character [\#139](https://github.com/autodesk-platform-services/aps-sdk-net/pull/139) ([srivastavarahull](https://github.com/srivastavarahull))

**Closed issues:**

- \[Bug\] Webhooks SDK: StatusFilter.Reactivated is available as a Status of webhooks in SDK but not supported [\#142](https://github.com/autodesk-platform-services/aps-sdk-net/issues/142)
- \[Bug\]  Getting hook methods from Webhooks SDK defaults to returning Active hooks, instead of returning both Active and Inactive hooks [\#138](https://github.com/autodesk-platform-services/aps-sdk-net/issues/138)
- AssignToType in ACC Issues API serializes to invalid string representations for HTTP Requests [\#136](https://github.com/autodesk-platform-services/aps-sdk-net/issues/136)
- OssClient.CreateSignedResourceAsync\(\) and Space in the file name [\#129](https://github.com/autodesk-platform-services/aps-sdk-net/issues/129)
- Upload Bucket Json Object Auto Convert To Something Else [\#128](https://github.com/autodesk-platform-services/aps-sdk-net/issues/128)
- Typo, extensions should be extension [\#124](https://github.com/autodesk-platform-services/aps-sdk-net/issues/124)
- Issues IssueLinkedDocumentsDetailsPosition  [\#122](https://github.com/autodesk-platform-services/aps-sdk-net/issues/122)

**Merged pull requests:**

- Keep Development branch updated with main. [\#127](https://github.com/autodesk-platform-services/aps-sdk-net/pull/127) ([sajith-subramanian](https://github.com/sajith-subramanian))

## [v2.0.2](https://github.com/autodesk-platform-services/aps-sdk-net/tree/v2.0.2) (2025-01-13)

[Full Changelog](https://github.com/autodesk-platform-services/aps-sdk-net/compare/v2.0.1...v2.0.2)

**Fixed bugs:**

- \[DAS-320\] Changed the data type of Position from int to double [\#126](https://github.com/autodesk-platform-services/aps-sdk-net/pull/126) ([srivastavarahull](https://github.com/srivastavarahull))
- \[Das 317\] - Fix Extensions property in TopFolderAttributesWithExtensions class [\#125](https://github.com/autodesk-platform-services/aps-sdk-net/pull/125) ([sajith-subramanian](https://github.com/sajith-subramanian))

**Closed issues:**

- Bug in ItemPayloadIncludedRelationshipsStorageData serialization [\#108](https://github.com/autodesk-platform-services/aps-sdk-net/issues/108)
- FolderContentsData not converting to JSON [\#107](https://github.com/autodesk-platform-services/aps-sdk-net/issues/107)

**Merged pull requests:**

- Typo, extensions should be extension [\#123](https://github.com/autodesk-platform-services/aps-sdk-net/pull/123) ([jmelhus](https://github.com/jmelhus))
- Update changelog [\#121](https://github.com/autodesk-platform-services/aps-sdk-net/pull/121) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Keep Dev branch updated [\#120](https://github.com/autodesk-platform-services/aps-sdk-net/pull/120) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Keep Main updated with Release v2 branch [\#119](https://github.com/autodesk-platform-services/aps-sdk-net/pull/119) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Keep Development branch updated [\#93](https://github.com/autodesk-platform-services/aps-sdk-net/pull/93) ([sajith-subramanian](https://github.com/sajith-subramanian))

## [v2.0.1](https://github.com/autodesk-platform-services/aps-sdk-net/tree/v2.0.1) (2024-12-11)

[Full Changelog](https://github.com/autodesk-platform-services/aps-sdk-net/compare/v2-GA...v2.0.1)

**Merged pull requests:**

- Update tests to .NET 8. Centralize package management & target framework. [\#117](https://github.com/autodesk-platform-services/aps-sdk-net/pull/117) ([tylerwarner33](https://github.com/tylerwarner33))
- Add tests to OSS test class [\#116](https://github.com/autodesk-platform-services/aps-sdk-net/pull/116) ([tylerwarner33](https://github.com/tylerwarner33))

## [v2-GA](https://github.com/autodesk-platform-services/aps-sdk-net/tree/v2-GA) (2024-12-02)

[Full Changelog](https://github.com/autodesk-platform-services/aps-sdk-net/compare/v2...v2-GA)

**Breaking changes:**

- Keep Main branch updated with release [\#106](https://github.com/autodesk-platform-services/aps-sdk-net/pull/106) ([sajith-subramanian](https://github.com/sajith-subramanian))
- \[DAS 278\] - ACC Admin adding auth provider [\#90](https://github.com/autodesk-platform-services/aps-sdk-net/pull/90) ([nishchhaldagar](https://github.com/nishchhaldagar))
- \[DAS 275\] - add auth provider to md [\#89](https://github.com/autodesk-platform-services/aps-sdk-net/pull/89) ([sajith-subramanian](https://github.com/sajith-subramanian))
- \[DAS-277\] - Added auth provider to issues and made enums to string in results response [\#88](https://github.com/autodesk-platform-services/aps-sdk-net/pull/88) ([srivastavarahull](https://github.com/srivastavarahull))
- \[DAS 279\] - Webhooks docs and authprovider updates [\#85](https://github.com/autodesk-platform-services/aps-sdk-net/pull/85) ([nishchhaldagar](https://github.com/nishchhaldagar))
- \[Das 276\] - add authprovider to oss [\#84](https://github.com/autodesk-platform-services/aps-sdk-net/pull/84) ([srivastavarahull](https://github.com/srivastavarahull))

**Implemented enhancements:**

- \[DAS 280\] add auth provider to dm client [\#98](https://github.com/autodesk-platform-services/aps-sdk-net/pull/98) ([Arrotech](https://github.com/Arrotech))
- Das 288 overload download method [\#97](https://github.com/autodesk-platform-services/aps-sdk-net/pull/97) ([srivastavarahull](https://github.com/srivastavarahull))
- \[DAS-280\] - Add Auth Provider to DM Client [\#82](https://github.com/autodesk-platform-services/aps-sdk-net/pull/82) ([Arrotech](https://github.com/Arrotech))
- \[DAS-251\]- Updated Oss sample [\#79](https://github.com/autodesk-platform-services/aps-sdk-net/pull/79) ([srivastavarahull](https://github.com/srivastavarahull))
- \[DAS-259\]-Remove Project Scope internal code [\#76](https://github.com/autodesk-platform-services/aps-sdk-net/pull/76) ([srivastavarahull](https://github.com/srivastavarahull))
- \[DAS 237\] - Update Authentication Test [\#72](https://github.com/autodesk-platform-services/aps-sdk-net/pull/72) ([Arrotech](https://github.com/Arrotech))

**Fixed bugs:**

- \[DAS 290\] - Fix for x-ads-force-gets-ignored [\#104](https://github.com/autodesk-platform-services/aps-sdk-net/pull/104) ([sajith-subramanian](https://github.com/sajith-subramanian))
- \[DAS-295\] Fixed create Issue endpoint [\#103](https://github.com/autodesk-platform-services/aps-sdk-net/pull/103) ([srivastavarahull](https://github.com/srivastavarahull))
- Update item payload included relationships storage data type [\#101](https://github.com/autodesk-platform-services/aps-sdk-net/pull/101) ([tylerwarner33](https://github.com/tylerwarner33))
- \[DAS 291\] - Webhooks added HookAttributes field in hookdetails model [\#99](https://github.com/autodesk-platform-services/aps-sdk-net/pull/99) ([nishchhaldagar](https://github.com/nishchhaldagar))

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

**Merged pull requests:**

- Update nuget.config To Reference nuget.org [\#114](https://github.com/autodesk-platform-services/aps-sdk-net/pull/114) ([tylerwarner33](https://github.com/tylerwarner33))
- \[Das-300\] migrate sdk's to .net 8.0 [\#113](https://github.com/autodesk-platform-services/aps-sdk-net/pull/113) ([sajith-subramanian](https://github.com/sajith-subramanian))
- \[DAS 188\] - Upload & Download Function names changed [\#112](https://github.com/autodesk-platform-services/aps-sdk-net/pull/112) ([srivastavarahull](https://github.com/srivastavarahull))
- \[DAS 305\] - Update Webhooks Sample [\#111](https://github.com/autodesk-platform-services/aps-sdk-net/pull/111) ([Arrotech](https://github.com/Arrotech))
- \[DAS 298\] Serialize oneOf responses [\#110](https://github.com/autodesk-platform-services/aps-sdk-net/pull/110) ([Arrotech](https://github.com/Arrotech))
- Update ItemPayloadIncludedRelationshipsStorageData TypeObject [\#109](https://github.com/autodesk-platform-services/aps-sdk-net/pull/109) ([tylerwarner33](https://github.com/tylerwarner33))
- Keep Main branch Updated  [\#105](https://github.com/autodesk-platform-services/aps-sdk-net/pull/105) ([sajith-subramanian](https://github.com/sajith-subramanian))
- \[DAS 294\] Update DM Client class docs [\#102](https://github.com/autodesk-platform-services/aps-sdk-net/pull/102) ([Arrotech](https://github.com/Arrotech))
- Update Main branch with Release V2 [\#100](https://github.com/autodesk-platform-services/aps-sdk-net/pull/100) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Merge Release v2 to Main [\#92](https://github.com/autodesk-platform-services/aps-sdk-net/pull/92) ([sajith-subramanian](https://github.com/sajith-subramanian))
- \[DAS 228\] - ACC Account Admin updates [\#87](https://github.com/autodesk-platform-services/aps-sdk-net/pull/87) ([nishchhaldagar](https://github.com/nishchhaldagar))
- Keep branch updated with Release branch [\#86](https://github.com/autodesk-platform-services/aps-sdk-net/pull/86) ([sajith-subramanian](https://github.com/sajith-subramanian))
- \[DAS 265\] - Restructured ACC Admin code to follow convention [\#80](https://github.com/autodesk-platform-services/aps-sdk-net/pull/80) ([nishchhaldagar](https://github.com/nishchhaldagar))
- \[DAS 260\] - Mark region as obsolete in SpecifyReferences model [\#78](https://github.com/autodesk-platform-services/aps-sdk-net/pull/78) ([sajith-subramanian](https://github.com/sajith-subramanian))
- \[DAS-261\] Define contributions guidelines [\#77](https://github.com/autodesk-platform-services/aps-sdk-net/pull/77) ([augustogoncalves](https://github.com/augustogoncalves))
- \[DAS 258\] - Reorder refreshToken method to improve usability [\#75](https://github.com/autodesk-platform-services/aps-sdk-net/pull/75) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Keep release branch updated [\#74](https://github.com/autodesk-platform-services/aps-sdk-net/pull/74) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Update changelog with main [\#70](https://github.com/autodesk-platform-services/aps-sdk-net/pull/70) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Keep dev branch updated with main [\#69](https://github.com/autodesk-platform-services/aps-sdk-net/pull/69) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Update AutoChangeLog.yml [\#68](https://github.com/autodesk-platform-services/aps-sdk-net/pull/68) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Update AutoChangeLog.yml [\#67](https://github.com/autodesk-platform-services/aps-sdk-net/pull/67) ([sajith-subramanian](https://github.com/sajith-subramanian))
- Release v2 - Reorder `RefreshTokenAsync` [\#65](https://github.com/autodesk-platform-services/aps-sdk-net/pull/65) ([ricaun](https://github.com/ricaun))

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
