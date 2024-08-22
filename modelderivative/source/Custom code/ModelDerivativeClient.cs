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
    public class ModelDerivativeClient: BaseClient
    {

        public IDerivativesApi DerivativesApi { get; }
        public IInformationalApi InformationalApi { get; }
        public IJobsApi JobsApi { get; }
        public IManifestApi ManifestApi { get; }
        public IMetadataApi MetadataApi { get; }
        public IThumbnailsApi ThumbnailsApi { get; }
        public ModelDerivativeClient(SDKManager.SDKManager sdkManager = default, IAuthenticationProvider authenticationProvider = default)
            : base(authenticationProvider)
        {
            if( sdkManager == null){
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
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().
        /// </param>
        /// <param name="ifModifiedSince">
        ///Specifies a date in the `Day of the week, DD Month YYYY HH:MM:SS GMT` format. The response will contain only the formats modified since the specified date and time. If you specify an invalid date, the response will contain all supported formats. If no changes have been made after the specified date, the service returns HTTP status `304`, NOT MODIFIED. (optional)
        /// </param>
        /// <param name="acceptEncoding">
        ///A comma separated list of the algorithms you want the response to be encoded in, specified in the order of preference.  
        ///
        ///If you specify `gzip` or `*`, content is compressed and returned in gzip format. (optional)
        /// </param>
        /// <returns>Task of SupportedFormats</returns>
        public async System.Threading.Tasks.Task<SupportedFormats> GetFormatsAsync(string ifModifiedSince = default, string acceptEncoding = default, string accessToken = default, bool throwOnError = true)
        {
            if(String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (this.AuthenticationProvider != null){
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.InformationalApi.GetFormatsAsync(ifModifiedSince, acceptEncoding, accessToken, throwOnError);
            return response.Content;

        }
        #endregion Informational

    }

}