
using System.Security.Claims;

namespace OnPeople.API.Extensions.Users
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserNameClaim(this ClaimsPrincipal user) {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static int GetUserIdClaim(this ClaimsPrincipal user) {
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }

        public static Boolean GetMasterClaim(this ClaimsPrincipal user) {
            Console.WriteLine("========================", user.FindFirst(ClaimTypes.Actor)?.Value);
            return (user.FindFirst(ClaimTypes.Actor)?.Value == "Master") ? true : false;
        }
    }
}