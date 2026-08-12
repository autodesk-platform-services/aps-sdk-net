/*
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components
 * that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk's expertise
 * in design and engineering.
 *
 * Secure Service Account
 *
 * Contact: aps.help@autodesk.com
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Autodesk.SecureServiceAccount.Model;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace Autodesk.SecureServiceAccount.Test;

/// <summary>
/// 	Offline tests for <see cref="Utils.GenerateJwtAssertion(string, string, string, string, List{Scopes}, int)"/>.
/// </summary>
/// <remarks>
/// 	These tests generate their own RSA key, so they require no credentials and make no network calls.
/// 	Each test generates a distinct key so the tests stay independent of execution order.
/// </remarks>
[TestClass]
public class TestJwtAssertion
{
    private static readonly string? keyId = Environment.GetEnvironmentVariable("KEY_ID");
    private static readonly string? clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
    private static readonly string? serviceAccountId = Environment.GetEnvironmentVariable("SERVICE_ACCOUNT_ID");
    private static List<Scopes> scopes => [Scopes.DataRead, Scopes.UserProfileRead];
    private static readonly string? expectedAudience = "https://developer.api.autodesk.com/authentication/v2/token";
    private static readonly string[] expectedScopes = ["data:read", "user-profile:read"];

    /// <summary>
    /// 	Creates a PEM-formatted RSA private key for a single test.
    /// </summary>
    /// <remarks>
    /// 	Each test gets its own key on purpose.
    /// 	The IdentityModel signature provider cache is process-wide and keyed on key material, so tests
    /// 	sharing one key could contaminate each other through that cache and become order dependent.
    /// 	Distinct keys guarantee each test observes only its own behaviour.
    /// </remarks>
    /// <returns>
    /// 	A PEM-formatted PKCS#8 RSA private key.
    /// </returns>
    private static string CreatePrivateKeyPem()
    {
        using RSA rsa = RSA.Create(2048);
        return rsa.ExportPkcs8PrivateKeyPem();
    }

    /// <summary>
    /// 	Regression test for the disposed-RSA signature provider cache defect.
    /// </summary>
    /// <remarks>
    /// 	The RSA used for signing is disposed when the method returns.
    /// 	If its RsaSecurityKey is allowed into the process-wide CryptoProviderFactory.Default cache,
    /// 	the cached provider outlives the RSA and the next call throws ObjectDisposedException.
    /// 	The faulted provider is then evicted, so failures alternate - a single call cannot catch this.
    /// 	Several iterations are required to prove the alternation is gone.
    /// </remarks>
    [TestMethod]
    public void GenerateJwtAssertion_CalledRepeatedlyInSameProcess_DoesNotThrow()
    {
        string privateKeyPem = CreatePrivateKeyPem();

        for (int i = 1; i <= 6; i++)
        {
            string assertion = Utils.GenerateJwtAssertion(
                keyId: keyId,
                privateKey: privateKeyPem,
                clientId: clientId,
                serviceAccountId: serviceAccountId,
                scopes: scopes);

            Assert.IsFalse(string.IsNullOrWhiteSpace(assertion), $"Call {i} produced an empty assertion.");
        }
    }

    /// <summary>
    /// 	Confirms the Stream overload is covered by the same fix, since it delegates to the string overload.
    /// </summary>
    [TestMethod]
    public void GenerateJwtAssertionFromStream_CalledRepeatedlyInSameProcess_DoesNotThrow()
    {
        string privateKeyPem = CreatePrivateKeyPem();

        for (int i = 1; i <= 6; i++)
        {
            using MemoryStream privateKeyStream = new(Encoding.UTF8.GetBytes(privateKeyPem));

            string assertion = Utils.GenerateJwtAssertion(
                keyId: keyId,
                privateKeyStream: privateKeyStream,
                clientId: clientId,
                serviceAccountId: serviceAccountId,
                scopes: scopes);

            Assert.IsFalse(string.IsNullOrWhiteSpace(assertion), $"Call {i} produced an empty assertion.");
        }
    }

    /// <summary>
    /// 	Guards the assertion contents, so the caching fix cannot silently change what is signed.
    /// </summary>
    [TestMethod]
    public void GenerateJwtAssertion_ProducesExpectedHeaderAndClaims()
    {
        string privateKeyPem = CreatePrivateKeyPem();

        string assertion = Utils.GenerateJwtAssertion(
            keyId: keyId,
            privateKey: privateKeyPem,
            clientId: clientId,
            serviceAccountId: serviceAccountId,
            scopes: scopes);

        JwtSecurityToken token = new JwtSecurityTokenHandler().ReadJwtToken(assertion);

        Assert.AreEqual("RS256", token.Header.Alg);
        Assert.AreEqual(keyId, token.Header.Kid);
        Assert.AreEqual(clientId, token.Claims.Single(claim => claim.Type == "iss").Value);
        Assert.AreEqual(serviceAccountId, token.Claims.Single(claim => claim.Type == "sub").Value);
        Assert.AreEqual(expectedAudience, token.Claims.Single(claim => claim.Type == "aud").Value);
        // The scope claim is written as a JSON array, so the handler expands it into one claim per element.
        string[] scopeValues = [.. token.Claims
            .Where(claim => claim.Type == "scope")
            .Select(claim => claim.Value)];

        CollectionAssert.AreEqual(expectedScopes, scopeValues);
    }

    /// <summary>
    /// 	Confirms the assertion still verifies against the signing key, proving the RSA was not disposed early.
    /// </summary>
    [TestMethod]
    public void GenerateJwtAssertion_SignatureVerifiesAgainstThePublicKey()
    {
        string privateKeyPem = CreatePrivateKeyPem();

        string assertion = Utils.GenerateJwtAssertion(
            keyId: keyId,
            privateKey: privateKeyPem,
            clientId: clientId,
            serviceAccountId: serviceAccountId,
            scopes: scopes);

        string[] parts = assertion.Split('.');
        Assert.AreEqual(3, parts.Length, "A compact JWT must have three parts.");

        using RSA rsa = RSA.Create();
        rsa.ImportFromPem(privateKeyPem.ToCharArray());

        byte[] signedBytes = Encoding.ASCII.GetBytes($"{parts[0]}.{parts[1]}");
        byte[] signature = Base64UrlEncoder.DecodeBytes(parts[2]);

        Assert.IsTrue(
            rsa.VerifyData(signedBytes, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1),
            "The assertion signature did not verify against the signing key.");
    }
}
