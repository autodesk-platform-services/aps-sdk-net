using Autodesk.Oss;
using Autodesk.Oss.Model;
using Autodesk.SDKManager;

namespace Samples
{
      class OSS
      {
            string token = "<token>";
            string bucketKey = "<bucket key>";
            string objectName = "<object name>";
            string sourceToUpload = "<path to source file>";//sourceToUpload can also be a stream object
            string filePath ="<path to source file>";

            string hash ="<hash>";
            OssClient ossClient = null!;


            public void Initialise()
            {
                  // Instantiate SDK manager as below.   
                  // You can also optionally pass configurations, logger, etc. 
                  SDKManager sdkManager = SdkManagerBuilder
                        .Create() // Creates SDK Manager Builder itself.
                        .Build();
                  // Instantiate OssClient using the created SDK manager
                  ossClient = new OssClient(sdkManager);
            }


            public async Task GetBucketDetailsAsync()
            {
                  Bucket bucket = await ossClient.GetBucketDetailsAsync(token, bucketKey);
                  // query for required properties
                  string bucketkey = bucket.BucketKey;
                  string bucketOwner = bucket.BucketOwner;
            }


            public async Task Upload()
            {
                  //The below helper method takes care of the complete upload process, i.e. 
                  // the steps 2 to 4 in this link (https://aps.autodesk.com/en/docs/data/v2/tutorials/app-managed-bucket/)

                  //sourceToUpload can be either file path or stream of the object 
                  ObjectDetails objectDetails = await ossClient.Upload(bucketKey, objectName, sourceToUpload,token);
                  // query for required properties
                  string objectId = objectDetails.ObjectId;
                  string objectKey = objectDetails.ObjectKey;

            }
            public async Task Download()
            {
                  //The below helper method takes care of the complete Download process, i.e.
                  await ossClient.Download(bucketKey, objectName, filePath, token);
            }

            public async function GetBucketsAsync() {

                  const response = await ossClient.GetBucketsAsync(token);
                  console.log(response);
            }
            public async function BatchSignedS3UploadAsync() { 

                  var uploadObject = new Batchsigneds3uploadObject
                  {
                        Requests = new List<Batchsigneds3uploadObjectRequests>
                        {
                              new Batchsigneds3uploadObjectRequests
                              {
                              ObjectKey = objectName,
                              FirstPart = 1,
                              Parts = 5,
                              UploadKey = "" // Start a new upload
                              }
                        }
                  };
            
                  const response = await ossClient.BatchSignedS3UploadAsync(token, bucketKey,uploadObjects);
                  console.log(response);
            }

            public async function CopyToAsync() {

                  const response = await ossClient.CopyToAsync(token, bucketKey, objectKey, newObjName);
                  console.log(response);
            }

            public async function CreateBucketAsync() {
            
                  const response = await ossClient.CreateBucketAsync(token,Region.US , new (){
                              BucketKey=bucketKey,
                              PolicyKey=PolicyKey.Temporary});
                  console.log(response);
            }

            public async function CreateSignedResourceAsync() {
                  
                  const response = await ossClient.CreateSignedResourceAsync(token, bucketkey, objectKey);
                  console.log(response);
            }

            public async function DeleteBucketAsync() {
                  
                  const response = await ossClient.DeleteBucketAsync(token, bucketkey);
                  console.log(response);
            }
            
            public async function DeleteObjectAsync() {
                  
                  const response = await ossClient.DeleteObjectAsync(token,bucketKey,objectName);
                  console.log(response);
            }
            
            public async function DeleteSignedResourceAsync() {
                  
                  const response = await ossClient.DeleteSignedResourceAsync(token, hash);
                  console.log(response);
            }

            async function GetObjectDetailsAsync() {
                  
                  const response = await ossClient.GetObjectDetailsAsync(token,bucketKey,objectName);
                  console.log(response);
            }

            async function GetObjectsAsync() {
                  
                  const response = await ossClient.GetObjectsAsync(token, bucketkey);
                  console.log(response);
            }

            async function GetSignedResourceAsync() {
                  
                  const response = await ossClient.getSignedResource(token, hash);
                  console.log(response);
            }

            async function SignedS3DownloadAsync() {
                  
                  const response = await ossClient.SignedS3DownloadAsync(token, bucketkey, objectName);
                  console.log(response);
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