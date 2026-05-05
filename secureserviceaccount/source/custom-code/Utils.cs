using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using Autodesk.SecureServiceAccount.Model;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Autodesk.SecureServiceAccount
{
    /// <summary>
    /// Provides helper methods for secure service account authentication operations,
    /// including JWT assertion generation for APS token exchange.
    /// </summary>
    public class Utils
    {

        // NOTE: Ensure that your system clock is set correctly before running this code.

        /// <summary>
        /// Generates a signed JWT assertion for APS token exchange using the provided RSA private key.
        /// NOTE: Ensure that your system clock is set correctly before running this code.
        /// </summary>
        /// <param name="keyId">The key identifier (kid) included in the JWT header.</param>
        /// <param name="privateKey">PEM-formatted RSA private key used to sign the token.</param>
        /// <param name="clientId">The OAuth client ID, used as the <c>iss</c> claim.</param>
        /// <param name="ssaId">The service account identifier, used as the <c>sub</c> claim.</param>
        /// <param name="scopes">Requested scopes to include in the <c>scope</c> claim.</param>
        /// <param name="assertionLifetimeSeconds">The lifetime of the assertion in seconds. Must be 0 - 5 minutes in the future. Default is 300 seconds (5 minutes).</param>
        /// <returns>A compact serialized JWT assertion string.</returns>
        public static string GenerateJwtAssertion(string keyId, string privateKey, string clientId, string ssaId, List<Scopes> scopes, int assertionLifetimeSeconds = 300)
        {
            // Create RSA from the PEM-formatted private key
            using RSA rsa = RSA.Create();
            rsa.ImportFromPem(privateKey.ToCharArray());

            var securityKey = new RsaSecurityKey(rsa)
            {
                KeyId = keyId
            };

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha256);

            // Build JWT claims
            var claims = new List<Claim>
            {
                new Claim("iss", clientId),
                new Claim("sub", ssaId),
                new Claim("aud", "https://developer.api.autodesk.com/authentication/v2/token"),
            };

            string scopeJson = JsonConvert.SerializeObject(scopes);
            claims.Add(new Claim("scope", scopeJson, JsonClaimValueTypes.JsonArray));

            // Create the token with a specified expiration
            var jwtToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(assertionLifetimeSeconds),
                signingCredentials: signingCredentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jwtToken);
        }

        /// <summary>
        /// Generates a signed JWT assertion for APS token exchange using a readable stream containing
        /// a PEM-formatted RSA private key.
        /// </summary>
        /// <param name="clientId">The OAuth client ID, used as the <c>iss</c> claim.</param>
        /// <param name="serviceAccountId">The service account identifier, used as the <c>sub</c> claim.</param>
        /// <param name="privateKeyStream">A readable stream containing the PEM-formatted RSA private key.</param>
        /// <param name="keyId">The key identifier (kid) included in the JWT header.</param>
        /// <param name="scopes">Requested scopes to include in the <c>scope</c> claim.</param>
        /// <param name="assertionLifetimeSeconds">The lifetime of the assertion in seconds. Must be 0 - 5 minutes in the future. Default is 300 seconds (5 minutes).</param>
        /// <returns>A compact serialized JWT assertion string.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="privateKeyStream"/> is null or not readable.</exception>
        public static string GenerateJwtAssertion(string clientId, string serviceAccountId, Stream privateKeyStream, string keyId, List<Scopes> scopes, int assertionLifetimeSeconds = 300)
        {
            if (privateKeyStream is null || !privateKeyStream.CanRead)
                throw new ArgumentException($"{nameof(privateKeyStream)} must be a readable stream.", nameof(privateKeyStream));

            if (privateKeyStream.CanSeek && privateKeyStream.Position != 0)
                privateKeyStream.Seek(0, SeekOrigin.Begin);

            using StreamReader streamReader = new(privateKeyStream, leaveOpen: true);
            string privateKeyPem = streamReader.ReadToEnd();

            return GenerateJwtAssertion(clientId, serviceAccountId, privateKeyPem, keyId, scopes, assertionLifetimeSeconds);
        }

    }
}
