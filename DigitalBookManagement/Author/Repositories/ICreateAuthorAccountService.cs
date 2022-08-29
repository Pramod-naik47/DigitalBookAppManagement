using Author.Models;

namespace Author.Repositories
{
    public interface ICreateAuthorAccout
    {
        string CreateAuthor(User userDetails);
    }
}
