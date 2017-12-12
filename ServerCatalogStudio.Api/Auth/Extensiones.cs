using Microsoft.AspNetCore.Http;
using ServerCatalogStudio.Api.Auth.Models;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ServerCatalogStudio.Api.Auth
{
    public static class Extensiones
    {
        public static byte[] ToHash(this string input)
        {
            return (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
        }

        public static bool IsEqual(this byte[] a1, byte[] a2)
        {
            return StructuralComparisons.StructuralEqualityComparer.Equals(a1, a2);
        }

        public static Payload GetPayload(this HttpContext HttpContext)
        {
            var payload = new Payload();
            foreach (var item in HttpContext.User.Claims.ToList())
            {
                if (payload.Id != 0 && !string.IsNullOrWhiteSpace(payload.Email))
                {
                    break;
                }

                if (item.Type.Contains(JwtRegisteredClaimNames.NameId))
                {
                    payload.Id = int.Parse(item.Value);
                }

                if (item.Type.Contains(JwtRegisteredClaimNames.Email))
                {
                    payload.Email = item.Value;
                }


            }
            return payload;
        }
    }
}
