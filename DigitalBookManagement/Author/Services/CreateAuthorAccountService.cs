using Author.Models;
using Author.Repositories;

namespace Author.Services
{
    public class CreateAuthorAccoutService : ICreateAuthorAccout
    {
        public DigitalBookManagementContext _digitalBookManagementContext { get; set; }
        public CreateAuthorAccoutService(DigitalBookManagementContext digitalBookManagementContext)
        {
            _digitalBookManagementContext = digitalBookManagementContext;
        }

        /// <summary>
        /// This method will create account for author
        /// </summary>
        /// <param name="author">author</param>
        /// <returns>return a  message whether the author is created or not</returns>
        public string CreateAuthor(User author)
        {
            try
            {
                _digitalBookManagementContext.Users.Add(author);
                _digitalBookManagementContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return $"Operation failed {ex.Message}";
            }
            return $"Author account for {author.UserName} created successfully";
        }
    }
}
