using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace Application.Web.Client.Utils
{
    public class JwtInfo
    {
        public IEnumerable<Claim> Claims { set; get; }

        public DateTime? ExpirationDateUtc { set; get; }

        public bool IsExpired { set; get; }

        public IEnumerable<string> Roles { set; get; }
    }

    public static class JwtParser
    {
        public static JwtInfo ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];

            var jsonBytes = getBase64WithoutPadding(payload);

            foreach (var keyValue in JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes))
            {
                if (keyValue.Value is JsonElement element && element.ValueKind == JsonValueKind.Array)
                {
                    foreach (var itemValue in element.EnumerateArray())
                    {
                        claims.Add(new Claim(keyValue.Key, itemValue.ToString()));
                    }
                }
                else
                {
                    claims.Add(new Claim(keyValue.Key, keyValue.Value.ToString()));
                }
            }

            var roles = getRoles(claims);
            var expirationDateUtc = getDateUtc(claims, "exp");
            var isExpired = getIsExpired(expirationDateUtc);
            return new JwtInfo
            {
                Claims = claims,
                Roles = roles,
                ExpirationDateUtc = expirationDateUtc,
                IsExpired = isExpired
            };
        }

        private static IList<string> getRoles(IList<Claim> claims) =>
            claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

        private static byte[] getBase64WithoutPadding(string base64)
        {  

            base64 = base64.Replace('-', '+'); // 62nd char of encoding
            base64 = base64.Replace('_', '/'); // 63rd char of encoding
            switch (base64.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 2: base64 += "=="; break; // Two pad chars
                case 3: base64 += "="; break; // One pad char
                default: throw new ArgumentOutOfRangeException(nameof(base64), "Illegal base64url string!");
            }
            return Convert.FromBase64String(base64); // Standard base64 decoder
        }

        private static bool getIsExpired(DateTime? expirationDateUtc) =>
            !expirationDateUtc.HasValue || !(expirationDateUtc.Value > DateTime.UtcNow);

        private static DateTime? getDateUtc(IList<Claim> claims, string type)
        {
            var exp = claims.SingleOrDefault(claim => claim.Type == type);
            if (exp == null)
            {
                return null;
            }

            var expValue = getTimeValue(exp.Value);
            if (expValue == null)
            {
                return null;
            }

            var dateTimeEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dateTimeEpoch.AddSeconds(expValue.Value);
        }

        private static long? getTimeValue(string claimValue)
        {
            if (long.TryParse(claimValue, out long resultLong))
                return resultLong;

            if (float.TryParse(claimValue, out float resultFloat))
                return (long)resultFloat;

            if (double.TryParse(claimValue, out double resultDouble))
                return (long)resultDouble;

            return null;
        }
    }
}
