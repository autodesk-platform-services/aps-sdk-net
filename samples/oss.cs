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
                  Bucket bucket = await ossClient.GetBucketDetailsAsync(bucketKey, accessToken: token);
                  // query for required properties
                  string bucketkey = bucket.BucketKey;
                  string bucketOwner = bucket.BucketOwner;
            }


            public async Task Upload()
            {
                  //The below helper method takes care of the complete upload process, i.e. 
                  // the steps 2 to 4 in this link (https://aps.autodesk.com/en/docs/data/v2/tutorials/app-managed-bucket/)

                  //sourceToUpload can be either file path or stream of the object 
                  ObjectDetails objectDetails = await ossClient.Upload(bucketKey, objectName, sourceToUpload, accessToken: token, CancellationToken.None);
                  // query for required properties
                  string objectId = objectDetails.ObjectId;
                  string objectKey = objectDetails.ObjectKey;

            }
            public async Task Download()
            {
                  //The below helper method takes care of the complete Download process, i.e.
                  await ossClient.Download(bucketKey, objectName, filePath, accessToken: token, CancellationToken.None);
            }

            public async void Main()
            {

                  // Initialise SDKManager & OSSClient
                  Initialise();
                  // Call respective methods
                  await GetBucketDetailsAsync();
                  await Upload();
                  await Download();
            }
      }
}