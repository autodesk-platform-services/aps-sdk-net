using Autodesk.ModelDerivative.Http;
using Autodesk.ModelDerivative.Model;


namespace Autodesk.ModelDerivative
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ModelDerivativeClient
    {

        public IDerivativesApi DerivativesApi { get; }
        public IInformationalApi InformationalApi { get; }
        public IJobsApi JobsApi { get; }
        public IManifestApi ManifestApi { get; }
        public IMetadataApi MetadataApi { get; }
        public IThumbnailsApi ThumbnailsApi { get; }
        public ModelDerivativeClient(SDKManager.SDKManager sdkManager)
        {
            this.DerivativesApi = new DerivativesApi(sdkManager);
            this.InformationalApi = new InformationalApi(sdkManager);
            this.JobsApi = new JobsApi(sdkManager);
            this.ManifestApi = new ManifestApi(sdkManager);
            this.MetadataApi = new MetadataApi(sdkManager);
            this.ThumbnailsApi = new ThumbnailsApi(sdkManager);
        }

        #region Informational
        public async System.Threading.Tasks.Task<Formats> GetFormatsAsync(string ifModifiedSince = default, string acceptEncoding = default, string accessToken = null, bool throwOnError = true)
        {

            var response = await this.InformationalApi.GetFormatsAsync(ifModifiedSince, acceptEncoding, accessToken, throwOnError);
            return response.Content;

        }
        #endregion Informational

        #region Jobs
        public async System.Threading.Tasks.Task<Job> StartJobAsync(bool xAdsForce = default, XAdsDerivativeFormat xAdsDerivativeFormat = default, JobPayload jobPayload = default, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.JobsApi.StartJobAsync( xAdsForce, xAdsDerivativeFormat, jobPayload, accessToken, throwOnError);
            return response.Content;
        }

        public async System.Threading.Tasks.Task<SpecifyReferences> SpecifyReferencesAsync (string urn,ReferencesPayload referencesPayload = default, string accessToken = null, bool throwOnError = true)
        {
            var response =  await this.JobsApi.SpecifyReferencesAsync(urn, referencesPayload,accessToken,throwOnError);
            return response.Content;
        }
        #endregion Jobs

        #region Manifest
        public async System.Threading.Tasks.Task<Manifest> GetManifestAsync(string urn, Region region = default, string acceptEncoding = default, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ManifestApi.GetManifestAsync(urn, region, acceptEncoding, accessToken, throwOnError);
            return response.Content;
        }


        public async System.Threading.Tasks.Task<DeleteManifest> DeleteManifestAsync (string urn, Region region = default, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ManifestApi.DeleteManifestAsync(urn,region,accessToken,throwOnError);
            return response.Content;
        }

        #endregion Manifest


        #region Derivatives
        public async System.Threading.Tasks.Task<DerivativeDownload> GetDerivativeUrlAsync(string derivativeUrn, string urn, Region region = default, int minutesExpiration = default, string responseContentDisposition = default, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.DerivativesApi.GetDerivativeUrlAsync(derivativeUrn, urn, region, minutesExpiration, responseContentDisposition, accessToken, throwOnError);
            return response.Content;
        }

        public async System.Threading.Tasks.Task<DerivativeHead> HeadCheckDerivativeAsync(string urn, string derivativeUrn, Region region = default, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.DerivativesApi.HeadCheckDerivativeAsync(urn, derivativeUrn, region, accessToken, throwOnError);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                return (new DerivativeHead() { IsProcessing = true });
            return response;

        }
        #endregion Derivatives

        #region Thumbnail
        public async System.Threading.Tasks.Task<System.IO.Stream> GetThumbnailAsync(string urn, Width width = Width._200, Height height = Height._200, Region region = default, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ThumbnailsApi.GetThumbnailAsync(urn, width, height, region, accessToken, throwOnError);
            return response.Content;
        }
        #endregion Thumbnail

        #region MetaData
        public async System.Threading.Tasks.Task<ModelViews> GetModelViewsAsync(string urn, Region region = default, string acceptEncoding = default, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.MetadataApi.GetModelViewsAsync(urn, region, acceptEncoding, accessToken, throwOnError);
            return response.Content;
        }
        public async System.Threading.Tasks.Task<ObjectTree> GetObjectTreeAsync(string urn, string modelGuid, Region region = default, string acceptEncoding = default, bool xAdsForce = default, XAdsDerivativeFormat xAdsDerivativeFormat = default, string forceget = default, int objectid = default, string level = default, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.MetadataApi.GetObjectTreeAsync(urn, modelGuid, region, acceptEncoding, xAdsForce, xAdsDerivativeFormat, forceget, objectid, level, accessToken, throwOnError);
            if (response.HttpResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
                return (new ObjectTree() { IsProcessing = true });
            return response.Content;
        }


        public async System.Threading.Tasks.Task<AllProperties> GetAllPropertiesAsync(string urn, string modelGuid, Region region = default, string acceptEncoding = default, bool xAdsForce = default, XAdsDerivativeFormat xAdsDerivativeFormat = default, int objectid = default, string forceget = default, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.MetadataApi.GetAllPropertiesAsync(urn, modelGuid, region, acceptEncoding, xAdsForce, xAdsDerivativeFormat, objectid, forceget, accessToken, throwOnError);
            if (response.HttpResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
                return (new AllProperties() { IsProcessing = true });
            return response.Content;
        }

        public async System.Threading.Tasks.Task<SpecificProperties> FetchSpecificPropertiesAsync(string urn, string modelGuid, Region region = default, string acceptEncoding = default, SpecificPropertiesPayload specificPropertiesPayload = default, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.MetadataApi.FetchSpecificPropertiesAsync(urn, modelGuid,  region, acceptEncoding, specificPropertiesPayload, accessToken, throwOnError);
            if (response.HttpResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
                return (new SpecificProperties() { IsProcessing = true });
            return response.Content;
        }

        #endregion MetaData






    }

}