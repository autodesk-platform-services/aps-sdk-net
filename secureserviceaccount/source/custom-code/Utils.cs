using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using Autodesk.SecureServiceAccount.Model;

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
        /// <returns>A compact serialized JWT assertion string.</returns>
        public static string GenerateJwtAssertion(string keyId, string privateKey, string clientId, string ssaId, List<Scopes> scopes)
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

            // Create the token with a 5-minute expiration
            var jwtToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(300),
                signingCredentials: signingCredentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jwtToken);
        }
    }
}