using System.Security.Claims;

namespace Author.Models
{
    public class AppAuthorizationClaims
    {
        public string UserType { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        public AppAuthorizationClaims(ClaimsIdentity claimIdentity)
        {
            this.UserType = claimIdentity.FindFirst("UserType").Value;
            this.UserName = claimIdentity.FindFirst("UserName").Value;
            this.UserId = claimIdentity.FindFirst("UserId").Value;
        }

    }
}
