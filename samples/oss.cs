using Autodesk.Oss;
using Autodesk.Oss.Model;
using Autodesk.SDKManager;

string token = "<token>";
string bucketKey = "<bucket key>";
string objectName = "<object name>";
string sourceToUpload = "<path to source file>";

// Instantiate SDK manager as below.   
// You can also optionally pass configurations, logger, etc. 
SDKManager sdkManager = SdkManagerBuilder
      .Create() // Creates SDK Manager Builder itself.
      .Build();

OssClient ossClient = new OssClient(sdkManager);

Bucket bucket = await ossClient.GetBucketDetailsAsync(bucketKey, accessToken:token);
// query for required properties
string bucketkey = bucket.BucketKey;
string bucketOwner = bucket.BucketOwner;
        
//The below helper method takes care of the complete upload process, i.e. 
// the steps 2 to 4 in this link (https://aps.autodesk.com/en/docs/data/v2/tutorials/app-managed-bucket/)
ObjectDetails objectDetails = await ossClient.Upload(bucketKey,objectName,sourceToUpload,accessToken:token,CancellationToken.None );
// query for required properties
string objectId =  objectDetails.ObjectId;
string objectKey= objectDetails.ObjectKey;





