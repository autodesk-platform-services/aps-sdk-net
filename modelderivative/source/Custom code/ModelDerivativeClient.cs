using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Autodesk.ModelDerivative.Http;
using Autodesk.ModelDerivative.Model;
using Autodesk.SDKManager;
using Newtonsoft.Json;


namespace Autodesk.ModelDerivative
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ModelDerivativeClient : BaseClient
    {

        /// <summary>
        /// Gets the instance of the IDerivativesApi interface.
        /// </summary>
        public IDerivativesApi DerivativesApi { get; }
        /// <summary>
        /// Gets the instance of the IInformationalApi interface.
        /// </summary>
        public IInformationalApi InformationalApi { get; }
        /// <summary>
        /// Gets the instance of the IJobsApi interface.
        /// </summary>
        public IJobsApi JobsApi { get; }
        /// <summary>
        /// Gets the instance of the IManifestApi interface.
        /// </summary>
        public IManifestApi ManifestApi { get; }
        /// <summary>
        /// Gets the instance of the IMetadataApi interface.
        /// </summary>
        public IMetadataApi MetadataApi { get; }
        /// <summary>
        /// Gets the instance of the IThumbnailsApi interface.
        /// </summary>
        public IThumbnailsApi ThumbnailsApi { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelDerivativeClient"/> class.
        /// </summary>
        /// <param name="sdkManager">The SDK manager.</param>
        /// <param name="authenticationProvider">The authentication provider.</param>
        public ModelDerivativeClient(SDKManager.SDKManager sdkManager = default, IAuthenticationProvider authenticationProvider = default)
            : base(authenticationProvider)
        {
            if (sdkManager == null)
            {
                sdkManager = SdkManagerBuilder.Create().Build();
            }
            this.DerivativesApi = new DerivativesApi(sdkManager);
            this.InformationalApi = new InformationalApi(sdkManager);
            this.JobsApi = new JobsApi(sdkManager);
            this.ManifestApi = new ManifestApi(sdkManager);
            this.MetadataApi = new MetadataApi(sdkManager);
            this.ThumbnailsApi = new ThumbnailsApi(sdkManager);
        }

        #region Informational

        /// <summary>
        /// List Supported Formats
        /// </summary>
        /// <remarks>
        ///Returns an up-to-date list of supported translations. This operation also provides information on the types of derivatives that can be generated for each source design file type. Furthermore, it allows you to obtain a list of translations that have changed since a specified date.
        ///
        ///See the [Supported Translation Formats table](/en/docs/model-derivative/v2/overview/supported-translations) for more details.
        ///
        ///**Note:** We keep adding new file formats to our supported translations list, constantly.
        /// </remarks>
        /// <exception cref="ModelDerivativeApiException">Thrown when fails to make API call</exception>
        /// <param name="ifModifiedSince">
        ///Specifies a date in the `Day of the week, DD Month YYYY HH:MM:SS GMT` format. The response will contain only the formats modified since the specified date and time. If you specify an invalid date, the response will contain all supported formats. If no changes have been made after the specified date, the service returns HTTP status `304`, NOT MODIFIED. (optional)
        /// </param>
        /// <param name="acceptEncoding">
        ///A comma separated list of the algorithms you want the response to be encoded in, specified in the order of preference.  
        ///
        ///If you specify `gzip` or `*`, content is compressed and returned in gzip format. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of SupportedFormats</returns>
        public async System.Threading.Tasks.Task<SupportedFormats> GetFormatsAsync(string ifModifiedSince = default, string acceptEncoding = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.InformationalApi.GetFormatsAsync(ifModifiedSince, acceptEncoding, accessToken, throwOnError);
            return response.Content;

        }
        #endregion Informational

        /// <summary>
        /// Create Translation Job
        /// </summary>
        /// <remarks>
        ///Creates a job to translate the specified source design to another format, generating derivatives of the source design. You can optionaly:
        ///
        ///- Extract selected parts of a design and export the set of geometries in OBJ format.
        ///- Generate different-sized thumbnails.
        ///
        ///When the translation job runs, details about the process and generated derivatives are logged to a JSON file known as a manifest. This manifest is typically created during the first translation of a source design. Subsequently, the system updates the same manifest whenever a translation is performed for that design. 
        ///
        ///If necessary, you can set the `x-ads-force` parameter to `true`. Then, the system will delete the existing manifest and create a new one. However, be aware that doing so will also delete all previously generated derivatives.
        /// </remarks>
        /// <exception cref="ModelDerivativeApiException">Thrown when fails to make API call</exception>
        /// <param name="xAdsForce">
        ///`true`: Forces the system to parse property data all over again. Use this option to retrieve an object tree when previous attempts have failed.
        ///
        ///`false`: (Default) Use previously parsed property data to extract the object tree. (optional)
        /// </param>
        /// <param name="xAdsDerivativeFormat">
        ///Specifies what Object IDs to return, if the design has legacy SVF derivatives generated by the BIM Docs service. Possible values are:  
        ///
        ///- `latest` - (Default) Return SVF2 Object IDs. 
        ///- `fallback` - Return SVF Object IDs.  
        ///
        ///**Note:**  
        ///
        ///1. This parameter applies only to designs with legacy SVF derivatives generated by the BIM 360 Docs service. 
        ///2. The BIM 360 Docs service now generates SVF2 derivatives. SVF2 Object IDs may not be compatible with the SVF Object IDs previously generated by the BIM 360 Docs service. Setting this header to fallback may resolve backward compatibility issues resulting from Object IDs of legacy SVF derivatives being retained on the client side. 
        ///3. If you use this parameter with one derivative (URN), you must use it consistently across the following: 
        ///
        ///   - [Create Translation Job](en/docs/model-derivative/v2/reference/http/job-POST) (for OBJ output) 
        ///   - [Fetch Object Tree](en/docs/model-derivative/v2/reference/http/urn-metadata-modelguid-GET)
        ///   - [Fetch All Properties](en/docs/model-derivative/v2/reference/http/urn-metadata-guid-properties-GET) (optional)
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives must be stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for European Union, Middle East, and Africa.
        ///- `APAC` - (Beta) Data center for the Australia region.
        ///
        ///**Note:** 
        ///
        ///1. Beta features are subject to change. Please avoid using them in production environments.
        ///2. Calling this operation twice for the same source design with different values for this parameter creates two distinct sets of manifests and derivatives. Each set is stored in the respective region. (optional)
        /// </param>
        /// <param name="jobPayload">
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of Job</returns>
        #region Jobs
        public async System.Threading.Tasks.Task<Job> StartJobAsync(JobPayload jobPayload, Region region = default, bool xAdsForce = default, XAdsDerivativeFormat xAdsDerivativeFormat = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.JobsApi.StartJobAsync(xAdsForce, xAdsDerivativeFormat, region, jobPayload, accessToken, throwOnError);
            return response.Content;
        }


        /// <summary>
        /// Specify References
        /// </summary>
        /// <remarks>
        ///Specifies the location of the files referenced by the specified source design.
        ///
        ///When you call [Create Translation Job](/en/docs/model-derivative/v2/reference/http/job-POST), set  `checkReferences` to `true`.   The Model Derivative service will then use the details you specify in this operation to locate and download the referenced files.
        /// </remarks>
        /// <exception cref="ModelDerivativeApiException">Thrown when fails to make API call</exception>
        /// <param name="urn">
        ///The Base64 (URL Safe) encoded design URN.
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `APAC` - (Beta) Data center for the Australia region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <param name="referencesPayload">
        /// (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of SpecifyReferences</returns>
        public async System.Threading.Tasks.Task<SpecifyReferences> SpecifyReferencesAsync(string urn, SpecifyReferencesPayload referencesPayload, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.JobsApi.SpecifyReferencesAsync(urn, region, referencesPayload, accessToken, throwOnError);
            return response.Content;
        }
        #endregion Jobs

        #region Manifest

        /// <summary>
        /// Fetch Manifest
        /// </summary>
        /// <remarks>
        ///Retrieves the manifest of the specified source design.
        ///
        ///The manifest is a JSON file containing information about all the derivatives translated from the specified source design. It contains information such as the URNs of the derivatives, the translation status of each derivative, and much more.
        ///
        ///The first time you translate a source design, the Model Derivative service creates a manifest for that design. Thereafter, every time you translate that source design, even to a different format, the Model Derivative service updates the same manifest. It does not create a new manifest. Instead, the manifest acts like a central registry for all the derivatives of your source design created through the Model Derivative service.  
        ///
        ///When the Model Derivative service starts a translation job (as a result of a request you make using [Create Translation Job](/en/docs/model-derivative/v2/reference/http/jobs/job-POST/)), it keeps on updating the manifest at regular intervals. So, you can use the manifest to check the status and progress of each derivative that is being generated. When multiple derivatives have been requested each derivative may complete at a different time. So, each derivative has its own `status` attribute. The manifest also contains an overall `status` attribute. The overall `status` becomes `complete` when the `status` of all individual derivatives become complete.
        ///
        ///Once the translation status of a derivative is `complete` you can download the derivative.
        ///
        ///**Note:** You cannot download 3D SVF2 derivatives.
        /// </remarks>
        /// <exception cref="ModelDerivativeApiException">Thrown when fails to make API call</exception>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="acceptEncoding">
        ///A comma separated list of the algorithms you want the response to be encoded in, specified in the order of preference.  
        ///
        ///If you specify `gzip` or `*`, content is compressed and returned in gzip format. (optional)
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `APAC` - (Beta) Data center for the Australia region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of Manifest</returns>
        public async System.Threading.Tasks.Task<Manifest> GetManifestAsync(string urn, Region region = default, string acceptEncoding = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ManifestApi.GetManifestAsync(urn, acceptEncoding, region, accessToken, throwOnError);
            return response.Content;
        }


        /// <summary>
        /// Delete Manifest
        /// </summary>
        /// <remarks>
        ///Deletes the manifest of the specified source design. It also deletes all derivatives (translated output files) generated from the source design. However, it does not delete the source design.
        ///
        ///**Note:** This operation is idempotent. So, if you call it multiple times, even when no manifest exists, will still return a successful response (200).
        /// </remarks>
        /// <exception cref="ModelDerivativeApiException">Thrown when fails to make API call</exception>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `APAC` - (Beta) Data center for the Australia region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of DeleteManifest</returns>
        public async System.Threading.Tasks.Task<DeleteManifest> DeleteManifestAsync(string urn, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ManifestApi.DeleteManifestAsync(urn, region, accessToken, throwOnError);
            return response.Content;
        }

        #endregion Manifest


        #region Derivatives

        /// <summary>
        /// Fetch Derivative Download URL
        /// </summary>
        /// <remarks>
        ///Returns a download URL and a set of signed cookies, which lets you securely download the derivative specified by the `derivativeUrn` URI parameter. The signed cookies have a lifetime of 6 hours. You can use range headers with the returned download URL to download the derivative in chunks, in parallel.
        /// </remarks>
        /// <exception cref="ModelDerivativeApiException">Thrown when fails to make API call</exception>
        /// <param name="derivativeUrn">
        ///The URL-encoded URN of the derivative. Use the [Fetch Manifest operation](/en/docs/model-derivative/v2/reference/http/manifest/urn-manifest-GET/)to obtain the URNs of derivatives for the specified source design.
        /// </param>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="minutesExpiration">
        ///Specifies how many minutes the signed cookies should remain valid. Default value is 360 minutes. The value you specify must be lower than the default value for this parameter. If you specify a value greater than the default value, the Model Derivative service will return an error with an HTTP status code of `400`. (optional)
        /// </param>
        /// <param name="responseContentDisposition">
        ///The value that must be specified as the `response-content-disposition` query string parameter with the download URL. Must begin with `attachment`. This value defaults to the default value corresponding to the derivative/file. (optional)
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `APAC` - (Beta) Data center for the Australia region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of DerivativeDownload</returns>

        public async System.Threading.Tasks.Task<DerivativeDownload> GetDerivativeUrlAsync(string derivativeUrn, string urn, Region region = default, int minutesExpiration = default, string responseContentDisposition = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.DerivativesApi.GetDerivativeUrlAsync(derivativeUrn, urn, minutesExpiration, responseContentDisposition, region, accessToken, throwOnError);
            if (response.HttpResponse.Headers != null)
            {
                response.HttpResponse.Headers.TryGetValues("Set-Cookie", out var setCookies);
                var cookieValues = setCookies.Select(x => x.Substring(x.IndexOf("=") + 1, (x.IndexOf(";") - 1 - x.IndexOf("="))));
                var url = new UriBuilder(response.Content.Url)
                {
                    Query = $"Policy={cookieValues.ElementAt(0)}&Key-Pair-Id={cookieValues.ElementAt(1)}&Signature={cookieValues.ElementAt(2)}"
                };
                response.Content.Url = url.ToString();
            }
            return response.Content;
        }

        /// <summary>
        /// Check Derivative Details
        /// </summary>
        /// <remarks>
        ///Returns information about the specified derivative.
        ///
        ///Use this operation to determine the total content length of a derivative before you download it. If the derivative is large, you can choose to download the derivative in chunks, by specifying a chunk size using the `Range` header parameter.
        /// </remarks>
        /// <exception cref="ModelDerivativeApiException">Thrown when fails to make API call</exception>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="derivativeUrn">
        ///The URL-encoded URN of the derivative. Check the manifest of the source design to get the URNs of the derivatives available for download.
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `APAC` - (Beta) Data center for the Australia region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> HeadCheckDerivativeAsync(string urn, string derivativeUrn, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.DerivativesApi.HeadCheckDerivativeAsync(urn, derivativeUrn, region, accessToken, throwOnError);
            return response;
        }
        #endregion Derivatives

        #region Thumbnail

        /// <summary>
        /// Fetch Thumbnail
        /// </summary>
        /// <remarks>
        ///Downloads a thumbnail of the specified source design.
        /// </remarks>
        /// <exception cref="ModelDerivativeApiException">Thrown when fails to make API call</exception>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="width">
        ///Width of thumbnail in pixels.  
        ///
        ///Possible values are: `100`, `200`, `400`  
        ///
        ///If `width` is omitted, but `height` is specified, `width` defaults to `height`. If both `width` and `height` are omitted, the server will return a thumbnail closest to `200`, if such a thumbnail is available. (optional)
        /// </param>
        /// <param name="height">
        ///Height of thumbnails.
        ///
        ///Possible values are: `100`, `200`, `400`.
        ///
        ///If `height` is omitted, but `width` is specified, `height` defaults to `width`.  If both `width` and `height` are omitted, the server will return a thumbnail closest to `200`, if such a thumbnail is available. (optional)
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `APAC` - (Beta) Data center for the Australia region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of System.IO.Stream</returns>
        public async System.Threading.Tasks.Task<System.IO.Stream> GetThumbnailAsync(string urn, Width width = Width.NUMBER_200, Height height = Height.NUMBER_200, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ThumbnailsApi.GetThumbnailAsync(urn, region, width, height, accessToken, throwOnError);
            return response.Content;
        }
        #endregion Thumbnail



        #region MetaData
        /// <summary>
        /// List Model Views
        /// </summary>
        /// <remarks>
        ///Returns a list of Model Views (Viewables) in the source design specified by the `urn` parameter. It also returns an ID that uniquely identifies the Model View. You can use these IDs with other metadata operations to obtain information about the objects within those Model Views.
        ///
        ///Designs created with applications like Fusion 360 and Inventor contain only one Model View per design. Applications like Revit allow multiple Model Views per design.
        ///
        ///**Note:** You can retrieve metadata only from a design that has already been translated to SVF or SVF2.
        /// </remarks>
        /// <exception cref="ModelDerivativeApiException">Thrown when fails to make API call</exception>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="acceptEncoding">
        ///A comma separated list of the algorithms you want the response to be encoded in, specified in the order of preference.  
        ///
        ///If you specify `gzip` or `*`, content is compressed and returned in gzip format. (optional)
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `APAC` - (Beta) Data center for the Australia region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ModelViews</returns>

        public async System.Threading.Tasks.Task<ModelViews> GetModelViewsAsync(string urn, Region region = default, string acceptEncoding = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.MetadataApi.GetModelViewsAsync(urn, acceptEncoding, region, accessToken, throwOnError);
            return response.Content;
        }

        /// <summary>
        /// Fetch Object tree
        /// </summary>
        /// <remarks>
        ///Retrieves the structured hierarchy of objects, known as an object tree, from the specified Model View (Viewable) within the specified source design. The object tree represents the arrangement and relationships of various objects present in that Model View.
        ///
        ///**Note:** A design file must be translated to SVF or SVF2 before you can retrieve its object tree.  
        ///
        ///Before you call this operation:
        ///
        ///- Use the [List Model Views](/en/docs/model-derivative/v2/reference/http/metadata/urn-metadata-GET/) operation to obtain the list of Model Views in the source design.
        ///- Pick the ID of the Model View you want to query and specify that ID as the value for the `modelGuid`  parameter.
        /// </remarks>
        /// <exception cref="ModelDerivativeApiException">Thrown when fails to make API call</exception>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="modelGuid">
        ///The ID of the Model View you are extracting the object tree from. Use the [List Model Views](/en/docs/model-derivative/v2/reference/http/metadata/urn-metadata-GET) operation to get the IDs of the Model Views in the source design.
        /// </param>
        /// <param name="acceptEncoding">
        ///A comma separated list of the algorithms you want the response to be encoded in, specified in the order of preference.  
        ///
        ///If you specify `gzip` or `*`, content is compressed and returned in gzip format. (optional)
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `APAC` - (Beta) Data center for the Australia region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <param name="xAdsForce">
        ///`true`: Forces the system to parse property data all over again. Use this option to retrieve an object tree when previous attempts have failed.
        ///
        ///`false`: (Default) Use previously parsed property data to extract the object tree. (optional)
        /// </param>
        /// <param name="xAdsDerivativeFormat">
        ///Specifies what Object IDs to return, if the design has legacy SVF derivatives generated by the BIM Docs service. Possible values are:  
        ///
        ///- `latest` - (Default) Return SVF2 Object IDs. 
        ///- `fallback` - Return SVF Object IDs.  
        ///
        ///**Note:**  
        ///
        ///1. This parameter applies only to designs with legacy SVF derivatives generated by the BIM 360 Docs service. 
        ///2. The BIM 360 Docs service now generates SVF2 derivatives. SVF2 Object IDs may not be compatible with the SVF Object IDs previously generated by the BIM 360 Docs service. Setting this header to fallback may resolve backward compatibility issues resulting from Object IDs of legacy SVF derivatives being retained on the client side. 
        ///3. If you use this parameter with one derivative (URN), you must use it consistently across the following: 
        ///
        ///   - [Create Translation Job](/en/docs/model-derivative/v2/reference/http/job-POST) (for OBJ output) 
        ///   - [Fetch Object Tree](/en/docs/model-derivative/v2/reference/http/urn-metadata-modelguid-GET)
        ///   - [Fetch All Properties](/en/docs/model-derivative/v2/reference/http/urn-metadata-guid-properties-GET)
        ///   - [Fetch Specific Properties](en/docs/model-derivative/v2/reference/http/metadata/urn-metadata-guid-properties-query-POST) (optional)
        /// </param>
        /// <param name="forceget">
        ///`true`: Retrieves large resources, even beyond the 20 MB limit. If exceptionally large (over 800 MB), the system acts as if `forceget` is `false`. 
        ///
        ///`false`: (Default) Does not retrieve resources if they are larger than 20 MB. (optional)
        /// </param>
        /// <param name="objectid">
        ///If specified, retrieves the sub-tree that has the specified Object ID as its parent node. If this parameter is not specified, retrieves the entire object tree. (optional)
        /// </param>
        /// <param name="level">
        ///Specifies how many child levels of the hierarchy to return, when the `objectid`  parameter is specified. Currently supports only `level` = `1`. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ObjectTree</returns>
        public async System.Threading.Tasks.Task<ObjectTree> GetObjectTreeAsync(string urn, string modelGuid, Region region = default, string acceptEncoding = default, bool xAdsForce = default, XAdsDerivativeFormat xAdsDerivativeFormat = default, string forceget = default, int objectid = default, string level = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.MetadataApi.GetObjectTreeAsync(urn, modelGuid, acceptEncoding, region, xAdsForce, xAdsDerivativeFormat, forceget, objectid, level, accessToken, throwOnError);
            if (response.HttpResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
                return (new ObjectTree() { IsProcessing = true });
            return response.Content;
        }


        /// <summary>
        /// Fetch All Properties
        /// </summary>
        /// <remarks>
        ///Returns a list of properties of all objects in the  Model View specified by the `modelGuid` parameter. 
        ///
        ///This operation returns properties of all objects by default. However, you can restrict the results to a specific object by specifying its ID as the `objectid` parameter.
        ///
        ///Properties are returned as a flat list, ordered, by their `objectid`. The `objectid` is a non-persistent ID assigned to an object when the source design is translated to the SVF or SVF2 format. This means that:
        ///
        ///- A design file must be translated to SVF or SVF2 before you can retrieve properties.
        ///- The `objectid` of an object can change if the design is translated to SVF or SVF2 again. If you require a persistent ID across translations, use `externalId` to reference objects, instead of `objectid`.
        ///
        ///Before you call this operation:
        ///
        ///- Use the [List Model Views](/en/docs/model-derivative/v2/reference/http/metadata/urn-metadata-GET/) operation to obtain the list of Model Views (Viewables) in the source design. 
        ///- Pick the ID of the Model View you want to query and specify that ID as the value for the `modelGuid` parameter.
        ///
        ///**Tip**: Use [Fetch Specific Properties](/en/docs/model-derivative/v2/reference/http/metadata/urn-metadata-guid-properties-query-POST/) to retrieve only the objects and properties of interest. What’s more, the response is paginated. So, when the number of properties returned is large, responses start arriving more promptly.
        /// </remarks>      
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="modelGuid">
        ///The ID of the Model View you are querying. Use the [List Model Views](/en/docs/model-derivative/v2/reference/http/metadata/urn-metadata-GET) operation to get the IDs of the Model Views in the source design.
        /// </param>
        /// <param name="acceptEncoding">
        ///A comma separated list of the algorithms you want the response to be encoded in, specified in the order of preference.  
        ///
        ///If you specify `gzip` or `*`, content is compressed and returned in gzip format. (optional)
        /// </param>
        /// <param name="xAdsForce">
        ///`true`: Forces the system to parse property data all over again. Use this option to retrieve an object tree when previous attempts have failed.
        ///
        ///`false`: (Default) Use previously parsed property data to extract the object tree. (optional)
        /// </param>
        /// <param name="xAdsDerivativeFormat">
        ///Specifies what Object IDs to return, if the design has legacy SVF derivatives generated by the BIM Docs service. Possible values are:  
        ///
        ///- `latest` - (Default) Return SVF2 Object IDs. 
        ///- `fallback` - Return SVF Object IDs.  
        ///
        ///**Note:**  
        ///
        ///1. This parameter applies only to designs with legacy SVF derivatives generated by the BIM 360 Docs service. 
        ///2. The BIM 360 Docs service now generates SVF2 derivatives. SVF2 Object IDs may not be compatible with the SVF Object IDs previously generated by the BIM 360 Docs service. Setting this header to fallback may resolve backward compatibility issues resulting from Object IDs of legacy SVF derivatives being retained on the client side. 
        ///3. If you use this parameter with one derivative (URN), you must use it consistently across the following: 
        ///
        ///   - [Create Translation Job](/en/docs/model-derivative/v2/reference/http/job-POST) (for OBJ output) 
        ///   - [Fetch Object Tree](/en/docs/model-derivative/v2/reference/http/urn-metadata-modelguid-GET)
        ///   - [Fetch All Properties](/en/docs/model-derivative/v2/reference/http/urn-metadata-guid-properties-GET)
        ///   - [Fetch Specific Properties](en/docs/model-derivative/v2/reference/http/metadata/urn-metadata-guid-properties-query-POST) (optional)
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `APAC` - (Beta) Data center for the Australia region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <param name="objectid">
        ///The Object ID of the object you want to restrict the response to. If you do not specify this parameter, all properties of all objects within the Model View are returned.   (optional)
        /// </param>
        /// <param name="forceget">
        ///`true`: Retrieves large resources, even beyond the 20 MB limit. If exceptionally large (over 800 MB), the system acts as if `forceget` is `false`. 
        ///
        ///`false`: (Default) Does not retrieve resources if they are larger than 20 MB. (optional)
        /// </param>
        /// <exception cref="ModelDerivativeApiException">Thrown when fails to make API call</exception>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of Properties</returns>

        public async System.Threading.Tasks.Task<Properties> GetAllPropertiesAsync(string urn, string modelGuid, Region region = default, string acceptEncoding = default, bool xAdsForce = default, XAdsDerivativeFormat xAdsDerivativeFormat = default, int objectid = default, string forceget = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.MetadataApi.GetAllPropertiesAsync(urn, modelGuid, acceptEncoding, xAdsForce, xAdsDerivativeFormat, region, objectid, forceget, accessToken, throwOnError);
            if (response.HttpResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
                return (new Properties() { IsProcessing = true });
            return response.Content;
        }

        /// <summary>
        /// Fetch Specific Properties
        /// </summary>
        /// <remarks>
        ///Queries the objects in the Model View (Viewable) specified by the `modelGuid` parameter and returns the specified properties in a paginated list. You can limit the number of objects to be queried by specifying a filter using the `query` attribute in the request body.
        ///
        ///**Note:** A design file must be translated to SVF or SVF2 before you can query object properties.  
        ///
        ///Before you call this operation:
        ///
        ///- Use the [List Model Views](/en/docs/model-derivative/v2/reference/http/metadata/urn-metadata-GET/) operation to obtain the list of Model Views in the source design.
        ///- Pick the ID of the Model View you want to query and specify that ID as the value for the `modelGuid`  parameter.
        /// </remarks>
        /// <exception cref="ModelDerivativeApiException">Thrown when fails to make API call</exception>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="modelGuid">
        ///The ID of the Model View you are querying. Use the [List Model Views](/en/docs/model-derivative/v2/reference/http/metadata/urn-metadata-GET) operation to get the IDs of the Model Views in the source design.
        /// </param>
        /// <param name="specificPropertiesPayload">
        ///The payload containing the specific properties to be fetched.
        /// </param>
        /// <param name="acceptEncoding">
        ///A comma separated list of the algorithms you want the response to be encoded in, specified in the order of preference.  
        ///
        ///If you specify `gzip` or `*`, content is compressed and returned in gzip format. (optional)
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `APAC` - (Beta) Data center for the Australia region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <param name="xAdsDerivativeFormat">
        ///Specifies what Object IDs to return, if the design has legacy SVF derivatives generated by the BIM Docs service. Possible values are:  
        ///
        ///- `latest` - (Default) Return SVF2 Object IDs. 
        ///- `fallback` - Return SVF Object IDs.  
        ///
        ///**Note:**  
        ///
        ///1. This parameter applies only to designs with legacy SVF derivatives generated by the BIM 360 Docs service. 
        ///2. The BIM 360 Docs service now generates SVF2 derivatives. SVF2 Object IDs may not be compatible with the SVF Object IDs previously generated by the BIM 360 Docs service. Setting this header to fallback may resolve backward compatibility issues resulting from Object IDs of legacy SVF derivatives being retained on the client side. 
        ///3. If you use this parameter with one derivative (URN), you must use it consistently across the following: 
        ///
        ///   - [Create Translation Job](/en/docs/model-derivative/v2/reference/http/job-POST) (for OBJ output) 
        ///   - [Fetch Object Tree](/en/docs/model-derivative/v2/reference/http/urn-metadata-modelguid-GET)
        ///   - [Fetch All Properties](/en/docs/model-derivative/v2/reference/http/urn-metadata-guid-properties-GET)
        ///   - [Fetch Specific Properties](en/docs/model-derivative/v2/reference/http/metadata/urn-metadata-guid-properties-query-POST) (optional)
        /// </param>  
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of SpecificProperties</returns>
        public async System.Threading.Tasks.Task<SpecificProperties> FetchSpecificPropertiesAsync(string urn, string modelGuid, SpecificPropertiesPayload specificPropertiesPayload, Region region = default, XAdsDerivativeFormat xAdsDerivativeFormat = default, string acceptEncoding = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.MetadataApi.FetchSpecificPropertiesAsync(urn, modelGuid, acceptEncoding, region, xAdsDerivativeFormat, specificPropertiesPayload, accessToken, throwOnError);
            if (response.HttpResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
                return (new SpecificProperties() { IsProcessing = true });
            return response.Content;
        }

        #endregion MetaData






    }

}