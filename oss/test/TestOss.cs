using Autodesk.SDKManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.Oss.Model;
using System.Net;

namespace Autodesk.Oss.Test;

[TestClass]
public class TestOss
{
	private static OssClient _ossClient = null!;

	string? token = Environment.GetEnvironmentVariable("TWO_LEGGED_ACCESS_TOKEN");
	string? bucketKey = Environment.GetEnvironmentVariable("BUCKET_KEY");
	string? objectKey = Environment.GetEnvironmentVariable("OBJECT_KEY");
	string? newObjName = Environment.GetEnvironmentVariable("NEW_OBJ_NAME");
	string? sourceToUpload = Environment.GetEnvironmentVariable("SOURCE_TO_UPLOAD");
	string? filePath = Environment.GetEnvironmentVariable("FILE_PATH");
	// Signed Url Format: "https://developer.api.autodesk.com/oss/v2/signedresources/<hash>?region=US"
	string? signedUrl = Environment.GetEnvironmentVariable("SIGNED_URL");

	[ClassInitialize]
	public static void ClassInitialize(TestContext testContext)
	{
		var sdkManager = SdkManagerBuilder
			.Create()
			.Add(new ApsConfiguration())
			.Add(ResiliencyConfiguration.CreateDefault())
			.Build();

		_ossClient = new OssClient(sdkManager);
	}

	#region Buckets

	[TestMethod]
	public async Task CreateBucketAsync()
	{
		Bucket bucket = await _ossClient.CreateBucketAsync(
			accessToken: token,
			xAdsRegion: Region.US,
			bucketsPayload: new CreateBucketsPayload()
			{
				BucketKey = bucketKey,
				PolicyKey = PolicyKey.Temporary
			});
		Assert.IsTrue(bucket.BucketKey.Equals(bucketKey));
	}

	[TestMethod]
	public async Task GetBucketDetailsAsync()
	{
		Bucket bucket = await _ossClient.GetBucketDetailsAsync(
			 accessToken: token,
			 bucketKey: bucketKey);
		Assert.IsTrue(bucket.BucketKey.Equals(bucketKey));
	}

	[TestMethod]
	public async Task GetBucketsAsync()
	{
		Buckets buckets = await _ossClient.GetBucketsAsync(accessToken: token);
		Assert.IsInstanceOfType(buckets.Items, typeof(List<BucketsItems>));
	}

	[TestMethod]
	public async Task DeleteBucketAsync()
	{
		HttpResponseMessage httpResponseMessage = await _ossClient.DeleteBucketAsync(
			 accessToken: token,
			 bucketKey: bucketKey);
		Assert.IsTrue(httpResponseMessage.StatusCode == HttpStatusCode.OK);
	}

	#endregion

	#region Objects

	[TestMethod]
	public async Task UploadObjectAsync()
	{
		ObjectDetails objectDetails = await _ossClient.UploadObjectAsync(
			accessToken: token,
			bucketKey: bucketKey,
			objectKey: objectKey,
			sourceToUpload: sourceToUpload,
			cancellationToken: CancellationToken.None);
		Assert.IsTrue(objectDetails.ObjectId.Equals($"urn:adsk.objects:os.object:{bucketKey}/{objectKey}"));
	}

	[TestMethod]
	public async Task CopyToAsync()
	{
		ObjectDetails objectDetails = await _ossClient.CopyToAsync(
			accessToken: token,
			bucketKey: bucketKey,
			objectKey: objectKey,
			newObjName: newObjName);
		Assert.IsTrue(objectDetails.ObjectId.Equals($"urn:adsk.objects:os.object:{bucketKey}/{newObjName}"));
	}

	[TestMethod]
	public async Task DownloadObjectAsync()
	{
		await _ossClient.DownloadObjectAsync(
			accessToken: token,
			bucketKey: bucketKey,
			objectKey: objectKey,
			filePath: filePath,
			cancellationToken: CancellationToken.None);
	}

	[TestMethod]
	public async Task GetObjectDetailsAsync()
	{
		ObjectFullDetails objectFullDetails = await _ossClient.GetObjectDetailsAsync(
			accessToken: token,
			bucketKey: bucketKey,
			objectKey: objectKey);
		Assert.IsTrue(objectFullDetails.ObjectId.Equals($"urn:adsk.objects:os.object:{bucketKey}/{objectKey}"));
	}

	[TestMethod]
	public async Task GetObjectsAsync()
	{
		BucketObjects bucketObjects = await _ossClient.GetObjectsAsync(
			accessToken: token,
			bucketKey: bucketKey);
		Assert.IsInstanceOfType(bucketObjects.Items, typeof(List<ObjectDetails>));
	}

	[TestMethod]
	public async Task DeleteObjectAsync()
	{
		HttpResponseMessage httpResponseMessage = await _ossClient.DeleteObjectAsync(
			accessToken: token,
			bucketKey: bucketKey,
			objectKey: objectKey);
		Assert.IsTrue(httpResponseMessage.StatusCode == HttpStatusCode.OK);
	}

	#endregion

	#region Signed Resources

	[TestMethod]
	public async Task CreateSignedResourceAsync()
	{
		CreateObjectSigned? signedObject = await _ossClient.CreateSignedResourceAsync(
			accessToken: token,
			bucketKey: bucketKey,
			objectKey: objectKey,
			createSignedResource: new()
			{
				MinutesExpiration = 3,
				SingleUse = true
			});
		Assert.IsTrue(signedObject.SignedUrl.StartsWith($"https://developer.api.autodesk.com/oss/v2/signedresources/"));
	}

	[TestMethod]
	public async Task GetSignedResourceAsync()
	{
		string hash = signedUrl[(signedUrl.LastIndexOf('/') + 1)..signedUrl.IndexOf('?')];
		Stream? signedResource = await _ossClient.GetSignedResourceAsync(
			accessToken: token,
			hash: hash);
		Assert.IsNotNull(signedResource);
	}

	[TestMethod]
	public async Task DeleteSignedResourceAsync()
	{
		string hash = signedUrl[(signedUrl.LastIndexOf('/') + 1)..signedUrl.IndexOf('?')];
		HttpResponseMessage httpResponseMessage = await _ossClient.DeleteSignedResourceAsync(
			accessToken: token,
			hash: hash);
		Assert.IsTrue(httpResponseMessage.StatusCode == HttpStatusCode.OK);
	}

	#endregion
}