/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * oss
 *
 * The Object Storage Service (OSS) allows your application to download and upload raw files (such as PDF, XLS, DWG, or RVT) that are managed by the Data service.
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
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
namespace Autodesk.Oss
{
    public interface IOSSFileTransfer
    {
 
        Task<HttpResponseMessage> Upload(
            string bucketKey,
            string objectKey,
            Stream sourceToUpload,
            string accessToken,
            CancellationToken cancellationToken,
            string requestIdPrefix = "",
            IProgress<int> progress = null);
    
        Task<Stream> Download(
            string bucketKey,
            string objectKey,
            string accessToken,
            CancellationToken cancellationToken,
            string filePath = null,
            string requestIdPrefix = "",
            IProgress<int> progress = null);
    }
}