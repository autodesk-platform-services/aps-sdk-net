using Autodesk.Oss;
using Autodesk.Oss.Model;
using Autodesk.SDKManager;

namespace Samples
{
      class OSS
      {
            string token = "<token>";
            string bucketKey = "<bucket key>";
            string objectKey = "<object key>";
            string sourceToUpload = "<path to source file>";//sourceToUpload can also be a stream object
            string filePath ="<path to source file>";

            string hash ="<hash>";
            string newObjName ="<newObjName>";

            OssClient ossClient = null!;

        public void Initialise()
            {
                  // Optionally initialise SDKManager to pass custom configurations, logger, etc. 
                  // SDKManager sdkManager = SdkManagerBuilder.Create().Build();
            
                  // Instantiate OssClient using the auth provider
                  StaticAuthenticationProvider staticAuthenticationProvider = new StaticAuthenticationProvider(token);
                  ossClient = new OssClient(authenticationProvider:staticAuthenticationProvider);
            }


            public async Task GetBucketDetailsAsync()
            {
                  Bucket bucket = await ossClient.GetBucketDetailsAsync( bucketKey);
                  // query for required properties
                  string bucketkey = bucket.BucketKey;
                  string bucketOwner = bucket.BucketOwner;
                  Console.Write(bucket);
            }


            public async Task Upload()
            {
                  //The below helper method takes care of the complete upload process, i.e. 
                  // the steps 2 to 4 in this link (https://aps.autodesk.com/en/docs/data/v2/tutorials/app-managed-bucket/)

                  //sourceToUpload can be either file path or stream of the object 
                  ObjectDetails objectDetails = await ossClient.Upload(bucketKey, objectKey, sourceToUpload);
                  // query for required properties
                  string objectId = objectDetails.ObjectId;
                  string objectkey = objectDetails.ObjectKey;
                  Console.Write(objectDetails);

            }
            public async Task Download()
            {
                  //The below helper method takes care of the complete Download process, i.e.
                  await ossClient.Download(bucketKey, objectKey, filePath);
            }

            public async Task GetBucketsAsync() {

                  Buckets response = await ossClient.GetBucketsAsync();
                  Console.Write(response);
            }
            public async Task BatchSignedS3UploadAsync() { 

                  var uploadObject = new Batchsigneds3uploadObject
                  {
                        Requests = new List<Batchsigneds3uploadObjectRequests>
                        {
                              new Batchsigneds3uploadObjectRequests
                              {
                              ObjectKey = objectKey,
                              FirstPart = 1,
                              Parts = 5,
                              UploadKey = "" // Start a new upload
                              }
                        }
                  };
            
                  Batchsigneds3uploadResponse response = await ossClient.BatchSignedS3UploadAsync(bucketKey,uploadObject);
                  Console.Write(response);

            }

            public async Task CopyToAsync() {

                  ObjectDetails response = await ossClient.CopyToAsync(bucketKey, objectKey, newObjName);
                  Console.Write(response);
            }

            public async Task CreateBucketAsync() {
            
                  Bucket response = await ossClient.CreateBucketAsync(Region.US , new (){
                              BucketKey=bucketKey,
                              PolicyKey=PolicyKey.Temporary});
                  Console.Write(response);
            }

            public async Task CreateSignedResourceAsync() {
                  
                  CreateObjectSigned response = await ossClient.CreateSignedResourceAsync(bucketKey, objectKey, new(){

                  MinutesExpiration=3,
                  SingleUse=true                  
                        
                  });
                  Console.Write(response);
            }

            public async Task DeleteBucketAsync() {
                  
                  var response = await ossClient.DeleteBucketAsync(bucketKey);
                  Console.Write(response);
            }
            
            public async Task DeleteObjectAsync() {
                  
                  var response = await ossClient.DeleteObjectAsync(bucketKey,objectKey);
                  Console.Write(response);
            }
            
            public async Task DeleteSignedResourceAsync() {
                  
                  var response = await ossClient.DeleteSignedResourceAsync( hash);
                  Console.Write(response);
            }

            async Task GetObjectDetailsAsync() {
                  
                  ObjectFullDetails response = await ossClient.GetObjectDetailsAsync(bucketKey,objectKey);
                  Console.Write(response);
            }

            async Task GetObjectsAsync() {
                  
                  BucketObjects response = await ossClient.GetObjectsAsync(bucketKey);
                  Console.Write(response);
            }

            async Task GetSignedResourceAsync() {
                  
                  Stream response = await ossClient.GetSignedResourceAsync( hash);
                  Console.Write(response);
            }

            async Task SignedS3DownloadAsync() {
                  
                  Signeds3downloadResponse response = await ossClient.SignedS3DownloadAsync( bucketKey, objectKey);
                  Console.Write(response);
            }

            public async void Main()
            {

                  // Initialise SDKManager & OSSClient
                  Initialise();
                  // Call respective methods
                  await GetBucketDetailsAsync();
                  await Upload();
                  await Download();
                  await GetBucketsAsync();
                  await CopyToAsync();
                  await BatchSignedS3UploadAsync();
                  await CreateBucketAsync();
                  await CreateSignedResourceAsync();
                  await DeleteBucketAsync();
                  await DeleteObjectAsync();
                  await GetObjectDetailsAsync();
                  await GetObjectsAsync();
                  await GetSignedResourceAsync();
                  await SignedS3DownloadAsync();
            }
      }
}