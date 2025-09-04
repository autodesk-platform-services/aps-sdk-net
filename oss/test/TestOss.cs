using Autodesk.Oss.Model;
using Autodesk.SDKManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
	string? xAdsMetaContentType = Environment.GetEnvironmentVariable("XADS_META_CONTENT_TYPE");
	string? xAdsMetaContentDisposition = Environment.GetEnvironmentVariable("XADS_META_CONTENT_DISPOSITION");
	string? xAdsMetaContentEncoding = Environment.GetEnvironmentVariable("XADS_META_CONTENT_ENCODING");
	string? xAdsMetaCacheControl = Environment.GetEnvironmentVariable("XADS_META_CACHE_CONTROL");
	string? xAdsUserDefinedMetadata = Environment.GetEnvironmentVariable("XADS_USER_DEFINED_METADATA");

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
	public async Task TestCreateBucketAsync()
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
	public async Task TestGetBucketDetailsAsync()
	{
		Bucket bucket = await _ossClient.GetBucketDetailsAsync(
			 accessToken: token,
			 bucketKey: bucketKey);
		Assert.IsTrue(bucket.BucketKey.Equals(bucketKey));
	}

	[TestMethod]
	public async Task TestGetBucketsAsync()
	{
		Buckets buckets = await _ossClient.GetBucketsAsync(accessToken: token);
		Assert.IsInstanceOfType(buckets.Items, typeof(List<BucketsItems>));
	}

	[TestMethod]
	public async Task TestDeleteBucketAsync()
	{
		HttpResponseMessage httpResponseMessage = await _ossClient.DeleteBucketAsync(
			 accessToken: token,
			 bucketKey: bucketKey);
		Assert.IsTrue(httpResponseMessage.StatusCode == HttpStatusCode.OK);
	}

	#endregion

	#region Objects

	[TestMethod]
	public async Task TestUploadObjectAsync()
	{
		ObjectDetails objectDetails = await _ossClient.UploadObjectAsync(
			accessToken: token,
			bucketKey: bucketKey,
			objectKey: objectKey,
			sourceToUpload: sourceToUpload,
			cancellationToken: CancellationToken.None,
			xAdsMetaContentType: xAdsMetaContentType,
			xAdsMetaContentDisposition: xAdsMetaContentDisposition,
			xAdsMetaContentEncoding: xAdsMetaContentEncoding,
			xAdsMetaCacheControl: xAdsMetaCacheControl,
			xAdsUserDefinedMetadata: xAdsUserDefinedMetadata);
		Assert.IsTrue(objectDetails.ObjectId.Equals($"urn:adsk.objects:os.object:{bucketKey}/{objectKey}"));
	}

	[TestMethod]
	public async Task TestUploadObjectStreamAsync()
	{
		using var fileStream = File.OpenRead(sourceToUpload);
		ObjectDetails objectDetails = await _ossClient.UploadObjectAsync(
			accessToken: token,
			bucketKey: bucketKey,
			objectKey: objectKey,
			sourceToUpload: fileStream,
			cancellationToken: CancellationToken.None,
			xAdsMetaContentType: xAdsMetaContentType,
			xAdsMetaContentDisposition: xAdsMetaContentDisposition,
			xAdsMetaContentEncoding: xAdsMetaContentEncoding,
			xAdsMetaCacheControl: xAdsMetaCacheControl,
			xAdsUserDefinedMetadata: xAdsUserDefinedMetadata);
		Assert.IsTrue(objectDetails.ObjectId.Equals($"urn:adsk.objects:os.object:{bucketKey}/{objectKey}"));
	}

	[TestMethod]
	public async Task TestCopyToAsync()
	{
		ObjectDetails objectDetails = await _ossClient.CopyToAsync(
			accessToken: token,
			bucketKey: bucketKey,
			objectKey: objectKey,
			newObjName: newObjName);
		Assert.IsTrue(objectDetails.ObjectId.Equals($"urn:adsk.objects:os.object:{bucketKey}/{newObjName}"));
	}

	[TestMethod]
	public async Task TestDownloadObjectAsync()
	{
		await _ossClient.DownloadObjectAsync(
			accessToken: token,
			bucketKey: bucketKey,
			objectKey: objectKey,
			filePath: filePath,
			cancellationToken: CancellationToken.None);
	}

	[TestMethod]
	public async Task TestGetObjectDetailsAsync()
	{
		ObjectFullDetails objectFullDetails = await _ossClient.GetObjectDetailsAsync(
			accessToken: token,
			bucketKey: bucketKey,
			objectKey: objectKey);
		Assert.IsTrue(objectFullDetails.ObjectId.Equals($"urn:adsk.objects:os.object:{bucketKey}/{objectKey}"));
	}

	[TestMethod]
	public async Task TestGetObjectsAsync()
	{
		BucketObjects bucketObjects = await _ossClient.GetObjectsAsync(
			accessToken: token,
			bucketKey: bucketKey);
		Assert.IsInstanceOfType(bucketObjects.Items, typeof(List<ObjectDetails>));
	}

	[TestMethod]
	public async Task TestDeleteObjectAsync()
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
	public async Task TestCreateSignedResourceAsync()
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
	public async Task TestUploadSignedResourcesChunkAsync()
	{
		string sessionId = Guid.NewGuid().ToString();
		var fileInfo = new FileInfo(sourceToUpload!);
		long fileSize = fileInfo.Length;
		const int chunkSize = 5 * 1024 * 1024; // 5MB

		CreateObjectSigned? signedObject = await _ossClient.CreateSignedResourceAsync(
			accessToken: token,
			access: Access.Write,
			bucketKey: bucketKey,
			objectKey: objectKey,
			createSignedResource: new()
			{
				MinutesExpiration = 60,
				SingleUse = false,
			});

		string signedUrl = signedObject.SignedUrl;
		string hash = new Uri(signedUrl).Segments.Last();

		ObjectDetails? objectDetails = null;
		int numChunks = (int)Math.Ceiling((double)fileSize / chunkSize);

		using var fileStream = File.OpenRead(sourceToUpload!);
		byte[] buffer = new byte[chunkSize];

		for (int index = 0; index < numChunks; index++)
		{
			long startByte = index * (long)chunkSize;
			long endByte = Math.Min(startByte + chunkSize - 1, fileSize - 1);
			int contentLength = (int)(endByte - startByte + 1);

			int bytesRead = await fileStream.ReadAsync(buffer.AsMemory(0, contentLength));
			using var chunkStream = new MemoryStream(buffer, 0, bytesRead);

			string contentRange = $"bytes {startByte}-{endByte}/{fileSize}";
			string contentType = $"application/octet-stream";

			objectDetails = await _ossClient.UploadSignedResourcesChunkAsync(
					accessToken: token,
					hash: hash,
					contentType: contentType,
					contentRange: contentRange,
					sessionId: sessionId,
					body: chunkStream);
		}

		Assert.IsNotNull(objectDetails);
		Assert.IsInstanceOfType<ObjectDetails>(objectDetails);
	}

	[TestMethod]
	public async Task TestGetSignedResourceAsync()
	{
		string hash = new Uri(signedUrl).Segments.Last();
		Stream? signedResource = await _ossClient.GetSignedResourceAsync(
			accessToken: token,
			hash: hash);
		Assert.IsNotNull(signedResource);
	}

	[TestMethod]
	public async Task TestDeleteSignedResourceAsync()
	{
		string hash = new Uri(signedUrl).Segments.Last();
		HttpResponseMessage httpResponseMessage = await _ossClient.DeleteSignedResourceAsync(
			accessToken: token,
			hash: hash);
		Assert.IsTrue(httpResponseMessage.StatusCode == HttpStatusCode.OK);
	}

	#endregion
}