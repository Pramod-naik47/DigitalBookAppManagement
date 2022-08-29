using TokenAuthentication.Models;

namespace TokenAuthentication.Services
{
    public class AuthorTokenService : IAuthorTokenService
    {
        public TokenAuthenticationDbContext _tokenAuthenticationDbContext { get; set; }
        public AuthorTokenService(TokenAuthenticationDbContext tokenAuthenticationDbContext)
        {
            _tokenAuthenticationDbContext = tokenAuthenticationDbContext;
        }

        public User ValidateUser(string userName, string password)
        {
            var result = _tokenAuthenticationDbContext.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();

            return result;
        }
    }
}
