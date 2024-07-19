namespace Autodesk.Oss.Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.SDKManager;
using Autodesk.Oss.Model;
using Autodesk.Oss;

[TestClass]
public class TestOss
{

	private static OssClient _ossClient = null!;

	string client_id = "<client_id>";
	string client_secret = "<client_secret>";
	string token = "<token>";
	string bucketKey = "<bucketKey>";
	string objectKey = "<objectKey>";
	string sourceToUpload = "<sourceToUpload>";


	[ClassInitialize]
	public static void ClassInitialize(TestContext testContext)
	{
		SDKManager sdkManager = SdkManagerBuilder
				  .Create() // Creates SDK Manager Builder itself.
				  .Build();

		_ossClient = new OssClient(sdkManager);
	}

	[TestMethod]
	public async Task TestCreateBucketAsync()
	{
		Bucket bucket = await _ossClient.CreateBucketAsync(
			accessToken: token,
			xAdsRegion: Region.US,
			policyKey: new CreateBucketsPayload()
			{
				BucketKey = bucketKey,
				PolicyKey = PolicyKey.Transient,
			});
		Assert.IsNotNull(bucket);
	}

	[TestMethod]
	public async Task TestGetBucketAsync()
	{
		Bucket bucket = await _ossClient.GetBucketDetailsAsync(
			accessToken: token,
			bucketKey: bucketKey);
		Assert.IsNotNull(bucket);
	}

	[TestMethod]
	public async Task TestUploadObjectAsync()
	{
		ObjectDetails objectDetails = await _ossClient.Upload(
			accessToken: token,
			bucketKey: bucketKey,
			objectKey: objectKey,
			sourceToUpload: sourceToUpload,
			cancellationToken: CancellationToken.None);
		Assert.IsNotNull(objectDetails);
	}

	[TestMethod]
	public async Task TestGetObjectAsync()
	{
		ObjectFullDetails objectFullDetails = await _ossClient.GetObjectDetailsAsync(
			accessToken: token,
			bucketKey: bucketKey,
			objectKey: objectKey);
		Assert.IsNotNull(objectFullDetails);
	}

	[TestMethod]
	public async Task TestDeleteObjectAsync()
	{
		HttpResponseMessage response = await _ossClient.DeleteObjectAsync(
			accessToken: token,
			bucketKey: bucketKey,
			objectKey: objectKey);
		Assert.IsTrue(response.IsSuccessStatusCode);
	}
}