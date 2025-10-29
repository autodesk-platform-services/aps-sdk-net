/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Construction.Issues
 *
 * An issue is an item that is created in ACC for tracking, managing and communicating tasks, problems and other points of concern through to resolution. You can manage different types of issues, such as design, safety, and commissioning. We currently support issues that are associated with a project.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Autodesk.Construction.Issues.Model
{
        /// <summary>
        /// A list of attachments to add to the issue.
        /// </summary>
        [DataContract]
        public partial class Attachment
        {
                /// <summary>
                /// Initializes a new instance of the <see cref="Attachment" /> class.
                /// </summary>
                public Attachment()
                {
                }

                /// <summary>
                ///The unique identifier for the attachment, set by the client when creating the attachment reference. This can be any unique GUID, but it is recommended to use the OSS storage GUID. For more information, see the Upload Issue Attachment tutorial.
                /// </summary>
                /// <value>
                ///The unique identifier for the attachment, set by the client when creating the attachment reference. This can be any unique GUID, but it is recommended to use the OSS storage GUID. For more information, see the Upload Issue Attachment tutorial.
                /// </value>
                [DataMember(Name = "attachmentId", EmitDefaultValue = false)]
                public string AttachmentId { get; set; }

                /// <summary>
                ///The human-readable display name for the attachment, including the file extension (for example, .pdf, .jpg, .dwg). This name appears in the ACC web UI and is used when downloading the file from the issue.
                /// </summary>
                /// <value>
                ///The human-readable display name for the attachment, including the file extension (for example, .pdf, .jpg, .dwg). This name appears in the ACC web UI and is used when downloading the file from the issue.
                /// </value>
                [DataMember(Name = "displayName", EmitDefaultValue = false)]
                public string DisplayName { get; set; }

                /// <summary>
                ///The unique filename of the attachment, typically formatted as {attachmentId}.{fileExtension}.
                ///This value must exactly match the name of the file stored in Autodesk Docs (OSS) that you uploaded via the OSS process.
                ///
                ///For more information, see the Upload Issue Attachment tutorial.
                /// </summary>
                /// <value>
                ///The unique filename of the attachment, typically formatted as {attachmentId}.{fileExtension}.
                ///This value must exactly match the name of the file stored in Autodesk Docs (OSS) that you uploaded via the OSS process.
                ///
                ///For more information, see the Upload Issue Attachment tutorial.
                /// </value>
                [DataMember(Name = "fileName", EmitDefaultValue = false)]
                public string FileName { get; set; }

                /// <summary>
                ///The type of attachment to create. Set to issue-attachment. Will always be: issue-attachment
                /// </summary>
                /// <value>
                ///The type of attachment to create. Set to issue-attachment. Will always be: issue-attachment
                /// </value>
                [DataMember(Name = "attachmentType", EmitDefaultValue = true)]
                public string AttachmentType { get; set; }

                /// <summary>
                ///The Object Storage Service (OSS) URN that uniquely identifies where the file is stored in Autodesk’s cloud infrastructure. You obtain this value after uploading the file to OSS (see the Upload Issue Attachment tutorial) or by retrieving it from an existing attachment (see the Downloading Issue Attachments tutorial).
                /// </summary>
                /// <value>
                ///The Object Storage Service (OSS) URN that uniquely identifies where the file is stored in Autodesk’s cloud infrastructure. You obtain this value after uploading the file to OSS (see the Upload Issue Attachment tutorial) or by retrieving it from an existing attachment (see the Downloading Issue Attachments tutorial).
                /// </value>
                [DataMember(Name = "storageUrn", EmitDefaultValue = false)]
                public string StorageUrn { get; set; }

                /// <summary>
                ///The size of the file in bytes.
                /// </summary>
                /// <value>
                ///The size of the file in bytes.
                /// </value>
                [DataMember(Name = "fileSize", EmitDefaultValue = false)]
                public int FileSize { get; set; }

                /// <summary>
                ///The file extension (without the dot), for example pdf or jpg.
                /// </summary>
                /// <value>
                ///The file extension (without the dot), for example pdf or jpg.
                /// </value>
                [DataMember(Name = "fileType", EmitDefaultValue = false)]
                public string FileType { get; set; }

                /// <summary>
                ///The ID of the issue that owns the attachment.
                /// </summary>
                /// <value>
                ///The ID of the issue that owns the attachment.
                /// </value>
                [DataMember(Name = "domainEntityId", EmitDefaultValue = false)]
                public string DomainEntityId { get; set; }

                /// <summary>
                ///The document lineage URN for the attachment’s source file.
                /// </summary>
                /// <value>
                ///The document lineage URN for the attachment’s source file.
                /// </value>
                [DataMember(Name = "lineageUrn", EmitDefaultValue = false)]
                public string LineageUrn { get; set; }

                /// <summary>
                ///The document version number.
                /// </summary>
                /// <value>
                ///The document version number.
                /// </value>
                [DataMember(Name = "version", EmitDefaultValue = false)]
                public int VarVersion { get; set; }

                /// <summary>
                ///The URN for the specific file version that was attached to the issue. This may differ from the latest version URN (tipVersionUrn) if a newer version of the file exists in Autodesk Docs.
                /// </summary>
                /// <value>
                ///The URN for the specific file version that was attached to the issue. This may differ from the latest version URN (tipVersionUrn) if a newer version of the file exists in Autodesk Docs.
                /// </value>
                [DataMember(Name = "versionUrn", EmitDefaultValue = false)]
                public string VersionUrn { get; set; }

                /// <summary>
                ///The URN for the latest (tip) version of the file.
                /// </summary>
                /// <value>
                ///The URN for the latest (tip) version of the file.
                /// </value>
                [DataMember(Name = "tipVersionUrn", EmitDefaultValue = false)]
                public string TipVersionUrn { get; set; }

                /// <summary>
                ///Not relevant
                /// </summary>
                /// <value>
                ///Not relevant
                /// </value>
                [DataMember(Name = "bubbleUrn", EmitDefaultValue = false)]
                public string BubbleUrn { get; set; }

                /// <summary>
                ///The ID of the user who created the issue attachment. For details about the user, call GET users.
                /// </summary>
                /// <value>
                ///The ID of the user who created the issue attachment. For details about the user, call GET users.
                /// </value>
                [DataMember(Name = "createdBy", EmitDefaultValue = false)]
                public string CreatedBy { get; set; }

                /// <summary>
                ///The date and time when the issue attachment was created, in ISO8601 format.
                /// </summary>
                /// <value>
                ///The date and time when the issue attachment was created, in ISO8601 format.
                /// </value>
                [DataMember(Name = "createdOn", EmitDefaultValue = false)]
                public string CreatedOn { get; set; }

                /// <summary>
                ///Not relevant
                /// </summary>
                /// <value>
                ///Not relevant
                /// </value>
                [DataMember(Name = "modifiedBy", EmitDefaultValue = false)]
                public string ModifiedBy { get; set; }

                /// <summary>
                ///Not relevant
                /// </summary>
                /// <value>
                ///Not relevant
                /// </value>
                [DataMember(Name = "modifiedOn", EmitDefaultValue = false)]
                public string ModifiedOn { get; set; }

                /// <summary>
                ///The ID of the user who deleted the issue attachment, if applicable. For details about the user, call GET users.
                /// </summary>
                /// <value>
                ///The ID of the user who deleted the issue attachment, if applicable. For details about the user, call GET users.
                /// </value>
                [DataMember(Name = "deletedBy", EmitDefaultValue = false)]
                public string DeletedBy { get; set; }

                /// <summary>
                ///The date and time when the issue attachment was deleted, if applicable.
                /// </summary>
                /// <value>
                ///The date and time when the issue attachment was deleted, if applicable.
                /// </value>
                [DataMember(Name = "deletedOn", EmitDefaultValue = false)]
                public string DeletedOn { get; set; }

                /// <summary>
                ///true: The attachment has been deleted.
                ///false: (default) The attachment has not been deleted.
                /// </summary>
                /// <value>
                ///true: The attachment has been deleted.
                ///false: (default) The attachment has not been deleted.
                /// </value>
                [DataMember(Name = "isDeleted", EmitDefaultValue = false)]
                public bool IsDeleted { get; set; }

                /// <summary>
                /// Returns the string presentation of the object
                /// </summary>
                /// <returns>String presentation of the object</returns>
                public override string ToString()
                {
                        return JsonConvert.SerializeObject(this, Formatting.Indented);
                }
        }

}
