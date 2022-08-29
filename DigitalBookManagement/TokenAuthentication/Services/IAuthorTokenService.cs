using TokenAuthentication.Models;

namespace TokenAuthentication.Services
{
    public interface IAuthorTokenService
    {
        User ValidateUser(string userName, string password);
    }
}